using AutoMapper;
using Dataservices.Domain;
using WebServiceAPI.Models.PersonViews;

namespace WebServiceAPI.Models.PersonProfiles
{
    public class ProfessionsProfile : Profile
    {
        public ProfessionsProfile()
            {
                CreateMap<ImdbPrimeProfession, ProfessionsViewModel>();
                CreateMap<CreateProfessionsViewModel, ImdbPrimeProfession>();
            }
    }
}