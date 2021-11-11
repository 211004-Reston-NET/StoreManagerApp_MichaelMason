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

        public IEnumerable<LineItem> GetAllWithNav()
        {
            return lineItemRepository.GetAllWithNav();
        }

        public LineItem GetByPrimaryKeyWithNav(int lineId)
        {
            return lineItemRepository.GetByPrimaryKeyWithNav(lineId);
        }

        public IEnumerable<LineItem> GetLineItemsByOrder(SOrder entity)
        {
            return lineItemRepository.GetAll().Where(l => l.OrderId.Equals(entity.OrderId));
        }

        public IEnumerable<LineItem> GetLineItemsByProduct(Product entity)
        {
            return lineItemRepository.GetAll().Where(l => l.ProdId.Equals(entity.ProdId));
        }

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