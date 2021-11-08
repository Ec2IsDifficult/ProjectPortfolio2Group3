namespace Dataservices.Repository
{
    using System.Collections.Generic;
    using System.Linq;
    using Domain;
    using IRepositories;
    using CRUDRepository;
    using Microsoft.EntityFrameworkCore;

    public class TitleRepository : Repository<ImdbTitleBasics>, ITitleRepository
    {
        public TitleRepository(ImdbContext context) :base(context)
        {
            
        }
        public IEnumerable<ImdbTitleBasics> GetTitlesByYear(int year)
        {
            return ImdbContext.ImdbTitleBasics.Where(x => x.StartYear == year);
        }

        public IEnumerable<ImdbTitleBasics> GetCast(string id)
        {
            return ImdbContext.ImdbTitleBasics.Include(x => x.Casts).Where(x => x.Tconst == id);
        }

        public IEnumerable<ImdbTitleBasics> GetCrew(string id)
        {
            return ImdbContext.ImdbTitleBasics.Include(x => x.Casts).Where(x => x.Tconst == id);
        }

        public IEnumerable<ImdbTitleRatings> GetRating(string id)
        {
            return ImdbContext.ImdbTitleRatings.Where(x => x.Tconst == id);
        }

        public IEnumerable<ImdbTitleBasics> GetSeasons(string id)
        {
            //TODO: Probably should be created using an SQL function
            return ImdbContext.ImdbTitleBasics.Include(x => x.Episodes);
        }

        public IEnumerable<ImdbTitleBasics> GetTitlesBetween(int startYear, int endYear)
        {
            //TODO: Probably should be created using an SQL function
            return ImdbContext.ImdbTitleBasics.Where(x => x.StartYear >= startYear && x.StartYear <= endYear);
        }

        public IEnumerable<ImdbTitleBasics> GetEpisodes(string id)
        {
            //TODO: Has to be made so that it checks whether it is null before it requests episodes
            return ImdbContext.ImdbTitleBasics.Include(x => x.Episodes);
        }
        
        public ImdbContext ImdbContext
        {
            get { return Context as ImdbContext; }
        }
    }
}