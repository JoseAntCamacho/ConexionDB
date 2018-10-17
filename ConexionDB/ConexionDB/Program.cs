using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;
using System.Linq.Expressions;


namespace ConexionDB
{ 
    class Program
    {
        public static bool IgualA1(int i)
        {
            return i == 1;
        }

        static void Main(string[] args)
        {
            /* para ver los delegados y el Enumerable
            Func<int, bool> valor;
            valor = IgualA1;            
            var objects = new int[] { 1, 2, 3, 4, 5, 6 };
            var query1 = objects.Where(c => c % 2 == 0).Select(c => c).OrderByDescending(c => c).ToList();
            var query2 = objects.Select(c => c % 2 == 0);
            foreach(var q in query1)
            {
                Console.WriteLine(q);
            }
            Console.WriteLine("------------------");
            foreach (var q in query2)
            {
                Console.WriteLine(q);
            }
            Console.Read();
            */

            /*para ver el IQueriable*/

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
