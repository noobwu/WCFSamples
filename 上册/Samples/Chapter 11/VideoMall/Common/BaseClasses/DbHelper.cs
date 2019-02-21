using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Practices.Unity.Utility;

namespace Artech.VideoMall.Common
{
    public abstract class DbHelper
    {
        private Dictionary<CacheKey, DbParameterCollection> cachedParameters = new Dictionary<CacheKey, DbParameterCollection>();

        protected string ConnectionStringName { get; private set; }
        protected string ConnectionString { get; private set; }
        public DbProviderFactory Factory { get; private set; }

        public DbHelper(string connectionStringName)
        {
            Guard.ArgumentNotNullOrEmpty(connectionStringName, "connectionStringName");
            this.ConnectionStringName = connectionStringName;
            ConnectionStringSettings cnnStringSettings = ConfigurationManager.ConnectionStrings[connectionStringName];
            this.ConnectionString = cnnStringSettings.ConnectionString;
            this.Factory = DbProviderFactories.GetFactory(cnnStringSettings.ProviderName);
        }

        protected abstract void DeriveParameters(DbCommand discoveryCommand);
        protected virtual int UserParametersStartIndex()
        {
            return 1;
        }
        public virtual string BuildParameterName(string name)
        {
            if (name.StartsWith("@"))
            {
                return name;
            }
            return "@" + name;
        }
        protected virtual void AssignParameters(DbCommand command, object[] parameters)
        {
            CacheKey key = new CacheKey { Database = this.ConnectionStringName, Procedure = command.CommandText };
            if (!cachedParameters.ContainsKey(key))
            {
                this.DeriveParameters(command);
                lock (cachedParameters)
                {
                    cachedParameters[key] = command.Parameters;
                }
            }
            int parameterIndexShift = this.UserParametersStartIndex();
            for (int i = 0; i < parameters.Length; i++)
            {
                IDataParameter parameter = command.Parameters[i + parameterIndexShift];
                command.Parameters[this.BuildParameterName(parameter.ParameterName)].Value = parameters[i] ?? DBNull.Value;
            }
        }

        public virtual T ExecuteScalar<T>(string procedure, params object[] parameters)
        {
            using (DbConnection connection = this.Factory.CreateConnection())
            {
                connection.ConnectionString = this.ConnectionString;
                DbCommand command = connection.CreateCommand();
                command.CommandText = procedure;
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                if (null != parameters)
                {
                    this.AssignParameters(command, parameters);
                }
                return (T)command.ExecuteScalar();
            }
        }
        public virtual int ExecuteNonQuery(string procedure, params object[] parameters)
        {
            using (DbConnection connection = this.Factory.CreateConnection())
            {
                connection.ConnectionString = this.ConnectionString;
                DbCommand command = connection.CreateCommand();
                command.CommandText = procedure;
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                if (null != parameters)
                {
                    this.AssignParameters(command, parameters);
                }
                return command.ExecuteNonQuery();
            }
        }
        public virtual DbDataReader ExecuteReader(string procedure, params object[] parameters)
        {
            DbConnection connection = this.Factory.CreateConnection();
            connection.ConnectionString = this.ConnectionString;
            DbCommand command = connection.CreateCommand();
            command.CommandText = procedure;
            command.CommandType = CommandType.StoredProcedure;
            try
            {
                connection.Open();
                if (null != parameters)
                {
                    this.AssignParameters(command, parameters);
                }

                return command.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch
            {
                connection.Close();
                throw;
            }
        }
    }

    internal class CacheKey
    {
        public string Database { get; set; }
        public string Procedure { get; set; }
        public override int GetHashCode()
        {
            return this.Database.GetHashCode() ^ this.Procedure.GetHashCode();
        }
    }
    public class SqlDbHelper : DbHelper
    {
        public SqlDbHelper(string connectionStringName)
            : base(connectionStringName)
        { }

        protected override void DeriveParameters(DbCommand discoveryCommand)
        {           
            SqlCommandBuilder.DeriveParameters(discoveryCommand as SqlCommand);
        }
    }
}
