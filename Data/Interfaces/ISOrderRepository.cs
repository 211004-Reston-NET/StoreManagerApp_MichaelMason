using Models;

namespace Data
{
    public interface ISOrderRepository : IRepository<SOrder>
    {
        SOrder GetByPrimaryKeyWithNav(int orderId);
    }
}
