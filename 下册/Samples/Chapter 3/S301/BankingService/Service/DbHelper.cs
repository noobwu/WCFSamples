using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Security.Permissions;

namespace Artech.TransactionalService.Service
{
    public class DbHelper
    {
        private DbProviderFactory _dbProviderFactory;
        private string _connectionString;

        public DbHelper(string connectionStringName)
        {
            string providerName = ConfigurationManager.ConnectionStrings[connectionStringName].ProviderName;
            this._connectionString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
            this._dbProviderFactory = DbProviderFactories.GetFactory(providerName);
        }

        private DbConnection CreateConnection()
        {
            DbConnection connection = this._dbProviderFactory.CreateConnection();
            connection.ConnectionString = this._connectionString;
            return connection;
        }

        private void DeriveParameters(DbCommand discoveryCommand)
        {
            if (discoveryCommand.CommandType != CommandType.StoredProcedure)
            {
                return;
            }

            if (this._dbProviderFactory is SqlClientFactory)
            {
                SqlCommandBuilder.DeriveParameters((SqlCommand)discoveryCommand);
            }

            if (this._dbProviderFactory is OracleClientFactory)
            {
                OracleCommandBuilder.DeriveParameters((OracleCommand)discoveryCommand);
            }
        }

        private void AssignParameters(DbCommand command, IDictionary<string, object> parameters)
        {
            IDictionary<string, object> copiedParams = new Dictionary<string, object>();
            foreach (var item in parameters)
            {
                copiedParams.Add(item.Key.ToLowerInvariant(), item.Value);
            }
            foreach (DbParameter parameter in command.Parameters)
            {
                if (!copiedParams.ContainsKey(parameter.ParameterName.TrimStart('@').ToLowerInvariant()))
                {
                    continue;
                }

                parameter.Value = copiedParams[parameter.ParameterName.TrimStart('@').ToLowerInvariant()];
            }
        }
        
        public int ExecuteNonQuery(string procedureName, IDictionary<string, object> parameters)
        {
            using (DbConnection connection = this.CreateConnection())
            {
                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = procedureName;
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    this.DeriveParameters(command);
                    this.AssignParameters(command, parameters);
                    return command.ExecuteNonQuery();
                }
            }
        }

        public T ExecuteScalar<T>(string procedureName,  IDictionary<string, object> parameters)
        {
            using (DbConnection connection = this.CreateConnection())
            {
                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = procedureName;
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    this.DeriveParameters(command);
                    this.AssignParameters(command, parameters);
                    return (T)command.ExecuteScalar();
                }
            }
        }
    }
}