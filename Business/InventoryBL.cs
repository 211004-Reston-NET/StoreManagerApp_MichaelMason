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

        public IEnumerable<Inventory> GetAllWithNav()
        {
            return inventoryRepository.GetAllWithNav();
        }

        public Inventory GetByPrimaryKeyWithNav(int invId)
        {
            return inventoryRepository.GetByPrimaryKeyWithNav(invId);
        }

        public IEnumerable<Inventory> GetInventoriesByStore(Storefront entity)
        {
            return inventoryRepository.GetAll().Where(i => i.StoreNumber.Equals(entity.StoreNumber));
        }

        public IEnumerable<Inventory> GetInventoriesByProduct(Product entity)
        {
            return inventoryRepository.GetAll().Where(i => i.ProdId.Equals(entity.ProdId));
        }

        public void UpdateInventoryQuantity(Inventory entity, int quantity)
        {
            entity.Quantity += quantity;
        }
        /*
        public void JoinProductAndStore(Inventory entity)
        {
            return (from prod in prodBL.Products
                    join inv in prodBL.Inventories
                    on prod.ProdId equals inv.ProdId
                    where storeId == inv.StoreNumber
                    select prod);
        }
        */
    }
}