using System.Collections.Generic;
using Dataservices.CRUDRepository;
using Dataservices.Domain;

namespace Dataservices.IRepositories
{
    using System.Linq;
    using Domain.FunctionObjects;

    public interface IPersonRepository : IIMutableRepository<ImdbNameBasics>
    {
        IEnumerable<ImdbKnownFor> GetKnowFor(string id);
        IEnumerable<CoActors> CoActors(string id);
        IEnumerable<ImdbNameBasics> GetPersonsByYear(int year);

        IEnumerable<ImdbNameBasics> GetRandomPeople(int amount);
    }
}