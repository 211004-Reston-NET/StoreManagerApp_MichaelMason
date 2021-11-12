using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{

    public class SOrderRepository : Repository<SOrder>, ISOrderRepository
    {
        public SOrderRepository(StoreManagerContext context) : base(context)
        {
        }

        /// <summary>
        /// Queries DB for all SOrder entities, eager loads navigation properties
        /// </summary>
        /// <returns>IEnumerable<SOrder></returns>
        public IEnumerable<SOrder> GetAllWithNav()
        {
            var orders = _context.SOrders
                .Include(o => o.CustNumberNavigation)
                .Include(o => o.StoreNumberNavigation);
            return orders;
        }

        /// <summary>
        /// Queries DB for single item based on pirmary key, eager loads navigation properties
        /// </summary>
        /// <param name="orderId">int</param>
        /// <returns>SOrder entity</returns>
        public SOrder GetByPrimaryKeyWithNav(int orderId)
        {
            var order = _context.SOrders
                .Include(o => o.CustNumberNavigation)
                .Include(o => o.StoreNumberNavigation)
                .Include(o => o.LineItems)
                .ThenInclude(l => l.Prod)
                .Single(o => o.OrderId.Equals(orderId));
            return order;
        }


        /// <summary>
        /// Updates Inventory quantity based on product id and line item quantity
        /// </summary>
        /// <param name="prodId">int</param>
        /// <param name="quantity">int</param>
        public void UpdateInventoryOnSale(int prodId, int quantity)
        {
            var inventory = _context.Inventories.Single(i => i.ProdId.Equals(prodId));
            inventory.Quantity -= quantity;
            _context.Update<Inventory>(inventory);
        }
    }
}
