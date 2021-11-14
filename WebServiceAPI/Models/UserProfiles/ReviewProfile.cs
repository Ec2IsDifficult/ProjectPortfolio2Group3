using AutoMapper;
using Dataservices.Domain;
using Dataservices.Domain.User;
using WebServiceAPI.Models.PersonViews;
using WebServiceAPI.Models.UserViews;

namespace WebServiceAPI.Models.UserProfiles
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<CUser, ReviewViewModel>();
            CreateMap<CreateReviewViewModel, CUser>();
        }
    }
}