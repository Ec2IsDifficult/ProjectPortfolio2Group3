namespace DataServices
{
    using System;
    using Dataservices.IRepositories;

    public interface IUnitOfWork : IDisposable
    {
        IPersonRepository Persons { get; }
        int Complete();
    }
}