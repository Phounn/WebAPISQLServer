﻿using Share.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Interface
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product product, int Id);
    }
}
