using Share.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Interface
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        void Update(Customer customer, int Id);
    }
}
