using AutoMapper;
using Dataservices.Domain;

namespace WebServiceAPI.Models.Profiles
{
    using Dataservices.Domain.Imdb;

    public class RatingProfile : Profile
    {
        public RatingProfile()
        {
            CreateMap<ImdbTitleRatings, RatingViewModel>();
            CreateMap<CreateRatingViewModel, ImdbTitleRatings>();
        }
    }
}