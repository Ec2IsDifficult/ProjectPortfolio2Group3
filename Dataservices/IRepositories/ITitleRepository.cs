namespace Dataservices.IRepositories
{
    using System.Collections.Generic;
    using System.Linq;
    using CRUDRepository;
    using Domain;
    using Domain.FunctionObjects;
    using Domain.Imdb;

    public interface ITitleRepository : IIMutableRepository<ImdbTitleBasics>

    {
    IEnumerable<ImdbTitleBasics> GetTitlesByYear(int year);
    ImdbTitleBasics GetCast(string id);
    ImdbTitleBasics GetCrew(string id);
    ImdbTitleRatings GetRating(string id);
    IEnumerable<ImdbTitleBasics> GetSeasons(string id);
    IEnumerable<ImdbTitleBasics> GetTitlesBetween(int startYear, int endYear);
    ImdbTitleBasics GetEpisodes(string id);
    IEnumerable<ImdbTitleBasics> GetAdultMovies();
    IQueryable<MoviesByGenre> GetMoviesByGenre(string name);

    IQueryable<ImdbTitleBasics> GetRandomTitles(int amount, float lowestRating);
    //IEnumerable<ImdbTitleBasics> GetTitleSeasons(string id);
    }
}