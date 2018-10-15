using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;
using System.Data.SqlClient;

namespace ConexionDB
{
    class Program
    {
        public class Pizza
        {
            public int Id { get; set; }
            public string Name { get; set; }

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

        public class Dapper:IDisposable
        {
            private string DataSource = ConfigurationSettings.AppSettings.Get("DataSource");
            private SqlConnection Connection { get; set; }

            public Dapper()
            {
                this.Connection = new SqlConnection(this.DataSource);
            }

            public void Open()
            {                                
                this.Connection.Open();
                Console.WriteLine("He abierto la conexión");
                Console.WriteLine(this.Connection.State.ToString());
            }

            public void Query()
            {
                
            }

            public void Dispose()
            {
                this.Connection.Close();
                Console.WriteLine("Ha entrado en el Dispose. Cerramos.");
            }

            public void Close()
            {
                if (this.Connection.State.ToString().Equals("Closed"))
                {
                    Console.WriteLine("Son iguales y lo cerraría");
                }
                if (String.Compare(this.Connection.State.ToString(),"Closed") == 0)
                {
                    Console.WriteLine("He cerrado la conexión");
                }
                this.Connection.Close();
                Console.WriteLine(this.Connection.State.ToString());
            }
        }

        static void Main(string[] args)
        {
            var dapper = new Dapper();
            try
            {
                dapper.Open();
                dapper.Close();
            }
            catch(Exception e)
            {

            }
            finally
            {
                Console.WriteLine("Hemos entrado en el finally y cerramos la conexión por si las moscas");
            }
            
            Console.ReadLine();
        }
        /*static void Main(string[] args)
        {
            var connection = new SqlConnection();
            connection.ConnectionString = @"
                Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Pizzeria;
                Integrated Security=True;Connect Timeout=30;Encrypt=False;
                TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //aunque esta línea de arriba puede dar problemas y por eso lo debemos meter en el try, podemos crearlo como un singletone y así lo ponemos arriba.
            // la cadena de conexión la guardaríamos en el appconfig.
            try
            {
                connection.Open();
                Console.WriteLine("La conexión se ha abierto correctamente.");
                SqlCommand cmd = new SqlCommand("select * from [table] where id=@id");
                cmd.Parameters.Add(new SqlParameter("@id", 1)); //añadimos los parámetros para buscar el de id = 1. 
                cmd.Connection = connection;
                
                var reader = cmd.ExecuteReader();
                while (reader.Read()) //.Read() es como un MoveNext, se trae lo que estamos leyendo.
                {
                    var schema = reader.GetSchemaTable();
                    // si no queremos poner el 0 y el 1 (posiciones de las columnas) tenemos que recuperar los metadatos.
                    var pizza = new Pizza(reader.GetInt32(0), reader.GetString(1));
                    
                    pizza.MuestraPantalla();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Tenemos un problema, no ha habido conexión.");
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                    Console.WriteLine("La conexión se ha cerrado correctamente tras abrirla, estamos en el finnaly");
                    Console.ReadLine();
                }
            }
        }*/
    }
}
