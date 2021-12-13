namespace Dataservices.IRepositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CRUDRepository;
    using Domain;
    using Domain.FunctionObjects;
    using Domain.Imdb;

    public interface ITitleRepository : IIMutableRepository<ImdbTitleBasics>
    {

        IEnumerable<ImdbTitleBasics> GetTitlesByYear(int year, PaginationFilter paginationFilter);
        ImdbTitleBasics GetCast(string id);
        ImdbTitleBasics GetCrew(string id);
        ImdbTitleRatings GetRating(string id);
        IEnumerable<ImdbTitleBasics> GetSeasons(string id);
        IEnumerable<ImdbTitleBasics> GetTitlesBetween(int startYear, int endYear);
        ImdbTitleBasics GetEpisodes(string id);
        IEnumerable<ImdbTitleBasics> GetAdultMovies();
        IQueryable<MoviesByGenre> GetMoviesByGenre(string name, PaginationFilter paginationFilter);

        IEnumerable<ImdbTitleBasics> GetRandomTitles(int amount, float lowestRating);
        //IEnumerable<ImdbTitleBasics> GetTitleSeasons(string id);

        IQueryable<BestMatchSearch> SearchBestMatch(string[] keyWords);

        IEnumerable<Genres> GetAllGenres(PaginationFilter paginationFilter = null);
        public int NumberOfGenres();
        }
}