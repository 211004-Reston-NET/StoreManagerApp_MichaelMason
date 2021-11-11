using Models;
using System.Collections.Generic;

namespace Data
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetAllWithNav();
        Product GetByPrimaryKeyWithNav(int prodId);
    }
}
