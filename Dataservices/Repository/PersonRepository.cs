using System.Collections.Generic;
using System.Linq;
using Dataservices.CRUDRepository;
using Dataservices.Domain;
using Dataservices.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Dataservices.Repository
{
    using Domain.FunctionObjects;

    //Will inherit all functionality from the Repository class and a functionality contract from its specific interface
    public class PersonRepository : ImmutableRepository<ImdbNameBasics>, IPersonRepository
    {
        // : base(context) to access the constructor from the parent class
        public PersonRepository(ImdbContext context) : base(context)
        {
            
        }
        //in person controller
        public IEnumerable<ImdbKnownFor> GetKnowFor(string id)
        {
            return ImdbContext.ImdbKnownFor.Where(x => x.Nconst == id);
        }
        // in person controller
        public IEnumerable<CoActors> CoActors(string name)
        {
            return ImdbContext.CoActors.FromSqlInterpolated($"select * from find_co_actors({name})");
        }   
        
        //in person controller
        public IEnumerable<ImdbNameBasics> GetPersonsByYear(int year)
        {
            return ImdbContext.ImdbNameBasics.Where(x => x.BirthYear == year);
        }
        
        //To cast the generic DbContext inherited from the parent class into an ImdbContext
        public ImdbContext ImdbContext
        {
            get { return Context as ImdbContext; }
        }
    }
}