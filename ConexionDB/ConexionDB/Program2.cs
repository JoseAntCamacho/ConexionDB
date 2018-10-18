using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ConexionDB
{
    class Program2 //ENTITY FRAMWORK.
    {
        static void Main(string[] args)
        {
            /* Esto sirve para poder añadir, actualizar y borrar en un contexto.
             * Y después salvas los resultados con el unit of work (savechanges).*/
             
            /*using( var context = new Context())
            {
                var pizza = new Pizza() { Name = "Salami y prosciuto"};
                context.Pizza.Add(pizza);
                context.SaveChanges();                
            }*/
            
            /* Y aquí lo recuperamos porque el context.Tsource es un IQueriable que podemos añadirle
             * toda la magia del LINQ para poder obtener el resultado deseado.*/
             
            /*using (var context = new Context())
            {
                var pizza = context.Pizza.Where(c => c.Id == 1);
                //esto no hace nada hasta que no le digas que traigas los datos o lo recorras con un foreach.
                var pizza2 =pizza.FirstOrDefault(); //trae el primero o el de por defecto
                pizza2.MuestraPantalla();
                pizza2.Name = "Salami y queso"; //ahora cambiamos el que hemos devuelto.
                context.SaveChanges();
                pizza = context.Pizza.Where(c => c.Id == 1);
                pizza2 = pizza.FirstOrDefault();
                pizza2.MuestraPantalla();
                // si le pongo el .AsNoTracking() le digo a la sentencia del Where() que no lo guarde en memoria lo que estoy haciendo, no me guardes el estado, no quiero modificar [SELECT]                 
            }*/

            /*using (var context = new Context())
            {
                // AHORA BORRAMOS LA LÍNEA CON id = 2.
                var listapizza = context.Pizza.Where(c => c.Id == 2);
                var pizza = listapizza.FirstOrDefault();
                context.Pizza.Remove(pizza);
                context.SaveChanges();
            } */

            /*using(var context = new Context())
            {
                var listapizzas = context.Pizza.Where(c => c.Id > 1);
                var pizza = listapizzas.ToList()[2];
                pizza.MuestraPantalla();
            }*/

            Console.Read();
            
        }
    }

    public class Context : DbContext
    {
        public DbSet<Pizza> Pizza { get; set; }
        public DbSet<Bar> Bar { get; set; }
    }
}
