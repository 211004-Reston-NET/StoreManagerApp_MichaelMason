using System.Collections.Generic;
using Models;

namespace Business
{
    public interface ISOrderBL : IBaseBL<SOrder>
    {
        SOrder GetByPrimaryKeyWithNav(int orderId);
        IEnumerable<SOrder> GetOrdersByCustomer(Customer entity);
        IEnumerable<SOrder> GetOrdersByStorefront(Storefront entity);
        decimal UpdateTotalPrice(SOrder entity, IEnumerable<LineItem> lineItems);
    }
}