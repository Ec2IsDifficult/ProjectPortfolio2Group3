namespace Dataservices.Repository
{
    using System.Collections.Generic;
    using System.Linq;
    using Domain;
    using IRepositories;
    using CRUDRepository;
    using Microsoft.EntityFrameworkCore;

    public class EpisodeRepository : ImmutableRepository<ImdbTitleBasics>, IEpisodeRepository
    {
        public EpisodeRepository(ImdbContext context) : base(context)
        {
        }

        public IEnumerable<ImdbTitleBasics> GetEpisodeCast(string id)
        {
            //TODO: There has to be a smarter way to check if the episode is actually an episode, than to check if the episodeOf attr. is null or not...
            //return ImdbContext.ImdbTitleBasics.Include(x => x.Cast).Where(x => x.Tconst == id && x.EpisodeOf != null);
            return null;
        }

        public IEnumerable<ImdbTitleBasics> GetEpisodeCrew(string id)
        {
            //TODO: There has to be a smarter way to check if the episode is actually an episode, than to check if the episodeOf attr. is null or not...
            //return ImdbContext.ImdbTitleBasics.Include(x => x.Crew).Where(x => x.Tconst == id && x.EpisodeOf != null);
            return null;
        }

        public IEnumerable<ImdbTitleBasics> GetEpisodeRating(string id)
        {
            //return ImdbContext.ImdbTitleBasics.Include(x => x.Rating).Where(x => x.Tconst == id && x.EpisodeOf != null);
            return null;
        }
        
        public ImdbContext ImdbContext{ get {return Context as ImdbContext;} }
    }
}