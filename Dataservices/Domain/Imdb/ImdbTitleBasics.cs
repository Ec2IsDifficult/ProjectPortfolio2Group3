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
        public int? StartYear { get; set; }
        public int? EndYear { get; set; }
        //gives null error in titlescontroller
        //public int RunTime { get; set; }
        public string Poster { get; set; }
        public string Plot { get; set; }
        public string Awards { get; set; }
        
        public ImdbTitleRatings Rating { get; set; }
        
        public IList<ImdbTitleAkas> AkasList { get; set; }
        public IList<CReviews> Reviews { get; set; }
        public IList<CBookmarkTitle> BeenBookmarkedBy { get; set; }
        public IList<ImdbCast> Cast { get; set; }
        public IList<ImdbCrew> Crew { get; set; }
        public IList<ImdbGenre> Genres { get; set; }
        public IList<ImdbKnownFor> KnownFors { get; set; }
        public IList<ImdbTitleEpisode> Episodes { get; set; }
        //public ImdbTitleEpisode EpisodeOf { get; set; }

    }
}