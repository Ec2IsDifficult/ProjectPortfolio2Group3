using AutoMapper;
using Dataservices.Domain.User;
using WebServiceAPI.Models.UserViews;

namespace WebServiceAPI.Models.UserProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<CUser, UserViewModel>();
            CreateMap<CreateUserViewModel, CUser>();
        }
    }
}