using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{

    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(StoreManagerContext context) : base(context)
        {
        }

        public Product GetByPrimaryKeyWithNav(int prodId)
        {
            var product = _context.Products
                .Include(p => p.Inventories)
                .ThenInclude(i => i.StoreNumberNavigation)
                .Single(p => p.ProdId.Equals(prodId));
            return product;
        }
    }
}
