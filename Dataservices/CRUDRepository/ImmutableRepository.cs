using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
namespace Dataservices.CRUDRepository
{
    public class ImmutableRepository<TEntity> : IIMutableRepository<TEntity> where TEntity : class
    {
        protected readonly Func<DbContext> _contextFactory;
        public ImmutableRepository(Func<DbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public TEntity Get<T>(T id)
        {
            var context = _contextFactory();
            return context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            var context = _contextFactory();
            return context.Set<TEntity>().ToList();
        }
    }
}