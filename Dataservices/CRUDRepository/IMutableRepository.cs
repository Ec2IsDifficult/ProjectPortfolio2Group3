using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Dataservices.CRUDRepository
{
    using System.Collections.Generic;

    public interface IMutableRepository<TEntity>
    {
        void Add(TEntity entity);
        void AddAll(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void UpdateAll(IEnumerable<TEntity> entities);
        void Delete(TEntity entity);
    }
}