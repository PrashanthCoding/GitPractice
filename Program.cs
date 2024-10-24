using Microsoft.AspNetCore.Mvc;

namespace SimpleWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // GET api/products
        [HttpGet]
        public ActionResult<Product> Get()
        {
            var product = new Product
            {
                Id = 1,
                Name = "Laptop",
                Price = 750.99M
            };
            return Ok(product);
        }
    }
}
