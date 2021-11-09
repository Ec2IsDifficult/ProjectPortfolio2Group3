namespace Dataservices.Repository
{
    using System.Collections.Generic;
    using System.Linq;
    using Domain;
    using IRepositories;
    using CRUDRepository;
    using Domain.User;
    using Microsoft.EntityFrameworkCore;

    public class UserRepository : Repository<CUser>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
            
        }
    }
}