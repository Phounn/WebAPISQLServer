using Data.Data;
using Data.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private ContosoPizzaContext? context;
        public IProductRepository ProductRepository { get; private set; } 
        public IOrderRepository OrderRepository { get; private set; }
        public ICustomerRepository CustomerRepository { get; private set; }
        public UnitOfWork(ContosoPizzaContext context)
        {
            this.context = context;
            ProductRepository = new ProductRepository(context);
            OrderRepository = new OrderRepository(context);
            CustomerRepository = new CustomerRepository(context);
        }
        public void Save()
        {
            context?.SaveChanges();
        }
    }
}
