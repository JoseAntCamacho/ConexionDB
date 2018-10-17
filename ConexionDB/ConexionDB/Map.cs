using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ConexionDB
{
    public class Schema
    {
        public string Column { get; set; }
        public int Ordinal { get; set; }
    }

    public class Map<T> where T : new()
    {
        private IList<Schema> _schema;
        //private IDataReader _reader;
        private Func<int, Object> _read;

        public Map(IList<Schema> schema, Func<int, Object> read) 
            // en puesto de pasar un IDataReader, es solo necesario pasar un puntero a un método.
            // Al final no ganas mucho, solo cambiar el GetValue de esta clase a SqlQuery.
            // Pero si haces esto es mucho más genérico y puedo testearlo mucho mejor.
        {
            _schema = schema;
            _read = read;
        }

        public T getValue()
        {
            var instancia = new T();
            foreach (var schema in _schema)
            {
                var property = instancia.GetType().GetProperty(schema.Column);
                if (null != property)
                {
                    property.SetValue(instancia, _read(schema.Ordinal));
                }
            }
            return instancia;
        }
    }
}
