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
            List<Product> info = Datos.BuscarTodos();
            return info;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Product product = Datos.BuscarPorId(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }



        // POST api/<ValuesController>
        [HttpPost]
        public Product Post(string name,int price)
        {

          Product product = Datos.Crear(name, price);
          return product;


        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, string name, int price)
        {
            Product product = Datos.Actualizar(id,name,price);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool isDeleted = Datos.Borrar(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
