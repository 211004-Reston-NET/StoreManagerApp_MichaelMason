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
        public SOrderBL(ISOrderRepository orderRepository) : base(orderRepository)
        {
            this.orderRepository = orderRepository;
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

        public decimal UpdateTotalPrice(SOrder entity, IEnumerable<LineItem> lineItems)
        {
            decimal total = 0;
            foreach (var item in lineItems)
            {
                entity.TotalPrice += item.Quantity * item.Prod.ProdPrice;
            }
            return total;
        }
    }
}