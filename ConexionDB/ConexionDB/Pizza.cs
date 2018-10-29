using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionDB
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void MuestraPantalla()
        {
            Console.WriteLine("Tenemos la pizza con Id " + this.Id + " y con el nombre " + this.Name);
            //comentario.
        }
    }    
}
