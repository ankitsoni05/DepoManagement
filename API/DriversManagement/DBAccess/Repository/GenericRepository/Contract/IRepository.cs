using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DBAccess.Repository.GenericRepository.Contract
{
    public interface IRepository<TEntity> where TEntity : class
    {
        //Getting Data
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity,bool>> predicate);

        //Adding Data
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        //Removing Data
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
