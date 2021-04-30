using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;

namespace RealEstateApp.DataAccess
{
    public static class SqlDataAccess
    {
        public static string GetConnecttionString(string connectionName = "RealEstateDbConnection")
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }

        public static List<T> LoadData<T>(string sql)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnecttionString()))
            {
                return cnn.Query<T>(sql).ToList();
            }
        }
        public static int SaveData<T>(string sql, T data)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnecttionString()))
            {
                return cnn.Execute(sql, data);
            }
        }

    }
}
