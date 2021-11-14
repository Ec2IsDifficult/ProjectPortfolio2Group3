using AutoMapper;
using Dataservices.Domain.User;
using WebServiceAPI.Models.UserViews;

namespace WebServiceAPI.Models.UserProfiles
{
    public class SearchHistoryProfile : Profile
    {
        public SearchHistoryProfile()
        {
            CreateMap<CUser, SearchHistoryViewModel>();
            CreateMap<CreateSearchHistoryViewModel, CUser>();
        }
    }
}