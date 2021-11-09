using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{

    public class BaseBL<TEntity> : IBaseBL<TEntity> where TEntity : class
    {
        public readonly IRepository<TEntity> repository;
        public BaseBL(IRepository<TEntity> context)
        {
            repository = context;
        }

        public void Create(TEntity entity)
        {
            repository.Create(entity);
        }

        public virtual TEntity GetByPrimaryKey(int id)
        {
            return repository.GetByPrimaryKey(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return repository.GetAll();
        }

        public void Update(TEntity entity)
        {
            repository.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            repository.Delete(entity);
        }

        public void Save()
        {
            repository.Save();
        }
    }
}
