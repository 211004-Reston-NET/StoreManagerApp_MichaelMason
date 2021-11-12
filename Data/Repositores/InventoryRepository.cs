using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{

    public class InventoryRepository : Repository<Inventory>, IInventoryRepository
    {
        public InventoryRepository(StoreManagerContext context) : base(context)
        { }

        /// <summary>
        /// Queries DB for all Inventory entities, eager loads navigation properties
        /// </summary>
        /// <returns>IEnumerable<Inventory></returns>
        public IEnumerable<Inventory> GetAllWithNav()
        {
            var inventory = _context.Inventories
                .Include(i => i.Prod)
                .Include(i => i.StoreNumberNavigation);
            return inventory;
        }

        /// <summary>
        /// Queries DB for single item based on pirmary key, eager loads navigation properties
        /// </summary>
        /// <param name="intId">int</param>
        /// <returns>Inventory entity</returns>
        public Inventory GetByPrimaryKeyWithNav(int invId)
        {
            var inventory = _context.Inventories
                .Include(i => i.Prod)
                .Include(i => i.StoreNumberNavigation)
                .Single(i => i.InvId.Equals(invId));
            return inventory;
        }
    }
}
