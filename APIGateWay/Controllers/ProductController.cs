using Data.Data;
using Data.Models;

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
        public List<Product> GetAllProducts()
        {

            return context!.Products.ToList();

        }
    }
}
