namespace WebServiceAPI.Models.PersonViews
{
    public class CoActorsViewModel
    {
        public string Url { get; set; }
        public string CoActorNconst { get; set; }
        public string CoActorName { get; set; }
        public string ActCount { get; set; }
    }

    public class CreateCoActorsViewModel
    {
        public string CoActorNconst { get; set; }
        public string CoActorName { get; set; }
        public string ActCount { get; set; }
    }
}