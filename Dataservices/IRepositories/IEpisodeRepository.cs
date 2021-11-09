namespace Dataservices.IRepositories
{
    using System.Collections.Generic;
    using Domain;

    public interface IEpisodeRepository
    {
        IEnumerable<ImdbTitleBasics> GetEpisodeCast(string id);
        IEnumerable<ImdbTitleBasics> GetEpisodeCrew(string id);
        IEnumerable<ImdbTitleBasics> GetEpisodeRating(string id);

    }
}