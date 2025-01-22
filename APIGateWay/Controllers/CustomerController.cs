using APIGateWay.Filter.ActionFilter;
using Data.Repositories;
using Data.Repositories.Interface;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Share.Entities;

namespace APIGateWay.Controllers
{

    [ApiController]
    [Route("/api/[controller]")]
    public class CustomerController : ControllerBase
    {
        readonly IUnitOfWork unitOfWork;
        public CustomerController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpGet]
        public ActionResult<List<Customer>> GetAllCustomers()
        {
            return Ok(unitOfWork.CustomerRepository.GetAll());
        }
        [HttpGet("{id}")]
        [Id_ValidateFilter]
        public ActionResult<Customer> GetCustomerById(int id)
        {
            var content = unitOfWork.CustomerRepository.GetById(id);
            return Ok(content);
        }
        [HttpPost]
        public ActionResult CreateCustomer(Customer customer)
        {
            try
            {
                unitOfWork.CustomerRepository.Create(customer);
                unitOfWork.Save();
            }
            catch (Exception ex) { }
            return Ok();
        }
        [HttpPut("{id}")]
        public ActionResult UpdateCustomer(Customer customer, int id)
        {
            unitOfWork.CustomerRepository.Update(customer, id);
            unitOfWork.Save();
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteCustomer(int id)
        {
            unitOfWork.CustomerRepository.Delete(id);
            unitOfWork.Save();
            return Ok();
        }
    }
}
