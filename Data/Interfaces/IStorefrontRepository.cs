using System.Collections.Generic;
using Models;

namespace Data
{
    public interface IStorefrontRepository : IRepository<Storefront>
    {
        Storefront GetByPrimaryKeyWithNav(int storeId);
        IEnumerable<Storefront> GetAllWithNav();
    }
}
