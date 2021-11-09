using System.Collections.Generic;

namespace Data
{
    
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Dependency injection
        /// </summary>
        protected readonly StoreManagerContext _context;
        public Repository(StoreManagerContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Sets model TEntity, creates new entity in memory
        /// </summary>
        /// <param name="entity">Model</param>
        public void Create(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        /// <summary>
        /// Sets model TEntity, deletes model from memory
        /// </summary>
        /// <param name="entity">Model</param>
        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        /// <summary>
        /// Sets model TEntity, returns all db entries in table
        /// </summary>
        /// <returns>IEnumerable<TEntity></returns>
        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>();
        }

        /// <summary>
        /// Sets model TEntity, returns exact match from db
        /// </summary>
        /// <param name="query">Table primary key (int)</param>
        /// <returns>TEntity[id]</returns>
        public TEntity GetByPrimaryKey(int query)
        {
            return _context.Set<TEntity>().Find(query);
        }

        /// <summary>
        /// Sets model TEntity, updates entity in memory
        /// </summary>
        /// <param name="entity">Model</param>
        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }

        /// <summary>
        /// Saves changes to db
        /// </summary>
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}