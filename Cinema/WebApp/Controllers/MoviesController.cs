using BusinessLogic.DTOs;
using BusinessLogic.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IGenreService _genreService;
        private readonly IActorService _actorService;
        private MovieAddViewModel _model;
        public MoviesController(IMovieService movieService, IGenreService genreService, IActorService actorService)
        {
            _movieService = movieService;
            _genreService = genreService;
            _actorService = actorService;
            _model = new MovieAddViewModel();
            _model.Genres = _genreService.GetAll();
        }
        //GET: /Movies/Index or /Movies
        public IActionResult Index()
        {
            List<MovieDTO> movies = _movieService.GetAll();
            return View(movies);
        }
        //GET: /Movies/Details  
        public IActionResult Details(int id)
        {
            MovieDTO mov = _movieService.GetMovieById(id);
            return View(mov);
        }
        //GET: /Movies/Add
        [Authorize(Roles = "Admin")]
        public IActionResult Add()
        {
            //RoleDTO role = TempData["R"];
            return View(_model);
        }
        //POST: /Movies/Add
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Add(MovieAddViewModel data)
        {
            Console.WriteLine(data.GenreString);

            MovieDTO movie = data.Movie;

            string[] genreNames = data.GenreString.Split(';');
            movie.Genres = _genreService.GetByNames(genreNames);

            movie.Roles = new List<RoleDTO>();
            string[] actorNames = data.ActorNameString.Split(";");
            string[] roleNames = data.RoleNameString.Split(";");
            string[] mainRole = data.MainRoleString.Split(";");

            Console.WriteLine(data.MainRoleString);
            for (int i = 0; i < actorNames.Length-1; i++)
            {
                Console.WriteLine(mainRole[i]);
                RoleDTO roleDTO = new RoleDTO();
                roleDTO.ActorId = _actorService.GetActorByName(actorNames[i]).Id;
                roleDTO.Role = roleNames[i];    
                roleDTO.IsMainRole = mainRole[i] == "true";
                movie.Roles.Add(roleDTO);
            }

            _movieService.Create(movie);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddRole(ActorDTO actor)
        {
            return RedirectToAction("Add");
        }
    }
}
