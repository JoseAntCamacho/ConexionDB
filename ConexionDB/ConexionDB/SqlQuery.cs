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

        public IEnumerable<T> Query<T>(string sql, Dictionary<string, object> parameter = null) where T : new()
        {
            //TODO: Hay que poner un try catch aquí.           
            _connection.Open();
            using (var cmd = Command(sql))
            {
                cmd.Connection = _connection;
                var datareader = cmd.ExecuteReader();
                var schema = GetSchema(datareader.GetSchemaTable());
                while (datareader.Read())
                {
                    yield return new Map<T>(schema, datareader.GetValue).getValue();
                }
            }
            _connection.Close();            
        }

        private IList<Schema> GetSchema(DataTable t) //es privado porque lo usamos solo aquí y no queremos que lo vean.
        {
            return t.AsEnumerable().Select(c =>
            new Schema
            {
                // TODO: Aquí tendríamos un problema si los nombre no coinciden. 
                // Hay que pasarlos a ToPascalCase().
                Column = c.Field<string>("ColumnName").ToPascalCase(),
                Ordinal = c.Field<int>("ColumnOrdinal")
            }).ToList();
        }

        /* Aquí se viola uno de los principios solid porque aquí no podemos burlar para testear.
           este trozo de comando, por lo que tendríamos que pasarlo por un atributo.*/
        
        private IDbCommand Command(string sql)
        {
            //TODO: Esto es muy restrictivo, hay que hacer un factory pattern para todos los tipos de comandos.
            return new SqlCommand(sql);
        }
    }
}
