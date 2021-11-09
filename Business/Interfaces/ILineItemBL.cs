using System.Collections.Generic;
using Models;

namespace Business
{
    public interface ILineItemBL : IBaseBL<LineItem>
    {
        IEnumerable<LineItem> GetLineItemsByOrder(SOrder entity);
        IEnumerable<LineItem> GetLineItemsByProduct(Product entity);
        bool LineItemQuantityIsGreaterThanInventory(Inventory inventory, LineItem lineitem);
    }
}