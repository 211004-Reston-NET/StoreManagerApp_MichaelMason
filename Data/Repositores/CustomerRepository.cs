using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{

    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(StoreManagerContext context) : base(context)
        {
        }

        /// <summary>
        /// Queries DB for single item based on pirmary key, eager loads navigation properties
        /// </summary>
        /// <param name="custId">int</param>
        /// <returns>Customer entity</returns>
        public Customer GetByPrimaryKeyWithNav(int custId)
        {
            var customer = _context.Customers
                .Include(c => c.SOrders)
                .ThenInclude(s => s.StoreNumberNavigation)
                .Single(c => c.CustNumber.Equals(custId));
            return customer;
        }

        /// <summary>
        /// Queries DB for all Cutomer entities, eager loads navigation properties
        /// </summary>
        /// <returns>IEnumerable<Customer></returns>
        public IEnumerable<Customer> GetAllWithNav()
        {
            var customer = _context.Customers
                .Include(c => c.SOrders)
                .ThenInclude(s => s.StoreNumberNavigation);
            return customer;
        }
    }
}
