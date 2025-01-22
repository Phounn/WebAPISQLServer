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
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        readonly ContosoPizzaContext context;
        public OrderRepository(ContosoPizzaContext context) : base(context)
        {
            this.context = context;
        }

        public void Update(Order order, int Id)
        {
            var contentId = context.Orders.Find(Id);
            contentId!.OrderPlaced = order.OrderPlaced;
            contentId.OrderFulfilled = order.OrderFulfilled;
            contentId.CustomerId = order.CustomerId;
            contentId.Customer = order.Customer;
        }
    }
}
