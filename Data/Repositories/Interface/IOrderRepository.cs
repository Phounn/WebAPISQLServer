using Share.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Interface
{
    public interface IOrderRepository : IRepository<Order>
    {
        void Update(Order order, int Id);
    }
}
