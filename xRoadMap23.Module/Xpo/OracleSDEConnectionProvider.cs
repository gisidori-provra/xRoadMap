using DevExpress.Data.Filtering;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.DB.Helpers;
using Microsoft.SqlServer.Types;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xRoadMap.Xpo
{
    public class OracleSDEConnectionProvider : DevExpress.Xpo.DB.ODPManagedConnectionProvider
    {
        public new const string XpoProviderTypeString = "OracleSDE";
        public const string ShapeFieldName = "SHAPE";

        public OracleSDEConnectionProvider(IDbConnection connection, AutoCreateOption autoCreateOption) : base(connection, autoCreateOption)
        {

        }
        public new static string GetConnectionString(string server, string userId, string password)
        {
            return String.Format("{3}={4};Data Source={0};user id={1}; password={2};", EscapeConnectionStringArgument(server), EscapeConnectionStringArgument(userId), EscapeConnectionStringArgument(password), DataStoreBase.XpoProviderTypeParameterName, XpoProviderTypeString);
        }
        public new static IDbConnection CreateConnection(string connectionString)
        {
            return ReflectConnectionHelper.GetConnection("Oracle.ManagedDataAccess", "Oracle.ManagedDataAccess.Client.OracleConnection", connectionString);
        }
        public new static IDataStore CreateProviderFromString(string connectionString, AutoCreateOption autoCreateOption, out IDisposable[] objectsToDisposeOnDisconnect)
        {
            IDbConnection connection = CreateConnection(connectionString);
            objectsToDisposeOnDisconnect = new IDisposable[] { connection };
            return CreateProviderFromConnection(connection, autoCreateOption);
        }

        public new static IDataStore CreateProviderFromConnection(IDbConnection connection, AutoCreateOption autoCreateOption)
        {
            return new OracleSDEConnectionProvider(connection, autoCreateOption);
        }

        public override string FormatColumn(string columnName, string tableAlias)
        {
            if (columnName == ShapeFieldName)
                return $"DECODE(sde.st_isempty({tableAlias}.{ShapeFieldName}),0, sde.st_astext({tableAlias}.{ShapeFieldName}))";
            return base.FormatColumn(columnName, tableAlias);
        }

        public override string ComposeSafeColumnName(string columnName)
        {
            return base.ComposeSafeColumnName(columnName.ToUpper());
        }

        public override string ComposeSafeTableName(string tableName)
        {
            return base.ComposeSafeTableName(tableName.ToUpper());
        }
        protected override object ReformatReadValue(object value, ReformatReadValueArgs args)
        {
            return base.ReformatReadValue(value, args);
        }
        public override string FormatUpdate(string tableName, string sets, string whereClause)
        {
            var pair = sets.Split(',');
            for (int i = 0; i < pair.Length; i++)
            {
                var items = pair[i].Split('=');
                var fld = items[0];
                var val = items[1];
                if (fld == $"\"{ShapeFieldName}\"")
                {
                    sets = sets.Replace(pair[i], $"{fld} = (CASE WHEN {val} IS NULL THEN NULL ELSE sde.st_geomfromtext({val},25832) END)");
                }
            }

            return base.FormatUpdate(tableName, sets, whereClause);
        }

        public override string FormatInsert(string tableName, string fields, string values)
        {
            var vals = values.Split(',');
            var flds = fields.Split(',');
            for (int i = 0; i < flds.Length; i++)
            {
                if (flds[i] == $"\"{ShapeFieldName}\"")
                {
                    vals[i] = $"(CASE WHEN {vals[i]} IS NULL THEN NULL ELSE sde.st_geomfromtext({vals[i]},25832) END)";
                }
            }
            var format = base.FormatInsert(tableName, fields, string.Join(",", vals));
            return format;
        }

        protected override object ConvertToDbParameter(object clientValue, TypeCode clientValueTypeCode)
        {
            var r = base.ConvertToDbParameter(clientValue, clientValueTypeCode);
            return r;
        }

        protected override IDataParameter CreateParameter(IDbCommand command, object value, string name, DBColumnType dbType, string dbTypeName, int size)
        {
            var r =  base.CreateParameter(command, value, name, dbType, dbTypeName, size);
            if (dbTypeName == "SDE.ST_GEOMETRY")
            {
                Oracle.ManagedDataAccess.Client.OracleParameter p = r as Oracle.ManagedDataAccess.Client.OracleParameter;
                if (!(value is System.DBNull))
                    p.OracleDbType = Oracle.ManagedDataAccess.Client.OracleDbType.Clob;
                return p;
            }
            return r;
        }

        public override string FormatBinary(BinaryOperatorType operatorType, string leftOperand, string rightOperand)
        {
            return base.FormatBinary(operatorType, leftOperand, rightOperand);
        }

        protected override void PrepareDelegates()
        {
            base.PrepareDelegates();
        }

        static Dictionary<string, long> tableRegistry = new System.Collections.Generic.Dictionary<string, long>();
        protected override string GetSeqName(string tableName)
        {
            long regid;
            tableName = ComposeSafeTableName(tableName);
            if (tableRegistry.ContainsKey(tableName) == false)
            {
                object value = this.GetScalar(new Query($"SELECT REGISTRATION_ID FROM SDE.TABLE_REGISTRY WHERE Table_Name = '{tableName}' AND OWNER = (SELECT sys_context('USERENV','CURRENT_SCHEMA') from dual) "));
                if (value == null)
                    regid = -1;
                else
                    regid = ((IConvertible)value).ToInt64(System.Globalization.CultureInfo.InvariantCulture);
                tableRegistry.Add(tableName, regid);
            }
            else
                regid = tableRegistry[tableName];

            if (regid == -1)
                return base.GetSeqName(tableName);

            return $"R{regid}";

        }
        public new static void Register()
        {
            RegisterDataStoreProvider(XpoProviderTypeString, new DataStoreCreationFromStringDelegate(CreateProviderFromString));
            RegisterDataStoreProvider("Oracle.ManagedDataAccess.Client.OracleConnection", new DataStoreCreationFromConnectionDelegate(CreateProviderFromConnection));
            RegisterFactory(new OracleSDEProviderFactory());
        }
    }

}
