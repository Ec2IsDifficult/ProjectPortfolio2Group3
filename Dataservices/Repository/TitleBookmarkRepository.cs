namespace Dataservices.Repository
{
    using CRUDRepository;
    using Domain.User;
    using Microsoft.EntityFrameworkCore;

    public class TitleBookmarkRepository : MutableRepository<CBookmarkTitle>
    {
        public TitleBookmarkRepository(DbContext context) : base(context)
        {
        }
    }
}