using Data_Reader_Writer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data_Reader_Writer.Repositories
{
    /// <summary>
    /// Generic repository providing basic CRUD operations on GenericEntity. 
    /// This repository can used by derived repositories to get access to common basic CRUD operations.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class GenericRepository<T> where T : GenericEntity
    {
        public List<T> DataList { get; set; }

        public GenericRepository()
        {
            DataList = new List<T>();
        }

        /// <summary>
        /// Insert data into the DB entity
        /// </summary>
        /// <param name="obj">Entry coming for insertion</param>
        public virtual void Insert(T obj)
        {
            obj.DateCreated = DateTime.Now;
            obj.DateModified = DateTime.Now;

            int currentId = 0;
            var lastEntry = DataList.OrderByDescending(data => data.Id).FirstOrDefault();

            if(lastEntry is null)
            {
                currentId = 1;
            }
            else
            {
                currentId = lastEntry.Id + 1;
            }

            obj.Id = currentId;

            DataList.Add(obj);
        }

        /// <summary>
        /// Delete an entity by Id from DB entity
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual bool Delete(int id)
        {
            var obj = DataList.SingleOrDefault(entity => entity.Id == id);

            return DataList.Remove(obj);
        }

        /// <summary>
        /// Find entity in DB by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T FindById(int id)
        { 
            return DataList.SingleOrDefault(item => item.Id == id);
        }

        /// <summary>
        /// Find all entities in DB that match the predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual List<T> FindAll(Expression<Func<T, bool>> predicate = null)
        {
            return DataList.AsQueryable().Where(predicate).ToList();
        }

        /// <summary>
        /// Update and entity in DB
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual bool Update(T entity)
        {
            var entry = DataList.SingleOrDefault(data => data.Id == entity.Id);

            if(entry is null)
            {
                return false;
            }

            entry = entity;
            return true;
        }
    }
}
