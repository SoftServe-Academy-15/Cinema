using AutoMapper;
using BusinessLogic.DTOs;
using DataAccess.Entities;
using DataAccess.Entities.MovieInformation;

namespace BusinessLogic.Helpers
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Genre, GenreDTO>();
            CreateMap<RoleDTO, MovieActor>().ReverseMap();
            CreateMap<CinemaHall, CinemaHallDTO>().ReverseMap();
            CreateMap<ActorDTO, Actor>()
                .ForMember(dest => dest.Movies, act => act.MapFrom(src => src.Roles))
                .ReverseMap();
            CreateMap<GenreDTO, GenreMovie>()
            .ForMember(dest => dest.GenreId, act => act.MapFrom(src => src.Id))
            .ReverseMap();
            CreateMap<MovieDTO, Movie>()
                    .ForMember(dest => dest.Actors, act => act.MapFrom(src => src.Roles))
                    .ReverseMap();
        }
    }
}