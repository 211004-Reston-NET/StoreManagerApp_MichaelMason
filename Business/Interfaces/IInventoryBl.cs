using System.Collections.Generic;
using Models;

namespace Business
{
    public interface IInventoryBl : IBaseBL<Inventory>
    {
        IEnumerable<Inventory> GetAllWithNav();
        Inventory GetByPrimaryKeyWithNav(int invId);
        IEnumerable<Inventory> GetInventoriesByProduct(Product entity);
        IEnumerable<Inventory> GetInventoriesByStore(Storefront entity);
        void UpdateInventoryQuantity(Inventory entity, int quantity);
    }
}