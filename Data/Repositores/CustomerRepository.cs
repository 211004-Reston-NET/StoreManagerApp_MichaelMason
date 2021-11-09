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

        public Customer GetByPrimaryKeyWithNav(int custId)
        {
            var customer = _context.Customers
                .Include(c => c.SOrders)
                .ThenInclude(s => s.StoreNumberNavigation)
                .Single(c => c.CustNumber.Equals(custId));
            return customer;
        }
    }
}
