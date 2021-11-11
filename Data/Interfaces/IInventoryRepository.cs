using Models;
using System.Collections.Generic;

namespace Data
{
    public interface IInventoryRepository : IRepository<Inventory>
    {
        IEnumerable<Inventory> GetAllWithNav();
        Inventory GetByPrimaryKeyWithNav(int invId);
    }
}
