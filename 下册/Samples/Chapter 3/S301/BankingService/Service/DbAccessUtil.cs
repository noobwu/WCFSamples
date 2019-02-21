using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Artech.TransactionalService.Service
{
    public static class DbAccessUtil
    {
        public static readonly DbHelper DbHelper = new DbHelper("BankingDb");

        public static int ExecuteNonQuery(string procedureName, IDictionary<string, object> parameters)
        {
            return DbHelper.ExecuteNonQuery(procedureName, parameters);
        }

        public static T ExecuteScalar<T>(string procedureName, IDictionary<string, object> parameters)
        {
            return DbHelper.ExecuteScalar<T>(procedureName, parameters);
        }
    }
}
