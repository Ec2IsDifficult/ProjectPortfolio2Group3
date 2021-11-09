namespace Dataservices.IRepositories
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using CRUDRepository;
    using Domain.User;

    public interface IUserRepository : IMutableRepository<CUser>
    {

    }
}