namespace Dataservices.Repository
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Linq;
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
        public IEnumerable<ImdbTitleBasics> GetTitlesByYear(int year)
        {
            return ImdbContext.ImdbTitleBasics.Where(x => x.StartYear == year);
        }

        public ImdbTitleBasics GetCast(string id)
        {
            return ImdbContext.ImdbTitleBasics.Include(x => x.Cast).FirstOrDefault(x => x.Tconst == id);
        }

        public ImdbTitleBasics GetCrew(string id)
        {
            return ImdbContext.ImdbTitleBasics.Include(x => x.Crew).FirstOrDefault(x => x.Tconst == id);
        }

        public ImdbTitleRatings GetRating(string id)
        {
            return ImdbContext.ImdbTitleRatings.FirstOrDefault(x => x.Tconst == id);
        }

        
        public IEnumerable<ImdbTitleBasics> GetSeasons(string id)
        {
            return ImdbContext.ImdbTitleBasics.Include(x => x.Episodes);
        }

        public IEnumerable<ImdbTitleBasics> GetTitlesBetween(int startYear, int endYear)
        {
            return ImdbContext.ImdbTitleBasics.Where(x => x.StartYear >= startYear && x.StartYear <= endYear);
        }

        public ImdbTitleBasics GetEpisodes(string id)
        {
            return ImdbContext.ImdbTitleBasics.Include(x => x.Episodes).FirstOrDefault(x => x.Tconst == id);
        }

        public IEnumerable<ImdbTitleBasics> GetAdultMovies()
        {
            return ImdbContext.ImdbTitleBasics.Where(x => x.IsAdult == true);
        }

        public IQueryable<MoviesByGenre> GetMoviesByGenre(string name)
        {
            return ImdbContext.MoviesByGenres.FromSqlInterpolated($"select * from similar_movies_genre({name})");
        }

        public ImdbContext ImdbContext
        {
            get { return Context as ImdbContext; }
        }
    }
}