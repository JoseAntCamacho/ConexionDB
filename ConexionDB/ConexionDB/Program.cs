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
            
            try
            {
                Dapper.ConnectionString = ConfigurationManager.AppSettings["DataSource1"];
                var query = Dapper.Open().Query<Pizza>("Select * from [table]", null).ToList();
                foreach (var p in query)
                {
                    p.MuestraPantalla();
                }
            }
            catch(Exception e)
            {

            }
            finally
            {
                
            }
            
            Console.ReadLine();
        }

        public class Pizza
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public Pizza() { }
            public Pizza(int id, string name)
            {
                Id = id;
                Name = name;
            }
            public void MuestraPantalla()
            {
                Console.WriteLine("Tenemos la pizza con Id " + this.Id + " y con el nombre " + this.Name);
            }
        }
    }
}
