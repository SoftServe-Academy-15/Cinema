using System.Security.Claims;
using System.Web.Http;
using BusinessLogic.DTOs;
using BusinessLogic.Interfaces.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorService _actorService;

        public ActorsController(IActorService actorService)
        {
            _actorService = actorService;
        }
        //GET: /Actors
        public IActionResult Index()
        {
            return View(_actorService.GetAll());
        }
        //GET: /Actors/GetActorByName/{name}
        [HttpGet]
        [Route("/Actors/GetActorByName/{name}")]
        [Route("/Actors/GetActorByName/")]
        public JsonResult GetActorByName(string name)
        {
            ActorDTO actor = _actorService.GetActorByName(name); 
            if(actor != null)
            {
                for (int i = 0; i < actor.Roles.Count; i++)
                {
                    actor.Roles[i].Actor = null;
                }
            }
            return Json(actor);
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
            actor.Name = actor.Name.Trim();
            actor.Surname = actor.Surname.Trim();
            _actorService.Create(actor);
            return View();
        }
        //Delete: /Actors/Delete/{id}
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if(!User.Identity.IsAuthenticated)
            {
                return Unauthorized();
            }
            if (User.FindFirst(ClaimTypes.Role)?.Value != "Admin") 
            {
                return Forbid();
            }
            var _actorToDelete = _actorService.GetActorById(id);
            if (_actorToDelete == null)
            {
                return NotFound($"Actor with id={id} not found");
            }
            else
            {
                _actorService.Delete(_actorToDelete);
                return Ok();
            }
        }
    }
}
