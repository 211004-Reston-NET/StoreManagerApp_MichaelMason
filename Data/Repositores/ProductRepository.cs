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

        /// <summary>
        /// Queries DB for all Product entities, eager loads navigation properties
        /// </summary>
        /// <returns>IEnumerable<Product></returns>
        public IEnumerable<Product> GetAllWithNav()
        {
            var products = _context.Products
                .Include(p => p.Inventories)
                .ThenInclude(p => p.StoreNumberNavigation);
            return products;
        }

        /// <summary>
        /// Queries DB for single item based on pirmary key, eager loads navigation properties
        /// </summary>
        /// <param name="prodId">int</param>
        /// <returns>Product entity</returns>
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
