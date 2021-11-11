using System.Collections.Generic;
using Models;

namespace Business
{
    public interface ISOrderBL : IBaseBL<SOrder>
    {
        SOrder GetByPrimaryKeyWithNav(int orderId);
        IEnumerable<SOrder> GetAllWithNav();
        IEnumerable<SOrder> GetOrdersByCustomer(Customer entity);
        IEnumerable<SOrder> GetOrdersByStorefront(Storefront entity);
        decimal UpdateTotalPrice(int prodId, int quantity);
        void UpdateInventoryOnSale(int prodId, int quantity);
    }
}