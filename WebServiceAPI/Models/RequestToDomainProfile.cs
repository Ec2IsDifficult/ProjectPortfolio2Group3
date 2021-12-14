namespace WebServiceAPI.Models
{
    using AutoMapper;
    using Dataservices.Domain;

    public class RequestToDomainView : Profile
    {
        public RequestToDomainView()
        {
            CreateMap<PaginationQuery, PaginationFilter>();
        }
    }
}