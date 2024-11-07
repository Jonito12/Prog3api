using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Dapper; 

namespace Negocio
{
    public class Datos
    {
        public string myConnectionString = "Server=db4free.net;Database=lasnieves110424;Uid=lasnieves110424;Pwd=lasnieves110424;";

        public static List<Product> productos = new List<Product>();

        public List<Product> BuscarTodos()
        {
            List<Product> productos = new List<Product>();

            using (MySqlConnection conn = new MySqlConnection(myConnectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Products";
                productos = conn.Query<Product>(sql).ToList();
            }

            return productos;

        }

        
    }
}
