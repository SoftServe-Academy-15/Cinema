using BusinessLogic.DTOs;
using BusinessLogic.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorService _actorService;
        public ActorsController(IActorService actorService)
        {
            _actorService = actorService;
        }
        public IActionResult Index()
        {
            return View(_actorService.GetAll());
        }
        //GET: /Actors/Add
        public IActionResult Add()
        {
            return View();
        }
        //POST: /Actors/Add
        [HttpPost]
        public IActionResult Add(ActorDTO actor)
        {
            _actorService.Create(actor);
            return View();
        }
    }
}
