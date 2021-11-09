using Models;
using System.Collections.Generic;


namespace Business
{
    public interface ICustomerBL : IBaseBL<Customer>
    {
        Customer GetByPrimaryKeyWithNav(int id);
        IEnumerable<Customer> SearchByAddress(string query);
        IEnumerable<Customer> SearchByEmail(string query);
        IEnumerable<Customer> SearchByName(string query);
        IEnumerable<Customer> SearchByPhone(string query);
    }
}
