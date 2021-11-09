using System.Text.Json;
using System.Collections.Generic;
using System.IO;
using Models;
using System;
using System.Linq;

namespace Data
{

    public class RepositoryJSON<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        /// <summary>
        /// Dependency injection
        /// </summary>
        protected const string _filepath = "./../Data/JSON/";
        protected string _jsonString;
        protected string _file;

        public RepositoryJSON()
        {
            if (typeof(TEntity).Equals(typeof(Customer)))
            {
                _file = "Customer.JSON";
            }
            if (typeof(TEntity).Equals(typeof(Inventory)))
            {
                _file = "Inventory.JSON";
            }
            if (typeof(TEntity).Equals(typeof(LineItem)))
            {
                _file = "LineItem.JSON";
            }
            if (typeof(TEntity).Equals(typeof(Product)))
            {
                _file = "Product.JSON";
            }
            if (typeof(TEntity).Equals(typeof(SOrder)))
            {
                _file = "SOrder.JSON";
            }
            if (typeof(TEntity).Equals(typeof(Storefront)))
            {
                _file = "Storefront.JSON";
            }

        }


        /// <summary>
        /// Sets model TEntity, creates new entity in memory
        /// </summary>
        /// <param name="entity">Model</param>
        /// 

        public void Create(TEntity entity)
        {
            var list = GetAll().ToList();
            list.Add(entity);
            _jsonString = JsonSerializer.Serialize(list, new JsonSerializerOptions{WriteIndented = true});
            File.WriteAllText(_filepath + "", _jsonString);
        }

        /// <summary>
        /// Sets model TEntity, deletes model from memory
        /// </summary>
        /// <param name="entity">Model</param>
        public void Delete(TEntity entity)
        {
            var list = GetAll().ToList();
            list.Remove(entity);
            _jsonString = JsonSerializer.Serialize(list, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filepath + "", _jsonString);
        }

        /// <summary>
        /// Sets model TEntity, returns all db entries in table
        /// </summary>
        /// <returns>IEnumerable<TEntity></returns>
        public IEnumerable<TEntity> GetAll()
        {
            try
            {
                _jsonString = File.ReadAllText(_filepath + _file);
            }
            catch(SystemException)
            {
                TEntity entity = new();
                List<TEntity> newList = new List<TEntity>();
                newList.Add(entity);
                File.WriteAllText(_filepath + _file, JsonSerializer.Serialize<List<TEntity>>(newList));

                _jsonString = File.ReadAllText(_filepath + _file);
            }

            return JsonSerializer.Deserialize<List<TEntity>>(_jsonString);
        }

        /// <summary>
        /// Sets model TEntity, returns exact match from db
        /// </summary>
        /// <param name="query">Table primary key (int)</param>
        /// <returns>TEntity[id]</returns>
        public TEntity GetByPrimaryKey(int query)
        {
            var list = GetAll().ToList();
            return list[query];
        }

        /// <summary>
        /// Sets model TEntity, updates entity in memory
        /// </summary>
        /// <param name="entity">Model</param>
        public void Update(TEntity entity)
        {
            var list = GetAll();
        }

        /// <summary>
        /// Saves changes to db
        /// </summary>
        public void Save()
        {
            var list = GetAll();
        }
    }
}