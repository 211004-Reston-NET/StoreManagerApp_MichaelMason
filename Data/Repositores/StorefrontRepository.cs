using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{

    public class StorefrontRepository : Repository<Storefront>, IStorefrontRepository
    {
        public StorefrontRepository(StoreManagerContext context) : base(context)
        {
        }

        /// <summary>
        /// Queries DB for single item based on pirmary key, eager loads navigation properties
        /// </summary>
        /// <param name="storeId">int</param>
        /// <returns>Storefront entity</returns>
        public Storefront GetByPrimaryKeyWithNav(int storeId)
        {
            var storefront = _context.Storefronts
                .Include(o => o.SOrders)
                .ThenInclude(s => s.StoreNumberNavigation)
                .Include(o => o.Inventories)
                .ThenInclude(s => s.Prod)
                .Single(o => o.StoreNumber.Equals(storeId));
            return storefront;
        }

        /// <summary>
        /// Queries DB for all Storefront entities, eager loads navigation properties
        /// </summary>
        /// <returns>IEnumerable<Storefront></returns>
        public IEnumerable<Storefront> GetAllWithNav()
        {
            var storefront = _context.Storefronts
                .Include(o => o.SOrders)
                .ThenInclude(s => s.StoreNumberNavigation)
                .Include(o => o.Inventories)
                .ThenInclude(s => s.Prod);
            return storefront;
        }
    }
}
