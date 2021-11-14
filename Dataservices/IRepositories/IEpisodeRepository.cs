namespace Dataservices.IRepositories
{
    using System.Collections.Generic;
    using Domain;
    using Domain.Imdb;

    public interface IEpisodeRepository
    {
        IEnumerable<ImdbTitleEpisode> GetEpisodeCast(string id);
        IEnumerable<ImdbTitleEpisode> GetEpisodeCrew(string id);
        IEnumerable<ImdbTitleEpisode> GetEpisodeRating(string id);
    }
}