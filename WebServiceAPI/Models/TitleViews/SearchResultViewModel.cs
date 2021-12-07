namespace WebServiceAPI.Models
{
    public class SearchResultViewModel
    {
        public string Url { get; set; }
        public string BestTconst { get; set; }
        public int Rank { get; set; }
        public string BestTitle { get; set; }
    }
    
    public class CreateSearchResultViewModel
    {
        public string BestTconst { get; set; }
        public int Rank { get; set; }
        public string BestTitle { get; set; }
    }
}