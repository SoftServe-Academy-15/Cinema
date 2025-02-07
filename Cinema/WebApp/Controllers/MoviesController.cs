using BusinessLogic.DTOs;
using BusinessLogic.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IGenreService _genreService;
        private readonly IActorService _actorService;
        //GET: /Movies/Index or /Movies
        public MoviesController(IMovieService movieService, IGenreService genreService, IActorService actorService)
        {
            _movieService = movieService;
            _genreService = genreService;
            _actorService = actorService;
        }
        public IActionResult Index()
        {
            return View(_movieService.GetAll());
        }
        //GET: /Movies/Add
        public IActionResult Add()
        {
            Console.WriteLine("__________Add start_____________________");
            MovieAddViewModel model = new MovieAddViewModel();
            //model.Actors = _actorService.GetAll();
            //model.Movie = new MovieDTO();
            //model.Movie.Title = "asd";
            //model.Movie.Id = 5;
            //model.Movie.TrailerLink = "https://www.youtube.com" +
            //    "/watch?v=aPDLCTcjbGI&list=RDaPDLCTcjbGI&start_radio=1" +
            //    "&ab_channel=Neiro";
            //model.Movie.ThumbnailLink = "https://pbs.twimg.com/profile_images/1243623122089041920/gVZIvphd_400x400.jpg";
            //model.Movie.Year = 2000;
            //model.Movie.Description = "asdgfasdf";
            model.Genres = _genreService.GetAll();
            return View(model);
        }
        //POST: /Movies/Add
        [HttpPost]
        public IActionResult Add(MovieDTO movie)
        {
            _movieService.Create(movie);
            return View();
        }
    }
}
