using System.Collections.Generic;
using System.Linq;
using Dataservices.CRUDRepository;
using Dataservices.Domain;
using Dataservices.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Dataservices.Repository
{
    //Will inherit all functionality from the Repository class and a functionality contract from its specific interface
    public class PersonRepository : Repository<ImdbNameBasics>, IPersonRepository
    {
        // : base(context) to access the constructor from the parent class
        public PersonRepository(ImdbContext context) : base(context)
        {
            
        }

        public IEnumerable<ImdbKnownFor> GetKnowFor(string id)
        {
            return ImdbContext.ImdbKnownFor.Where(x => x.Nconst == id);
        }
        
        //TODO: Either an object has to be created based on a new entity in the database, or some query has to be made to reach this result. This is basicly a recursive relationship ImdbNameBasics has with itself
        public IEnumerable<ImdbNameBasics> CoActors(string id)
        {
            throw new System.NotImplementedException();
        }

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