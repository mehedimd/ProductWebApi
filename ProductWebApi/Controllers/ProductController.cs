using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductWebApi.Models;

namespace ProductWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly MyContext db;
        public ProductController(MyContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var products = db.Products.ToList();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await db.Products.FindAsync(id);
            if(product != null)
            {
                return Ok(product);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            if(product != null)
            {
                db.Products.Add(product);
                if (db.SaveChanges() > 0)
                {
                    return Ok(product);
                }
            }
            return BadRequest();
        }
        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {
            if( product != null)
            {
                db.Products.Update(product);
                if (db.SaveChanges() > 0)
                {
                    return Ok(product);
                }
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await db.Products.FindAsync(id);
            if(product != null)
            {
                db.Products.Remove(product);
                if (db.SaveChanges() > 0)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }
    }
}
