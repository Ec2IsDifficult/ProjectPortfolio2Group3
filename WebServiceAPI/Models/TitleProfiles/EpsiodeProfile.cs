using AutoMapper;
using Dataservices.Domain;

namespace WebServiceAPI.Models.Profiles
{
    using Dataservices.Domain.Imdb;

    public class EpsiodeProfile : Profile
    {
        public EpsiodeProfile()
        {
            CreateMap<ImdbTitleBasics, EpisodeViewModel>();
            CreateMap<CreateEpisodeViewModel, ImdbTitleBasics>();
        }
    }
}