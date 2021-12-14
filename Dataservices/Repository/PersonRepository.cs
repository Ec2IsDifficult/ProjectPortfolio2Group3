using System.Collections.Generic;
using System.Linq;
using Dataservices.CRUDRepository;
using Dataservices.Domain;
using Dataservices.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Dataservices.Repository
{
    using System;
    using System.Threading.Tasks;
    using Domain.FunctionObjects;

    //Will inherit all functionality from the Repository class and a functionality contract from its specific interface
    public class PersonRepository : ImmutableRepository<ImdbNameBasics>, IPersonRepository
    {
        
        public PersonRepository(Func<DbContext> contextFactory) : base(contextFactory)
        {
        }

        //in person controller
        public IEnumerable<ImdbKnownFor> GetKnowFor(string id)
        {
            var ctx = new ImdbContext();
            return ctx.ImdbKnownFor.Where(x => x.Nconst == id).Include(x => x.Name).Include(x=>x.Title);
        }
        // in person controller
        public IEnumerable<CoActors> CoActors(string id)
        {
            var ctx = new ImdbContext();
            return ctx.CoActors.FromSqlInterpolated($"select * from find_co_actors({id})");
        }   
        
        //in person controller
        public IEnumerable<ImdbNameBasics> GetPersonsByYear(int year)
        {
            var ctx = new ImdbContext();
            return ctx.ImdbNameBasics.Where(x => x.BirthYear == year);
        }

        public IEnumerable<ImdbNameBasics> GetRandomPeople(int amount)
        {
            var ctx = new ImdbContext();
            return ctx.ImdbNameBasics.FromSqlInterpolated($"select * from getRandomPeople({amount})");
        }
    }
}