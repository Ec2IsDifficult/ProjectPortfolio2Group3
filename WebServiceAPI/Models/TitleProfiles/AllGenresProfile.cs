namespace WebServiceAPI.Models.Profiles
{
    using System.Collections.Generic;
    using AutoMapper;
    using Dataservices.Domain.FunctionObjects;
    using Dataservices.Domain.Imdb;

    public class AllGenresProfile : Profile
    {
        public AllGenresProfile() {
            CreateMap<Genres, AllGenresViewModel>();
            CreateMap<CreateGenreViewModel, Genres>();
        }

    }
}