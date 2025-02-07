using AutoMapper;
using BusinessLogic.DTOs;
using DataAccess.Entities.MovieInformation;

namespace BusinessLogic.Helpers
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<GenreDTO, Genre>().ReverseMap();
            CreateMap<RoleDTO, MovieActor>().ReverseMap();
            CreateMap<ActorDTO, Actor>().ReverseMap()
                .ForMember(dest => dest.Roles, act => act.MapFrom(src => src.Movies));
            CreateMap<MovieDTO, Movie>().ReverseMap();
        }
    }
}