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
    }
}
