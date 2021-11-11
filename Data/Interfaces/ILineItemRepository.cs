using Models;
using System.Collections.Generic;

namespace Data
{
    public interface ILineItemRepository : IRepository<LineItem>
    {
        IEnumerable<LineItem> GetAllWithNav();
        LineItem GetByPrimaryKeyWithNav(int lineId);
    }
}
