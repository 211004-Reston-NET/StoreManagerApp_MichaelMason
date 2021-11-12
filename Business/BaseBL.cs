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

        /// <summary>
        /// Create a new entity of type TEntity
        /// </summary>
        /// <param name="entity">Model entity</param>
        public void Create(TEntity entity)
        {
            repository.Create(entity);
        }

        /// <summary>
        /// Get entity of type TEntity from DB by primary key (int)
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>entity</returns>
        public virtual TEntity GetByPrimaryKey(int id)
        {
            return repository.GetByPrimaryKey(id);
        }

        /// <summary>
        /// Get all entities of type TEnity from the DB
        /// </summary>
        /// <returns>IEnumerable<TEntity></returns>
        public IEnumerable<TEntity> GetAll()
        {
            return repository.GetAll();
        }

        /// <summary>
        /// Updates entity of type TEntity in the DB
        /// </summary>
        /// <param name="entity">TEntity entity</param>
        public void Update(TEntity entity)
        {
            repository.Update(entity);
        }

        /// <summary>
        /// Deletes entity of type TEntity from the DB
        /// </summary>
        /// <param name="entity">TEntity entity</param>
        public void Delete(TEntity entity)
        {
            repository.Delete(entity);
        }

        /// <summary>
        /// Saves all changes to the DB
        /// </summary>
        public void Save()
        {
            repository.Save();
        }
    }
}
