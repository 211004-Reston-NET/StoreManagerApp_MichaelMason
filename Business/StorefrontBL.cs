using System.Collections.Generic;
using System.Linq;
using Data;
using Models;

namespace Business
{

    public class StorefrontBL : BaseBL<Storefront>, IStorefrontBL
    {
        protected readonly IStorefrontRepository storefrontRepository;
        public StorefrontBL(IStorefrontRepository storefrontRepository) : base(storefrontRepository)
        {
            this.storefrontRepository = storefrontRepository;
        }

        /// <summary>
        /// Gets an Storefront entity and all associated navigation properties by primary key
        /// </summary>
        /// <param name="invId">int</param>
        /// <returns>Storefront entity</returns>
        public Storefront GetByPrimaryKeyWithNav(int storeId)
        {
            return storefrontRepository.GetByPrimaryKeyWithNav(storeId);
        }

        public IEnumerable<Storefront> GetAllWithNav()
        {
            return storefrontRepository.GetAllWithNav();
        }

        /// <summary>
        /// Gets all Storefront entities by entity address field
        /// </summary>
        /// <param name="query">string</param>
        /// <returns>IEnumerable<Storefront></returns>
        public IEnumerable<Storefront> SearchStorefrontsByAddress(string query)
        {
            return storefrontRepository.GetAll().Where(s => s.StoreAddress.ToLower().Contains(query.ToLower()));
        }


        /// <summary>
        /// Gets all Storefront entities by entity name field
        /// </summary>
        /// <param name="query">string</param>
        /// <returns>IEnumerable<Storefront></returns>
        public IEnumerable<Storefront> SearchStorefrontsByName(string query)
        {
            return storefrontRepository.GetAll().Where(s => s.StoreName.ToLower().Contains(query.ToLower()));
        }
    }
}
