namespace Dataservices.Repository
{
    using Domain.User;
    using IRepositories;
    using CRUDRepository;
    using Microsoft.EntityFrameworkCore;

    public class UserRepository : Repository<CUser>, IUserRepository

    {
        public UserRepository(DbContext context) : base(context)
        {
            
        }
    }
}