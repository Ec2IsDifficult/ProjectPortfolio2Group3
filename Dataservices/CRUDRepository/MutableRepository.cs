using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Dataservices.CRUDRepository
{
    public class MutableRepository<TEntity> : ImmutableRepository<TEntity>, IMutableRepository<TEntity> where TEntity : class
    {
        public MutableRepository(Func<DbContext> contextFactory) : base(contextFactory)
        {
        }

        public void Add(TEntity entity)
        {
            var context = _contextFactory();
            context.Set<TEntity>().Add(entity);
            context.SaveChanges();
        }
        
        //We might not need to have this functionality at all
        public void AddAll(IEnumerable<TEntity> entities)
        {
            var context = _contextFactory();
            context.Set<TEntity>().AddRange(entities);
            context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            var context = _contextFactory();
            context.Set<TEntity>().Update(entity);
            context.SaveChanges();
        }

        public void UpdateAll(IEnumerable<TEntity> entities)
        {
            var context = _contextFactory();
            context.Set<TEntity>().UpdateRange(entities);
            context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            var context = _contextFactory();
            context.Set<TEntity>().Remove(entity);
            context.SaveChanges();
        }
    }
}