using AutoMapper;
using Dataservices.Domain.User;

namespace WebServiceAPI.Models.UserProfiles
{
    public class RatingProfile : Profile
    {
        public RatingProfile()
        {
            CreateMap<CUser, RatingViewModel>();
            CreateMap<CreateRatingViewModel, CUser>();
        }
    }
}