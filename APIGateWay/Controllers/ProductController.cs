using APIGateWay.Filter.ActionFilter;
using Data.Data;
using Share.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data.Repositories.Interface;
// ບົດຮຽນນນນນນນນນນນນນນນນນນນນນນນນນນນນນນນນນນນນນນນນນນນນນນນນນນນນນນນນນນນນນນນນນນນນນນນນນນນນນນນນນນນນ
namespace APIGateWay.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        readonly ContosoPizzaContext? context;
        readonly IProductRepository repository;
        readonly IUnitOfWork unitOfWork;
        public ProductController(ContosoPizzaContext context, IProductRepository repository, IUnitOfWork unitOfWork) //#3 Next Here
        {
            this.context = context; // ໃຊ້ແບບໂດຍກົງ
            this.repository = repository; // ໃຊ້ແບບ repository
            this.unitOfWork = unitOfWork; // ສາມາດເບິ່ງໄດ້ໃນcontroller ໂຕອື່ນ ເພາະໂຕນີ້ມັນເລະແລ້ວ
        }

        [HttpGet]
        public ActionResult<List<Product>> GetAllProducts()//#4 Next
        {
            var content = repository.GetAll(); //#6
            return Ok(content);
            //return Ok(context!.Products.ToList()); // return directly
        }
        [HttpGet("{id}")]
        [Id_ValidateFilter]
        public ActionResult<Product> GetProductById(int id)
        {
            //var product = context!.Products.Where(x => x.Id == id).FirstOrDefault();
            //return Ok(product);

            var content = repository.GetById(id);
            return Ok(content);
        }
        [HttpPost]
        public ActionResult CreateProduct([FromBody] Product product)
        {
            //try
            //{
            //    if (product == null) return BadRequest();
            //    var content = new Product
            //    {
            //        Name = product.Name,
            //        Price = product.Price
            //    };

            //    context!.Products.Add(content);
            //    context.SaveChanges();
            //    return Ok(content);
            //}
            //catch (Exception ex)
            //{
            //    // Log the exception
            //    return StatusCode(500, "An error occurred while creating the product");
            //}
            try
            {
                if (product == null) return BadRequest();
                var content = new Product
                {
                    Name = product.Name,
                    Price = product.Price
                };

                repository.Create(content);
                context?.SaveChanges();
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
            //var content = context!.Products.Find(id);
            //if (content is null || id < 0) return BadRequest();
            //content.Name = product.Name;
            //content.Price = product.Price;
            //context.SaveChanges();
            //return Ok(product);
            repository.Update(product, id);
            context?.SaveChanges();
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            //var content = context?.Products.Find(id);
            //if (content?.Id != id) return BadRequest();
            //context?.Products.Remove(content);
            //context?.SaveChanges();
            //return Ok();
            repository.Delete(id);
            context?.SaveChanges();
            return Ok();

        }
    }
}
