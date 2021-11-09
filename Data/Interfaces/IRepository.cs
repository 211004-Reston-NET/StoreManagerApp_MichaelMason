using System.Collections.Generic;

namespace Data
{
    public interface IRepository<TEntity> where TEntity : class
    {
        // create
        void Create(TEntity entity);

        // read
        IEnumerable<TEntity> GetAll();
        TEntity GetByPrimaryKey(int query);

        // update
        void Update(TEntity entity);

        // delete
        void Delete(TEntity entity);
        void Save();
    }
}