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

        /// <summary>
        /// Gets all SOrder entities with associated navigation properties
        /// </summary>
        /// <returns>IEnumerable<SOrder></returns>
        public IEnumerable<SOrder> GetAllWithNav()
        {
            return orderRepository.GetAllWithNav();
        }

        /// <summary>
        /// Gets an SOrder entity and all associated navigation properties by primary key
        /// </summary>
        /// <param name="orderId">int</param>
        /// <returns>Inventory entity</returns>
        public SOrder GetByPrimaryKeyWithNav(int orderId)
        {
            return orderRepository.GetByPrimaryKeyWithNav(orderId);
        }

        /// <summary>
        /// Gets all SOrders associated with specific Storefront
        /// </summary>
        /// <param name="entity">Storefront entity</param>
        /// <returns>IEnumerable<SOrder></returns>
        public IEnumerable<SOrder> GetOrdersByStorefront(Storefront entity)
        {
            return orderRepository.GetAll().Where(s => s.StoreNumber.Equals(entity.StoreNumber));
        }

        /// <summary>
        /// Gets all SOrders associated with specific Customer
        /// </summary>
        /// <param name="entity">Customer entity</param>
        /// <returns>IEnumerable<SOrder></returns>
        public IEnumerable<SOrder> GetOrdersByCustomer(Customer entity)
        {
            return orderRepository.GetAll().Where(s => s.CustNumber.Equals(entity.CustNumber));
        }


        /// <summary>
        /// Updates the total price based on associated product id
        /// </summary>
        /// <param name="prodId">int</param>
        /// <param name="quantity">int</param>
        /// <returns></returns>
        public decimal UpdateTotalPrice(int prodId, int quantity)
        {

            var prod = productRepository.GetByPrimaryKey(prodId);
            return quantity * prod.ProdPrice;
        }

        /// <summary>
        /// Updates total inventory based on associated product id
        /// </summary>
        /// <param name="prodId">int</param>
        /// <param name="quantity">int</param>
        public void UpdateInventoryOnSale(int prodId, int quantity)
        {
            orderRepository.UpdateInventoryOnSale(prodId, quantity);
        }
    }
}