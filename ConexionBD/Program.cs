using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ConexionBD
{
    class Program
    {
        static void Main(string[] args)
        {
            //DataProvider();
            DataSet();
        }

        public static void DataSet()
        {

            Console.WriteLine("llalaljsfjsldfjlasjfljasdjfl;kasjdflkjs");
            var ta = new ConexionBD.DataSet.MyDataSetTableAdapters.usuarioTableAdapter();
            var dt = ta.GetData();
            foreach (ConexionBD.DataSet.MyDataSet.usuarioRow row in dt.Rows)
            {
                Console.WriteLine("{0},{1},{2},{3}", 
                    row.idusuario, row.nombre, row.apellido, row.edad);
            }
            System.Threading.Thread.Sleep(9000);
            dt.Dispose();
            ta.Dispose();
        }
        /*
         */
     public static void DataProvider()
        {
            string connectionString = "Data Source=localhost;" +
               "Initial Catalog=info_db;" +
               "User id=connection;" +
               "Password =123456;";

            string Query = "Select * from Usuario";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(Query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine("{0},{1},{2},{3}", reader[0], reader[1], reader[2], reader[3]);
                    }
            
                    connection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
