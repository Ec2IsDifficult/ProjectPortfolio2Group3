namespace Dataservices.Repository
{
    using System;
    using CRUDRepository;
    using Domain.User;
    using Microsoft.EntityFrameworkCore;

    public class TitleBookmarkRepository : MutableRepository<CBookmarkTitle>
    {
        public TitleBookmarkRepository(Func<DbContext> contextFactory) : base(contextFactory)
        {
        }
    }
}