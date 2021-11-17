using AutoMapper;
using Dataservices.Domain.FunctionObjects;
using Dataservices.Domain.Imdb;

namespace WebServiceAPI.Models.Profiles
{
    public class GenreProfile : Profile
    {
            public GenreProfile()
            {
                CreateMap<MoviesByGenre, GenreViewModel>();
                CreateMap<CreateGenreViewModel, MoviesByGenre>();
            }
    }
}