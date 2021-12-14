namespace Dataservices.Repository
{
    using System;
    using CRUDRepository;
    using Domain.User;
    using Microsoft.EntityFrameworkCore;

    public class PersonBookMarkRepository : MutableRepository<CBookmarkPerson> 
    {
        public PersonBookMarkRepository(Func<DbContext> contextFactory) : base(contextFactory)
        {
        }
    }
}