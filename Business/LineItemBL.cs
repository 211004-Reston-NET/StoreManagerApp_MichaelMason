using System.Collections.Generic;
using System.IO;
using System.Linq;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models;

namespace Business
{

    public class LineItemBL : BaseBL<LineItem>, ILineItemBL
    {
        readonly ILineItemRepository lineItemRepository;
        public LineItemBL(ILineItemRepository lineItemRepository) : base(lineItemRepository)
        {
            this.lineItemRepository = lineItemRepository;
        }

        /// <summary>
        /// Gets all LineItem entities with associated navigation properties
        /// </summary>
        /// <returns>IEnumerable<LineItem></returns>
        public IEnumerable<LineItem> GetAllWithNav()
        {
            return lineItemRepository.GetAllWithNav();
        }

        /// <summary>
        /// Gets an LineItem entity and all associated navigation properties by primary key
        /// </summary>
        /// <param name="lineId">int</param>
        /// <returns>LineItem entity</returns>
        public LineItem GetByPrimaryKeyWithNav(int lineId)
        {
            return lineItemRepository.GetByPrimaryKeyWithNav(lineId);
        }

        /// <summary>
        /// Gets all LineItem entities associated with an SOrder entity
        /// </summary>
        /// <param name="entity">SOrder entity</param>
        /// <returns>IEnumerabe<LineItem></returns>
        public IEnumerable<LineItem> GetLineItemsByOrder(SOrder entity)
        {
            return lineItemRepository.GetAll().Where(l => l.OrderId.Equals(entity.OrderId));
        }

        /// <summary>
        /// Gets all LineItem entities associated with a Product entity
        /// </summary>
        /// <param name="entity">Product entity</param>
        /// <returns>IEnumerabe<LineItem></returns>
        public IEnumerable<LineItem> GetLineItemsByProduct(Product entity)
        {
            return lineItemRepository.GetAll().Where(l => l.ProdId.Equals(entity.ProdId));
        }

        /// <summary>
        /// Checks if LineItem Quantity is greater than inventory in stock
        /// </summary>
        /// <param name="inventory">Inventory entity</param>
        /// <param name="lineitem">LineItem entity</param>
        /// <returns>bool</returns>
        public bool LineItemQuantityIsGreaterThanInventory(Inventory inventory, LineItem lineitem)
        {
            if (lineitem.Quantity > inventory.Quantity)
            {
                return true;
            }
            return false;
        }
    }
}