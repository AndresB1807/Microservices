using Microsoft.AspNetCore.Mvc;

namespace Microservicios.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Product>> GetAll()
        {
            return Products;
        }

        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            return Products.Single(x => x.Id == id);
        }

        public static List<Product> Products = new List<Product> 
        { 
            new Product
            {
                Id = 1,
                Name = "Guitarra",
                Price = 2323,
                Description = "Para tocar mago de oz"
            },
            new Product
            {
                Id = 2,
                Name = "Amplificador",
                Price = 34234,
                Description = "Para tocar la guitarrita"
            }
        };
    }
}
