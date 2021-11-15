using System.Collections.Generic;
using Models;

namespace Business
{
    public interface IStorefrontBL : IBaseBL<Storefront>
    {
        Storefront GetByPrimaryKeyWithNav(int storeId);
        IEnumerable<Storefront> GetAllWithNav();
        IEnumerable<Storefront> SearchStorefrontsByAddress(string query);
        IEnumerable<Storefront> SearchStorefrontsByName(string query);
    }
}
