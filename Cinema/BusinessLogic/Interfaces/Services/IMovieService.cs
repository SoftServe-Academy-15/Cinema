using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.DTOs;

namespace BusinessLogic.Interfaces.Services
{
    public interface IMovieService
    {
        void AddMovie(MovieDTO movieDTO);
        void UpdateMovie(MovieDTO movieDTO);
        void DeleteMovie(int movieId);
        MovieDTO GetMovieById(int id);
        List<MovieDTO> GetMoviesByIds(int[] ids);
        List<MovieDTO> GetMoviesByGenres(List<GenreDTO> genreDTOs);
        List<MovieDTO> GetMoviesByActors(List<ActorDTO> ActorDTOs);
        List<GenreDTO> GetAllGenres(int id);
        List<MovieDTO> GetAllMovies();
        List<MovieDTO> GetMoviesByName(string name);
    }
}
