namespace Dataservices.IRepositories
{
    using System.Collections.Generic;
    using CRUDRepository;
    using Domain;

    public interface IEpisodeRepository : IRepository<ImdbTitleEpisode>
    {
        IEnumerable<ImdbTitleEpisode> GetEpisodeCast(string id);
        IEnumerable<ImdbTitleEpisode> GetEpisodeCrew(string id);
        IEnumerable<ImdbTitleEpisode> GetEpisodeRating(string id);

    }
}