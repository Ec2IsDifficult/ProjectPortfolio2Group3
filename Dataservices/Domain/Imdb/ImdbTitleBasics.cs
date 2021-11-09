using System.Collections.Generic;
using Dataservices.Domain.User;

namespace Dataservices.Domain
{
    public class ImdbTitleBasics
    {
        public string Tconst { get; set; }
        public string PrimaryTitle { get; set; }
        public string TitleType { get; set; }
        public bool IsAdult { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public int RunTime { get; set; }
        public string Poster { get; set; }
        public string Plot { get; set; }
        public string Awards { get; set; }
        
        public ImdbTitleRatings Rating { get; set; }
        
        public List<ImdbTitleAkas> AkasList { get; set; }
        public List<CReviews> Reviews { get; set; }
        public List<CBookmarkTitle> BeenBookmarkedBy { get; set; }
        public List<ImdbCast> Cast { get; set; }
        public List<ImdbCrew> Crew { get; set; }
        public List<ImdbGenre> Genres { get; set; }
        public List<ImdbKnownFor> KnownFors { get; set; }
        public List<ImdbTitleEpisode> Episodes { get; set; }
        //public ImdbTitleEpisode EpisodeOf { get; set; }

    }
}