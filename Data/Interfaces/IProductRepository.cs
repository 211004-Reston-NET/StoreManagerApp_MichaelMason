using Models;

namespace Data
{
    public interface IProductRepository : IRepository<Product>
    {
        Product GetByPrimaryKeyWithNav(int prodId);
    }
}
