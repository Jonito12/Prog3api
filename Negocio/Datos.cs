using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Datos
    {
        public static List<Product> productos = new List<Product>();

        public static List<Product> BuscarTodos()
        {
            return productos;
        }

        public static Product Crear(string Name, int Price)
        {
            Random random = new Random();
            int randomId = random.Next(0, 100);
            string name = Name;
            int price = Price;
            Product product = new Product(price, name, randomId);

            productos.Add(product);

            return product;
        }

       public static Product BuscarPorId(int Id)
       {
            Product product = productos.FirstOrDefault(p => p.Id == Id);
            return product;
       }

        public static Product? Actualizar(int Id, string Name, int Price)
        {
            Product product = productos.FirstOrDefault(p => p.Id == Id);
            if (product == null)
            {
                return null;
            }

            product.Name = Name;
            product.Price = Price;    
            return product;
        }
        public static bool Borrar(int Id)
        {
            Product? product = productos.FirstOrDefault(p => p.Id == Id);
            if (product == null)
            {
                return false;
            }

            productos.Remove(product);
            return true;
        }
            
    }
}
