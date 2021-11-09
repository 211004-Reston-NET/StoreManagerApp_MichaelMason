using Models;

namespace Data
{
    public interface IStorefrontRepository : IRepository<Storefront>
    {
        Storefront GetByPrimaryKeyWithNav(int storeId);
    }
}
