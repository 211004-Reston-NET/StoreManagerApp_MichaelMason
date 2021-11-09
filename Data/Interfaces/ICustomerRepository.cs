using Models;

namespace Data
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetByPrimaryKeyWithNav(int custId);
    }
}
