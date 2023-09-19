using DevExpress.Xpo.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xRoadMap.Xpo
{
    public class OracleSDEProviderFactory : ODPManagedProviderFactory
    {

        public override IDataStore CreateProviderFromConnection(IDbConnection connection, AutoCreateOption autoCreateOption)
        {
            return OracleSDEConnectionProvider.CreateProviderFromConnection(connection, autoCreateOption);
        }
        public override IDataStore CreateProviderFromString(string connectionString, AutoCreateOption autoCreateOption, out IDisposable[] objectsToDisposeOnDisconnect)
        {
            return OracleSDEConnectionProvider.CreateProviderFromString(connectionString, autoCreateOption, out objectsToDisposeOnDisconnect);
        }
        public override string GetConnectionString(Dictionary<string, string> parameters)
        {
            if (!parameters.ContainsKey(ServerParamID) || !parameters.ContainsKey(UserIDParamID) || !parameters.ContainsKey(PasswordParamID)) { return null; }
            return OracleSDEConnectionProvider.GetConnectionString(parameters[ServerParamID], parameters[UserIDParamID], parameters[PasswordParamID]);
        }

    }
}
