using System.Collections.Generic;
using Dataservices.Domain;

namespace WebServiceAPI.Models
{
    using Dataservices.Domain.Imdb;

    public class EpisodeViewModel
    {
        public string Url { get; set; }
        public IList<ImdbTitleEpisode> Episodes { get; set; }
    }

    public class CreateEpisodeViewModel
    {
        public IList<ImdbTitleEpisode> Episodes { get; set; }
    }
}