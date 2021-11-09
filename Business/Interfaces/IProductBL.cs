using System.Collections.Generic;
using Models;

namespace Business
{
    public interface IProductBL : IBaseBL<Product>
    {
        Product GetByPrimaryKeyWithNav(int prodId);
        IEnumerable<Product> GetProductByName(string query);
        IEnumerable<Product> GetProductsByCategory(string query);
        IEnumerable<Product> GetProductsByDescription(string query);
    }
}