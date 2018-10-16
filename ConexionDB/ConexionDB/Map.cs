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
        private IDataReader _reader;

        public Map(IList<Schema> schema, IDataReader reader)
        {
            _schema = schema;
            _reader = reader;
        }

        public T getValue()
        {
            var instancia = new T();
            foreach (var schema in _schema)
            {
                var property = instancia.GetType().GetProperty(schema.Column);
                if (null != property)
                {
                    property.SetValue(instancia, _reader.GetValue(schema.Ordinal));
                }
            }
            return instancia;
        }
    }
}
