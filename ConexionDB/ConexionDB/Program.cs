using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;

namespace ConexionDB
{
    class Program
    {
        static void Main(string[] args)
        {
            var sAttr = ConfigurationSettings.AppSettings.Get("DataSource");
            Console.WriteLine(sAttr);
            Console.ReadLine();
        }
    }
}
