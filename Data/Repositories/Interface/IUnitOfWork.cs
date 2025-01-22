using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Interface
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get;  }
        IOrderRepository OrderRepository { get; }
        ICustomerRepository CustomerRepository { get;  }
        void Save();

    }
}
