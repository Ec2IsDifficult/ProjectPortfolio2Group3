namespace Dataservices.IRepositories
{
    using System.Collections.Generic;
    using CRUDRepository;
    using Domain;

    public interface ITitleRepository : IRepository<ImdbTitleBasics>
    {
        IEnumerable<ImdbTitleBasics> GetTitlesByYear(int year);
        ImdbTitleBasics GetCast(string id);
        ImdbTitleBasics GetCrew(string id);
        ImdbTitleRatings GetRating(string id);
        IEnumerable<ImdbTitleBasics> GetSeasons(string id);
        IEnumerable<ImdbTitleBasics> GetTitlesBetween(int startYear, int endYear);
        ImdbTitleBasics GetEpisodes(string id);
    }
}