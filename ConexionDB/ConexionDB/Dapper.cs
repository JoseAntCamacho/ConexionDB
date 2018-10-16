using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace ConexionDB
{
    public class Dapper
    {
        public static string ConnectionString { get; set; }

        public static SqlQuery Open()
        {
            return new SqlQuery(GetConnection());
        }

        private static IDbConnection GetConnection()
        {
            return new SqlConnection(Dapper.ConnectionString);
        }
        
    }
}
