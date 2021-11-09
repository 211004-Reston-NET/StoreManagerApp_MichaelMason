using System.Collections.Generic;

namespace Business
{
    public interface IBaseBL<TEntity> where TEntity : class
    {
        void Create(TEntity entity);
        void Delete(TEntity entity);
        IEnumerable<TEntity> GetAll();
        TEntity GetByPrimaryKey(int id);
        void Save();
        void Update(TEntity entity);
    }
}
