using System.Collections.Generic;
using System.IO;
using System.Linq;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models;

namespace Business
{

    public class SOrderBL : BaseBL<SOrder>, ISOrderBL
    {
        protected readonly ISOrderRepository orderRepository;
        readonly IProductBL productRepository;
        public SOrderBL(ISOrderRepository orderRepository, IProductBL productRepository) : base(orderRepository)
        {
            this.orderRepository = orderRepository;
            this.productRepository = productRepository;
        }

        public IEnumerable<SOrder> GetAllWithNav()
        {
            return orderRepository.GetAllWithNav();
        }

        public SOrder GetByPrimaryKeyWithNav(int orderId)
        {
            return orderRepository.GetByPrimaryKeyWithNav(orderId);
        }

        public IEnumerable<SOrder> GetOrdersByStorefront(Storefront entity)
        {
            return orderRepository.GetAll().Where(s => s.StoreNumber.Equals(entity.StoreNumber));
        }

        public IEnumerable<SOrder> GetOrdersByCustomer(Customer entity)
        {
            return orderRepository.GetAll().Where(s => s.CustNumber.Equals(entity.CustNumber));
        }

        public decimal UpdateTotalPrice(int prodId, int quantity)
        {
            
                var prod = productRepository.GetByPrimaryKey(prodId);
                return quantity * prod.ProdPrice;
        }

        public void UpdateInventoryOnSale(int prodId, int quantity)
        {
            orderRepository.UpdateInventoryOnSale(prodId, quantity);
        }
    }
}