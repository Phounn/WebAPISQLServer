using Data.Data;
using Data.Repositories.Interface;
using Share.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        readonly ContosoPizzaContext context;
        public CustomerRepository(ContosoPizzaContext context) : base(context)
        {
            this.context = context;
        }

        public void Update(Customer customer, int Id)
        {
            var contentId = context.Customers.Find(Id);
            contentId!.FirstName = customer.FirstName;
            contentId.LastName = customer.LastName;
            contentId.Email = customer.Email;
            contentId.Phone = customer.Phone;
        }
    }
}
