using AutoMapper;
using Dataservices.Domain;

namespace WebServiceAPI.Models.Profiles
{
    public class EpsiodeProfile : Profile
    {
        public EpsiodeProfile()
        {
            CreateMap<ImdbTitleBasics, EpisodeViewModel>();
            CreateMap<CreateEpisodeViewModel, ImdbTitleBasics>();
        }
    }
}