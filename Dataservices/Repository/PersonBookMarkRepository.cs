namespace Dataservices.Repository
{
    using CRUDRepository;
    using Domain.User;
    using Microsoft.EntityFrameworkCore;

    public class PersonBookMarkRepository : MutableRepository<CBookmarkPerson> 
    {
        public PersonBookMarkRepository(DbContext context) : base(context)
        {
        }
    }
}