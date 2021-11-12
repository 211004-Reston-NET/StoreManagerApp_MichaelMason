using System.Collections.Generic;
using System.IO;
using System.Linq;
using Data;
using Models;

namespace Business
{

    public class InventoryBl : BaseBL<Inventory>, IInventoryBl
    {
        readonly IInventoryRepository inventoryRepository;
        public InventoryBl(IInventoryRepository inventoryRepository) : base(inventoryRepository)
        {
            this.inventoryRepository = inventoryRepository;
        }

        /// <summary>
        /// Gets all Inventory entities with associated navigation properties
        /// </summary>
        /// <returns>IEnumerable<Inventory></returns>
        public IEnumerable<Inventory> GetAllWithNav()
        {
            return inventoryRepository.GetAllWithNav();
        }

        /// <summary>
        /// Gets an Inventory entity and all associated navigation properties by primary key
        /// </summary>
        /// <param name="invId">int</param>
        /// <returns>Inventory entity</returns>
        public Inventory GetByPrimaryKeyWithNav(int invId)
        {
            return inventoryRepository.GetByPrimaryKeyWithNav(invId);
        }

        /// <summary>
        /// Gets all Inventory entities associated with a Storefront entity
        /// </summary>
        /// <param name="entity">Storefront entity</param>
        /// <returns>IEnumerabe<Inventory></returns>
        public IEnumerable<Inventory> GetInventoriesByStore(Storefront entity)
        {
            return inventoryRepository.GetAll().Where(i => i.StoreNumber.Equals(entity.StoreNumber));
        }

        /// <summary>
        /// Gets all Inventory entities associated with a Product entity
        /// </summary>
        /// <param name="entity">Product entity</param>
        /// <returns>IEnumerabe<Inventory></returns>
        public IEnumerable<Inventory> GetInventoriesByProduct(Product entity)
        {
            return inventoryRepository.GetAll().Where(i => i.ProdId.Equals(entity.ProdId));
        }

        /// <summary>
        /// Updates the Inventory entity Quantity field
        /// </summary>
        /// <param name="entity">Inventory entity</param>
        /// <param name="quantity">int</param>
        public void UpdateInventoryQuantity(Inventory entity, int quantity)
        {
            entity.Quantity += quantity;
        }
    }
}