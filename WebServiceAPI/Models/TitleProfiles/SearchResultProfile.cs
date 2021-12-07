namespace WebServiceAPI.Models.Profiles
{
    using AutoMapper;
    using Dataservices.Domain.FunctionObjects;

    public class SearchResultProfile : Profile
    {
        public SearchResultProfile()
        {
            CreateMap<BestMatchSearch, SearchResultViewModel>();
            CreateMap<CreateSearchResultViewModel, BestMatchSearch>();
        }
    }
    
}