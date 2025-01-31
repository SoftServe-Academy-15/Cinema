﻿using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Interfaces.Services;
using DataAccess.Interfaces;
using DataAccess.Entities.MovieInformation;
using System.Drawing;
using System.Numerics;
using DataAccess.Entities.Specifications;
using BusinessLogic.Services.Base;

namespace BusinessLogic.Services
{
    internal class MovieService : BaseServiceClass<Movie, MovieDTO>, IMovieService
    {
        public MovieService(IMapper mapper, IRepository<Movie> repository) : base(mapper, repository)
        {
        }

        public MovieDTO GetMovieById(int id)
        {
            var result = Repository.GetFirstBySpec(new MovieSpecification.ById(id));
            return Mapper.Map<MovieDTO>(result);
        }
        public List<MovieDTO> GetMoviesByIds(int[] ids)
        {
            var result = Repository.GetListBySpec(new MovieSpecification.ByIds(ids));
            return Mapper.Map<List<MovieDTO>>(result);
        }
        public List<MovieDTO> GetMoviesByGenres(List<GenreDTO> genreDTOs) 
        {
            List<string> genres = genreDTOs.Select(g => g.GenreName).ToList();
            var result = Repository.GetListBySpec(new MovieSpecification.ByGenres(genres));
            return Mapper.Map<List<MovieDTO>>(result);
        }
        public List<MovieDTO> GetMoviesByActors(List<ActorDTO> ActorDTOs)
        {
            List<int> actorsIds = ActorDTOs.Select(g => g.Id).ToList();
            var result = Repository.GetListBySpec(new MovieSpecification.ByActors(actorsIds));
            return Mapper.Map<List<MovieDTO>>(result);
        }
        public List<MovieDTO> GetMoviesByName(string name)
        {
            var result = Repository.GetListBySpec(new MovieSpecification.ByName(name));
            return Mapper.Map<List<MovieDTO>>(result);
        }
    }
}
