namespace Dataservices.Repository
{
    using System.Collections.Generic;
    using System.Linq;
    using Domain;
    using IRepositories;
    using CRUDRepository;
    using Domain.Imdb;
    using Microsoft.EntityFrameworkCore;

    public class EpisodeRepository : ImmutableRepository<ImdbTitleEpisode>, IEpisodeRepository
    {
        public EpisodeRepository(ImdbContext context) : base(context)
        {
            
        }

        public IEnumerable<ImdbTitleEpisode> GetEpisodeCast(string id)
        {
            var ctx = new ImdbContext();
            return ctx.ImdbTitleEpisode.Include(x => x.MainTitle).ThenInclude(x => x.Cast).Where(x => x.EpisodeTconst == id);
        }

        public IEnumerable<ImdbTitleEpisode> GetEpisodeCrew(string id)
        {
            var ctx = new ImdbContext();
            return ctx.ImdbTitleEpisode.Include(x => x.MainTitle).ThenInclude(x => x.Crew).Where(x => x.EpisodeTconst == id);
        }

        public IEnumerable<ImdbTitleEpisode> GetEpisodeRating(string id)
        {
            var ctx = new ImdbContext();
            return ctx.ImdbTitleEpisode.Include(x => x.MainTitle).ThenInclude(x => x.Rating).Where(x => x.EpisodeTconst == id);
        }
        

        public ImdbContext ImdbContext{ get {return Context as ImdbContext;} }
    }
}