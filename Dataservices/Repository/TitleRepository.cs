namespace Dataservices.Repository
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Linq;
    using System.Threading.Tasks;
    using Domain;
    using IRepositories;
    using CRUDRepository;
    using Domain.FunctionObjects;
    using Domain.Imdb;
    using Microsoft.EntityFrameworkCore;

    public class TitleRepository : ImmutableRepository<ImdbTitleBasics>, ITitleRepository
    {
        public TitleRepository(ImdbContext context) :base(context)
        {
            
        }
        //in titles controller
        public IEnumerable<ImdbTitleBasics> GetTitlesByYear(int year)
        {            
            var ctx = new ImdbContext();
            return ctx.ImdbTitleBasics.Where(x => x.StartYear == year);
        }
        //in titles controller
        public ImdbTitleBasics GetCast(string id)
        {
            var ctx = new ImdbContext();
            return ctx.ImdbTitleBasics.Include(x => x.Cast).FirstOrDefault(x => x.Tconst == id);
        }
        //in titles controller
        public ImdbTitleBasics GetCrew(string id)
        {
            var ctx = new ImdbContext();
            return ctx.ImdbTitleBasics.Include(x => x.Crew).FirstOrDefault(x => x.Tconst == id);
        }
        //in titles controller
        public ImdbTitleRatings GetRating(string id)
        {
            var ctx = new ImdbContext();
            return ctx.ImdbTitleRatings.FirstOrDefault(x => x.Tconst == id);
        }

        //same as GetEpisodes ?
        public IEnumerable<ImdbTitleBasics> GetSeasons(string id)
        {
            var ctx = new ImdbContext();
            return ctx.ImdbTitleBasics.Include(x => x.Episodes);
        }

        //in titles controller
        public IEnumerable<ImdbTitleBasics> GetTitlesBetween(int startYear, int endYear)
        {
            var ctx = new ImdbContext();
            return ctx.ImdbTitleBasics.Where(x => x.StartYear >= startYear && x.StartYear <= endYear);
        }
        //in titles controller
        public ImdbTitleBasics GetEpisodes(string id)
        {
            var ctx = new ImdbContext();
            return ctx.ImdbTitleBasics.Include(x => x.Episodes).FirstOrDefault(x => x.Tconst == id);
        }

        //in titles controller
        public IEnumerable<ImdbTitleBasics> GetAdultMovies()
        {
            var ctx = new ImdbContext();
            return ctx.ImdbTitleBasics.Where(x => x.IsAdult == true);
        }

        //in titles controller
        public IQueryable<MoviesByGenre> GetMoviesByGenre(string name)
        {
            var ctx = new ImdbContext();
            return ctx.MoviesByGenres.FromSqlInterpolated($"select * from similar_movies_genre({name})");
        }

        //
        public IEnumerable<ImdbTitleBasics> GetRandomTitles(int amount, float lowestRating)
        {
            var ctx = new ImdbContext();
            return ctx.ImdbTitleBasics.FromSqlInterpolated(
                $"select * from getRandomTitles({amount},{lowestRating})");
        }

        public IQueryable<BestMatchSearch> SearchBestMatch(string[] keyWords)
        {
            var ctx = new ImdbContext();
            return ctx.BestMatchSearches.FromSqlInterpolated($"select * from best_match_querying({keyWords})");
        }

        public ImdbContext ImdbContext
        {
            get { return Context as ImdbContext; }
        }
    }
}