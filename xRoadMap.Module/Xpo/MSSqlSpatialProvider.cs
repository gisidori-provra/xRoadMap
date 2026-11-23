using DevExpress.Persistent.BaseImpl.MultiTenancy;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.DB.Exceptions;
using DevExpress.Xpo.DB.Helpers;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Data.SqlClient;
using Microsoft.SqlServer.Types;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xRoadMap.Xpo
{

    // https://supportcenter.devexpress.com/ticket/details/t331156/troubleshooting-version-mismatch-system-invalidcastexception-object-must-implement#

    public class MSSqlSpatialProvider : MSSqlConnectionProvider
    {
        private static IServiceProvider _serviceProvider;
        public new const string XpoProviderTypeString = "MSSqlSpatial";
        public const string ShapeFieldName = "SHAPE";

        public static new void Register()
        {
            RegisterDataStoreProvider(XpoProviderTypeString, new DataStoreCreationFromStringDelegate(CreateProviderFromString));
        }

        public MSSqlSpatialProvider(IDbConnection connection, AutoCreateOption autoCreateOption)
          : base(connection, autoCreateOption)
        {

        }

        public override UpdateSchemaResult UpdateSchema(bool doNotCreateIfFirstTableNotExist, params DBTable[] tables)
        {
            var exists = FunctionExists("dbo", "STMaxM");
            if (exists == false)
            {
                ExecuteSqlSchemaUpdate("Function", "STMaxM", string.Empty, """
                CREATE OR ALTER   FUNCTION [dbo].[STMaxM]
                (
                    @geom geometry
                )
                RETURNS FLOAT
                AS
                BEGIN
                    DECLARE @i INT = 1;
                    DECLARE @n INT;
                    DECLARE @m FLOAT;
                    DECLARE @maxM FLOAT = NULL;

                    IF @geom IS NULL
                        RETURN NULL;

                    SET @n = @geom.STNumPoints();

                    WHILE @i <= @n
                    BEGIN
                        SET @m = @geom.STPointN(@i).M;

                        IF @m IS NOT NULL
                           AND (@maxM IS NULL OR @m > @maxM)
                            SET @maxM = @m;

                        SET @i = @i + 1;
                    END;

                    RETURN @maxM;
                END;
                """);
            }

            exists = FunctionExists("dbo", "STMinM");
            if (exists == false)
            {
                ExecuteSqlSchemaUpdate("Function", "STMinM", string.Empty, """
                CREATE OR ALTER   FUNCTION [dbo].[STMinM]
                (
                    @geom geometry
                )
                RETURNS FLOAT
                AS
                BEGIN
                    DECLARE @i INT = 1;
                    DECLARE @n INT;
                    DECLARE @m FLOAT;
                    DECLARE @minM FLOAT = NULL;

                    IF @geom IS NULL
                        RETURN NULL;

                    SET @n = @geom.STNumPoints();

                    WHILE @i <= @n
                    BEGIN
                        SET @m = @geom.STPointN(@i).M;

                        IF @m IS NOT NULL
                           AND (@minM IS NULL OR @m < @minM)
                            SET @minM = @m;

                        SET @i = @i + 1;
                    END;

                    RETURN @minM;
                END;
                """);
            }
            return base.UpdateSchema(doNotCreateIfFirstTableNotExist, tables);
        }

        public new static string GetConnectionString(string server, string catalog)
        {
            string connectionString = MSSqlConnectionProvider.GetConnectionString(server, catalog);
            return connectionString.Replace(MSSqlConnectionProvider.XpoProviderTypeString, XpoProviderTypeString);
        }

        public new static string GetConnectionString(string server, string userid, string password, string catalog)
        {
            string connectionString = MSSqlConnectionProvider.GetConnectionString(server, userid, password, catalog);
            return connectionString.Replace(MSSqlConnectionProvider.XpoProviderTypeString, XpoProviderTypeString);

        }

        public static new IDataStore CreateProviderFromString(string connectionString, AutoCreateOption autoCreateOption, out IDisposable[] objectsToDisposeOnDisconnect)
        {
            IDbConnection connection = new SqlConnection(connectionString);
            objectsToDisposeOnDisconnect = new IDisposable[] { connection };
            return CreateProviderFromConnection(connection, autoCreateOption);
        }


        public static new IDataStore CreateProviderFromConnection(IDbConnection connection, AutoCreateOption autoCreateOption)
        {
            return new MSSqlSpatialProvider(connection, autoCreateOption);
        }

        protected override object ReformatReadValue(object value, ReformatReadValueArgs args)
        {
            // This implementation deactivates the default behavior of the base 
            // class logic, because the conversion step is not necessary for the types
            // SqlGeography and SqlGeometry, and because the attempt at conversion
            // results in exceptions since there is no automatic conversion mechanism.
            if (value != null)
            {
                Type valueType = value.GetType();
                if (valueType == typeof(SqlGeography) || valueType == typeof(SqlGeometry))
                    return value;
            }
            return base.ReformatReadValue(value, args);
        }

        public override string FormatColumn(string columnName, string tableAlias)
        {
            if (IsShapeField(columnName))
                return $"{tableAlias}.{ComposeSafeColumnName(ShapeFieldName)}.STAsText()";

            return base.FormatColumn(columnName, tableAlias);
        }

        public override string FormatUpdate(string tableName, string sets, string whereClause)
        {
            var pairs = sets.Split(',');
            for (int i = 0; i < pairs.Length; i++)
            {
                var items = pairs[i].Split('=');
                if (items.Length != 2)
                    continue;

                var fld = items[0].Trim();
                var val = items[1].Trim();
                if (IsShapeField(fld))
                {
                    pairs[i] = $"{fld} = CASE WHEN {val} IS NULL THEN NULL ELSE geometry::STGeomFromText({val}, 25832) END";
                }
            }

            return base.FormatUpdate(tableName, string.Join(",", pairs), whereClause);
        }

        public override string FormatInsert(string tableName, string fields, string values)
        {
            var vals = values.Split(',');
            var flds = fields.Split(',');
            for (int i = 0; i < flds.Length && i < vals.Length; i++)
            {
                if (IsShapeField(flds[i]))
                {
                    vals[i] = $"CASE WHEN {vals[i]} IS NULL THEN NULL ELSE geometry::STGeomFromText({vals[i]}, 25832) END";
                }
            }

            return base.FormatInsert(tableName, fields, string.Join(",", vals));
        }

        private static bool IsShapeField(string name)
        {
            return name
                .Replace("[", string.Empty)
                .Replace("]", string.Empty)
                .Replace("\"", string.Empty)
                .Trim()
                .Equals(ShapeFieldName, StringComparison.OrdinalIgnoreCase);
        }

        // Metodo per impostare il service provider da Startup.cs
        public static void SetServiceProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }


        private bool FunctionExists(string schema, string name)
        {
            using var command = Connection.CreateCommand();

            command.CommandText = $"""
        SELECT CASE
            WHEN OBJECT_ID(N'{schema}.{name}', N'FN') IS NULL THEN 0
            ELSE 1
        END
        """;

            return Convert.ToInt32(command.ExecuteScalar()) == 1;
        }
    }
}
