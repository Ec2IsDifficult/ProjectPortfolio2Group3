using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
namespace Dataservices.CRUDRepository
{
    public class ImmutableRepository<TEntity> : IIMutableRepository<TEntity> where TEntity : class
    {
        //Since the specific repositories need to inherit the functionality we need protected not private
        protected readonly DbContext Context;

        public ImmutableRepository(DbContext context)
        {
            Context = context;
        }
        
        public TEntity Get<T>(T id)
        {
            //The .Set function return a DbSet<TEntity> for access by subclasses (specific repositories)
            return Context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        //Figure out exactly what this does
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }
    }
}