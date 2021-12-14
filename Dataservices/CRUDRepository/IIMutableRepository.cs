using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Dataservices.CRUDRepository
{
    //Generic interface. where the TEntity must be a reference type
    public interface IIMutableRepository <TEntity> where TEntity : class
    {
        TEntity Get<T>(T id);
        IEnumerable<TEntity> GetAll();
    }
}