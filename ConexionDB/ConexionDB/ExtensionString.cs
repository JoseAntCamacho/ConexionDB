using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionDB
{
    public static class ExtensionString
    {
        // extensionMethod, necesitamos extender una clase que no es nuestra. 
        // tiene que ser una clase estática, con un método estático cuyo primer parámetro sea el this T, 
        // donde T es el objeto o clase que queremos extender.
        // Esta clase es para pasar a PascalCase.
        public static string ToPascalCase (this string value)
        {
            if(null == value || string.Empty == value)
            {
                return null;
            }
            if (value.Length < 2)
            {
                return value.ToUpper();
            }
            return string.Format("{0}{1}", char.ToUpperInvariant(value[0]),value.Substring(1)); 
            // devolvemos la primera letra en mayúscula y el resto igual.
        }

         // Otro método que podríamos extender de string para hacerlo en camelCase.
        public static string ToCamelCase (this string value)
        {
            return value;
        }

    }
}
