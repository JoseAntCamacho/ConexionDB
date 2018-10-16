using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ConexionDB
{
    public class SqlQuery
    {
        private IDbConnection _connection;
        
        public SqlQuery(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<T> Query<T>(string sql, Dictionary<string, object> parameter) where T : new()
        {
            _connection.Open();
            using (var cmd = Command(sql))
            {
                cmd.Connection = _connection;
                var datareader = cmd.ExecuteReader();
                var schema = GetSchema(datareader.GetSchemaTable());
                while (datareader.Read())
                {
                    yield return new Map<T>(schema, datareader).getValue();
                }
            }
            _connection.Close();
        }

        public IList<Schema> GetSchema(DataTable t)
        {
            return t.AsEnumerable().Select(c =>
            new Schema
            {
                Column = c.Field<String>("ColumnName"),
                Ordinal = c.Field<int>("ColumnOrdinal")
            }).ToList();
        }

        IDbCommand Command(string sql)
        {
            return new SqlCommand(sql);
        }
    }
}
