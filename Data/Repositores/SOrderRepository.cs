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

        public IEnumerable<SOrder> GetAllWithNav()
        {
            var orders = _context.SOrders
                .Include(o => o.CustNumberNavigation)
                .Include(o => o.StoreNumberNavigation);
            return orders;
        }

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

        public void UpdateInventoryOnSale(int prodId, int quantity)
        {
            var inventory = _context.Inventories.Single(i => i.ProdId.Equals(prodId));
            inventory.Quantity -= quantity;
            _context.Update<Inventory>(inventory);
        }
    }
}
