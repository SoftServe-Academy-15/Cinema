using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Interfaces.Services;
using DataAccess.Interfaces;
using DataAccess.Entities.MovieInformation;
using System.Drawing;
using System.Numerics;
using DataAccess.Entities.Specifications;

namespace BusinessLogic.Services
{
    internal class MovieService : IMovieService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Movie> _movieRepository;
        private readonly IRepository<Genre> _genreRepository;
        public MovieService(IMapper mapper,
                            IRepository<Movie> movieRepository,
                            IRepository<Genre> genreRepository)
        {
            _mapper = mapper;
            _movieRepository = movieRepository;
            _genreRepository = genreRepository;
        }
        public void AddMovie(MovieDTO movieDTO)
        {
            var movie = _mapper.Map<Movie>(movieDTO);
            _movieRepository.Insert(movie);
            _movieRepository.Save();
        }

        public void DeleteMovie(int movieId)
        {
            _movieRepository.Delete(movieId);
            _movieRepository.Save();
        }

        public void UpdateMovie(MovieDTO movieDTO)
        {
            var movie = _mapper.Map<Movie>(movieDTO);
            _movieRepository.Update(movie);
            _movieRepository.Save();
        }

        public List<GenreDTO> GetAllGenres(int id)
        {
            var result = _genreRepository.GetAll();
            return _mapper.Map<List<GenreDTO>>(result);
        }

        public List<MovieDTO> GetAllMovies()
        {
            var result = _movieRepository.GetListBySpec(new MovieSpecification.All());
            return _mapper.Map<List<MovieDTO>>(result);
        }

        public MovieDTO GetMovieById(int id)
        {
            var result = _movieRepository.GetFirstBySpec(new MovieSpecification.ById(id));
            return _mapper.Map<MovieDTO>(result);
        }
        public List<MovieDTO> GetMoviesByIds(int[] ids)
        {
            var result = _movieRepository.GetListBySpec(new MovieSpecification.ByIds(ids));
            return _mapper.Map<List<MovieDTO>>(result);
        }
        public List<MovieDTO> GetMoviesByGenres(List<GenreDTO> genreDTOs) 
        {
            List<string> genres = genreDTOs.Select(g => g.GenreName).ToList();
            var result = _movieRepository.GetListBySpec(new MovieSpecification.ByGenres(genres));
            return _mapper.Map<List<MovieDTO>>(result);
        }
        public List<MovieDTO> GetMoviesByActors(List<ActorDTO> ActorDTOs)
        {
            List<int> actorsIds = ActorDTOs.Select(g => g.Id).ToList();
            var result = _movieRepository.GetListBySpec(new MovieSpecification.ByActors(actorsIds));
            return _mapper.Map<List<MovieDTO>>(result);
        }
        public List<MovieDTO> GetMoviesByName(string name)
        {
            var result = _movieRepository.GetListBySpec(new MovieSpecification.ByName(name));
            return _mapper.Map<List<MovieDTO>>(result);
        }
    }
}
