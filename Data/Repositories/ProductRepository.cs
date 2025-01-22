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
    public class ProductRepository : Repository<Product>, IProductRepository // class ທີ່ສືບທອດມານັ້ນ ຖ້າໂຕໃດຂຶ້ນກ່ອນ ຈະເປັນ class ຫຼັກໃນການສືບທອດ
    {
        private ContosoPizzaContext context;
        public ProductRepository(ContosoPizzaContext context) : base(context) // #1 ເວລາຍິງ api ເຂົ້າມາມັນຈະມາເຮັດໂຕນີ້ກ່ອນ ນັ້ນກໍຄືສົ່ງ argument context ໄປຫາclass ທີຖືກສືບທອດມາ. (Next) Repository
        {
            this.context = context;
        }

        public void Update(Product product, int Id)
        {
            var content = context.Products.Find(Id);
            content!.Name = product.Name;
            content!.Price = product.Price;
            context.Update(content);
        }
    }
}
