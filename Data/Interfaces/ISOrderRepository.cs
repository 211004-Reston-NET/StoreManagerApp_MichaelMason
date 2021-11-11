using Models;
using System.Collections.Generic;

namespace Data
{
    public interface ISOrderRepository : IRepository<SOrder>
    {
        SOrder GetByPrimaryKeyWithNav(int orderId);
        IEnumerable<SOrder> GetAllWithNav();
        void UpdateInventoryOnSale(int prodId, int quantity);
    }
}
