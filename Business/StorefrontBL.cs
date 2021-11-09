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

        public Storefront GetByPrimaryKeyWithNav(int storeId)
        {
            return storefrontRepository.GetByPrimaryKeyWithNav(storeId);
        }

        public IEnumerable<Storefront> SearchStorefrontsByAddress(string query)
        {
            return storefrontRepository.GetAll().Where(s => s.StoreAddress.ToLower().Contains(query.ToLower()));
        }

        public IEnumerable<Storefront> SearchStorefrontsByName(string query)
        {
            return storefrontRepository.GetAll().Where(s => s.StoreName.ToLower().Contains(query.ToLower()));
        }
    }
}
