namespace WebServiceAPI.Models
{
    public class GenreViewModel
    {
        public string Url { get; set; }
        public string Tconst { get; set; }
        public int GenreCount { get; set; }
    }

    public class CreateGenreViewModel
    {
        public string Tconst { get; set; }
        public int GenreCount { get; set; }
    }
}