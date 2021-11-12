using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{

    public class LineItemRepository : Repository<LineItem>, ILineItemRepository
    {
        public LineItemRepository(StoreManagerContext context) : base(context)
        {
        }

        /// <summary>
        /// Queries DB for all Cutomer entities, eager loads navigation properties
        /// </summary>
        /// <returns>IEnumerable<LineItem></returns>
        public IEnumerable<LineItem> GetAllWithNav()
        {
            var lineItems = _context.LineItems
                .Include(l => l.Order)
                .Include(l => l.Prod);
            return lineItems;
        }

        /// <summary>
        /// Queries DB for single item based on pirmary key, eager loads navigation properties
        /// </summary>
        /// <param name="lineId">int</param>
        /// <returns>LineItem entity</returns>
        public LineItem GetByPrimaryKeyWithNav(int lineId)
        {
            var lineItem = _context.LineItems
                .Include(l => l.Prod)
                .Include(l => l.Order)
                .Single(l => l.LineId.Equals(lineId));
            return lineItem;
        }
    }
}
