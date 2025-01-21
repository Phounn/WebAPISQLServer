using APIGateWay.Filter.ActionFilter;
using Data.Data;
using Share.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIGateWay.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        readonly ContosoPizzaContext? context;
        public ProductController(ContosoPizzaContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<List<Product>> GetAllProducts()
        {
            return Ok(context!.Products.ToList());
        }
        [HttpGet("{id}")]
        [Product_ValidateProductByIdFilter]
        public ActionResult<Product> GetProductById(int id)
        {
            var product = context!.Products.Where(x => x.Id == id).FirstOrDefault();
            return Ok(product);
        }
        [HttpPost]
        public ActionResult CreateProduct([FromBody] Product product)
        {
            try
            {
                if (product == null) return BadRequest();
                var content = new Product
                {
                    Name = product.Name,
                    Price = product.Price
                };

                context!.Products.Add(content);
                context.SaveChanges();
                return Ok(content);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "An error occurred while creating the product");
            }
        }
        [HttpPut("{id}")]
        public ActionResult<Product> UpdateProduct([FromBody] Product product, int id)
        {
            var content = context!.Products.Find(id);
            if (content is null || id < 0) return BadRequest();
            content.Name = product.Name;
            content.Price = product.Price;
            context.SaveChanges();
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            var content = context?.Products.Find(id);
            if (content?.Id != id) return BadRequest();
            context?.Products.Remove(content);
            context?.SaveChanges();
            return Ok();
        }
    }
}
