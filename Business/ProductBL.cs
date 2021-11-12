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

        /// <summary>
        /// Gets all Product entities with associated navigation properties
        /// </summary>
        /// <returns>IEnumerable<Product></returns>
        public IEnumerable<Product> GetAllWithNav()
        {
            return productRepository.GetAllWithNav();
        }

        /// <summary>
        /// Gets an Product entity and all associated navigation properties by primary key
        /// </summary>
        /// <param name="prodId">int</param>
        /// <returns>Product entity</returns>
        public Product GetByPrimaryKeyWithNav(int prodId)
        {
            return productRepository.GetByPrimaryKeyWithNav(prodId);
        }

        /// <summary>
        /// Gets all Product entities by entity field Name
        /// </summary>
        /// <param name="query">string</param>
        /// <returns>IEnumerabe<Product></returns>
        public IEnumerable<Product> GetProductByName(string query)
        {
            return productRepository.GetAll().Where(p => p.ProdName.Contains(query));
        }

        /// <summary>
        /// Gets all Product entities by entity field Description
        /// </summary>
        /// <param name="query">Storefront entity</param>
        /// <returns>IEnumerabe<Product></returns>
        public IEnumerable<Product> GetProductsByDescription(string query)
        {
            return productRepository.GetAll().Where(p => p.ProdDescription.Contains(query));
        }

        /// <summary>
        /// Gets all Product entities by entity field Category
        /// </summary>
        /// <param name="query">string</param>
        /// <returns>IEnumerabe<Product></returns>
        public IEnumerable<Product> GetProductsByCategory(string query)
        {
            return productRepository.GetAll().Where(p => p.ProdCategory.Contains(query));
        }
    }
}