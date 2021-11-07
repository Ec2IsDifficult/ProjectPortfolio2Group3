using System.Collections.Generic;
using Dataservices.CRUDRepository;
using Dataservices.Domain;

namespace Dataservices.IRepositories
{
    public interface IPersonRepository : IRepository<ImdbNameBasics>
    {
        IEnumerable<ImdbKnownFor> GetKnowFor(string id);
        //This should be changed to an object called CoActors or just an IEnumerable of CoActors
        IEnumerable<ImdbNameBasics> CoActors(string id);
        IEnumerable<ImdbNameBasics> GetPersonsByYear(int year);
    }
}