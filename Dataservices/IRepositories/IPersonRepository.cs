using System.Collections.Generic;
using Dataservices.CRUDRepository;
using Dataservices.Domain;

namespace Dataservices.IRepositories
{
    using Domain.FunctionObjects;

    public interface IPersonRepository : IIMutableRepository<ImdbNameBasics>
    {
        IEnumerable<ImdbKnownFor> GetKnowFor(string id);
        IEnumerable<CoActors> CoActors(string id);
        IEnumerable<ImdbNameBasics> GetPersonsByYear(int year);
    }
}