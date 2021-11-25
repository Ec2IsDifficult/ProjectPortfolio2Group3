namespace WebServiceAPI.Models
{
    public class TitlesViewModel
    {
        public string Url { get; set; }
        public string Tconst { get; set; }
        public string PrimaryTitle { get; set; }
        public string TitleType { get; set; }
        //public bool IsAdult { get; set; }
        public int? StartYear { get; set; }
        public int? EndYear { get; set; }
        //runtime column is null
        //public int RunTime { get; set; }
        public string Poster { get; set; }
        public string Plot { get; set; }
        public string Awards { get; set; }
    }

    public class CreateTitlesViewModel
    {
        public string Tconst { get; set; }
        public string PrimaryTitle { get; set; }
        public string TitleType { get; set; }
        //public bool IsAdult { get; set; }
        public int? StartYear { get; set; }
        public int? EndYear { get; set; }
        //column runtime is null error
        //public int RunTime { get; set; }
        public string Poster { get; set; }
        public string Plot { get; set; }
        public string Awards { get; set; }
    }
}