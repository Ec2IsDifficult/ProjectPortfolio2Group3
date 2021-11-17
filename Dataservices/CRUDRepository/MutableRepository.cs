using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Dataservices.CRUDRepository
{
    public class MutableRepository<TEntity> : ImmutableRepository<TEntity>, IMutableRepository<TEntity> where TEntity : class
    {
        public MutableRepository(DbContext context) : base(context)
        {
           
        }
        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            Context.SaveChanges();
        }
        
        //We might not need to have this functionality at all
        public void AddAll(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
            Context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            Context.Set<TEntity>().Update(entity);
            Context.SaveChanges();
        }

        public void UpdateAll(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().UpdateRange(entities);
            Context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
            Context.SaveChanges();
        }

        public void DeleteAll(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
            Context.SaveChanges();
        }
    }
}