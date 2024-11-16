using Microsoft.AspNetCore.Mvc;
using Negocio;
using System.Xml.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiProgra3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {


        // GET: api/<ValuesController>
        [HttpGet]
        public List<Product> Get()
        {
            Datos informacion = new Datos();
            List<Product> info = informacion.BuscarTodos();
            return info;

        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Datos informacion = new Datos();
            Product product = informacion.BuscarPorId(id);  // Cambiado de Datos.BuscarPorId(id) para devolver un Product
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }


        // POST api/<ValuesController>
        [HttpPost]
        public Product Post(string title, int price)
        {
            Datos informacion = new Datos();
            Product product = new Product { Title = title, Price = price };  // Creación del objeto Product
            Product createdProduct = informacion.Crear(product);
            return createdProduct;
        }


        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, string title, int price)
        {
            Datos informacion = new Datos();
            Product product = new Product { Title = title, Price = price };
            Product updateproduct = informacion.Actualizar(id, product);
            if (updateproduct == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Datos informacion = new Datos();
            int product = informacion.Borrar(id);
            if (product == 0)
            {
                return NotFound();
            }
            return Ok("El producto fue eliminado correctamente."); ;
        }
    }
}
