using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Dataservices
{
    //Generic interface. where the TEntity must be a reference type
    public interface IRepository<TEntity> where TEntity : class
    {
        
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        //The find function takes a predicate which is a lambda function "Expression<Func<TEntity, bool>>"
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void AddAll(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void UpdateAll(IEnumerable<TEntity> entities);
        void Delete(TEntity entity);
        void DeleteAll(IEnumerable<TEntity> entities);
    }
}