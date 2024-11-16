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

        public int Crear(string title, Product p)
        {
            int resultado = 0;

            using (MySqlConnection conn = new MySqlConnection(myConnectionString))
            {
                conn.Open();
                string sql = "INSERT INTO Products (Title, Description, Category, Price) VALUES (@Title,@Description,@Category, @Price)";
                resultado = conn.Execute(sql, p);
            }

            return resultado;
        }

        public Product Actualizar(int id, Product p)
        {
            int resultado = 0;

            using (MySqlConnection conn = new MySqlConnection(myConnectionString))
            {
                conn.Open();
                string sql = "UPDATE Products SET Title = @Title, Description = @Description, Category = @Category, Price = @Price WHERE Id = @Id";
                p.Id = id;  // Establece el ID para la actualización
                resultado = conn.Execute(sql, p);
            }

            return p;
        }



        public int Borrar(int id)
        {
            int resultado = 0;

            using (MySqlConnection conn = new MySqlConnection(myConnectionString))
            {
                conn.Open();
                string sql = "DELETE FROM Products WHERE Id = @Id";  // Corrección en el nombre de la tabla
                resultado = conn.Execute(sql, new { Id = id });
            }

            return resultado;
        }


        public Product BuscarPorId(int id)
        {
            Product resultado = null;

            using (MySqlConnection conn = new MySqlConnection(myConnectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Products WHERE Id = @Id";  
                resultado = conn.QueryFirstOrDefault<Product>(sql, new { Id = id });
            }

            return resultado;
        }


        public Product Crear( Product p)
        {
            using (MySqlConnection conn = new MySqlConnection(myConnectionString))
            {
                conn.Open();
                string sql = "INSERT INTO Products (Title, Description, Category, Price) VALUES (@Title, @Description, @Category, @Price)";
                conn.Execute(sql, p);

                return p;
            }
        }
    }
}
