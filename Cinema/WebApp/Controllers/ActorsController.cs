using System.Web.Http;
using BusinessLogic.DTOs;
using BusinessLogic.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorService _actorService;
        private ActorManagerModel _actorManagerModel;

        //If true - then in the next Index page invoke page mode will be set to default (View)
        //Resetting to true each Index call
        //Set to false before redirecting to Index page, if you changed page mode
        bool _defaultPageMode = true;
        public ActorsController(IActorService actorService)
        {
            _actorService = actorService;
            _actorManagerModel = new ActorManagerModel();
        }
        //GET: /Actors
        public IActionResult Index()
        {
            if (_defaultPageMode)
                _actorManagerModel.PageMode = ActorManagerPageMode.View;
            _defaultPageMode = true;
            _actorManagerModel.Actors = _actorService.GetAll();
            return View(_actorManagerModel);
        }
        //GET: /Actors/Manage
        public IActionResult Manage()
        {
            _defaultPageMode = false;
            _actorManagerModel.PageMode = ActorManagerPageMode.Manage;
            return RedirectToAction(nameof(Index));
        }
        //GET: /Actors/Select
        public IActionResult Select()
        {
            _defaultPageMode = false;
            _actorManagerModel.PageMode = ActorManagerPageMode.Select;
            return RedirectToAction(nameof(Index));
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
            try
            {
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
            catch (Exception ex)
            {
                Console.WriteLine($"ex.Message: {ex.Message}, ex.Source: {ex.Source}");
                return new InternalServerErrorResult();
            }
        }
    }
}
