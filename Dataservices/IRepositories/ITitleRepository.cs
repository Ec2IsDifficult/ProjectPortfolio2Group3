namespace Dataservices.IRepositories
{
    using System.Collections.Generic;
    using CRUDRepository;
    using Domain;

    public interface ITitleRepository : IRepository<ImdbTitleBasics>
    {
        IEnumerable<ImdbTitleBasics> GetTitlesByYear(int year);
        IEnumerable<ImdbTitleBasics> GetCast(string id);
        IEnumerable<ImdbTitleBasics> GetCrew(string id);
        IEnumerable<ImdbTitleRatings> GetRating(string id);
        IEnumerable<ImdbTitleBasics> GetSeasons(string id);
        IEnumerable<ImdbTitleBasics> GetTitlesBetween(int startYear, int endYear);
        IEnumerable<ImdbTitleBasics> GetEpisodes(string id);
    }
}