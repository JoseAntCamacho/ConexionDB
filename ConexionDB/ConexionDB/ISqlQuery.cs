using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionDB
{
    interface ISqlQuery
    {
        IEnumerable<T> Query<T>(string sql, Dictionary<string, object> parameter = null) where T : new();
    }
}
