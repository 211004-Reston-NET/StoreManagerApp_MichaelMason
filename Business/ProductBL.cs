using System.Collections.Generic;
using System.Linq;
using Data;
using Models;

namespace Business
{

    public class ProductBL : BaseBL<Product>, IProductBL
    {
        readonly IProductRepository productRepository;
        public ProductBL(IProductRepository productRepository) : base(productRepository)
        {
            this.productRepository = productRepository;
        }

        public Product GetByPrimaryKeyWithNav(int prodId)
        {
            return productRepository.GetByPrimaryKeyWithNav(prodId);
        }

        public IEnumerable<Product> GetProductByName(string query)
        {
            return productRepository.GetAll().Where(p => p.ProdName.Contains(query));
        }

        public IEnumerable<Product> GetProductsByDescription(string query)
        {
            return productRepository.GetAll().Where(p => p.ProdDescription.Contains(query));
        }

        public IEnumerable<Product> GetProductsByCategory(string query)
        {
            return productRepository.GetAll().Where(p => p.ProdCategory.Contains(query));
        }
    }
}