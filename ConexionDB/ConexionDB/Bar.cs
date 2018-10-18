using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionDB
{
    public class Bar
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void MuestraPantalla()
        {
            Console.WriteLine("Tenemos el bar con Id " + this.Id + " y con el nombre " + this.Name);
        }
    }
}
