using BusinessLogic.DTOs;
using BusinessLogic.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class RolesController : Controller
    {
        private readonly IActorService _actorService;
        private RoleModel _model;
        private RoleDTO _roleDTO;
        public RolesController(IActorService actorService)
        {
            _actorService = actorService;
            _model = new RoleModel();
        }
        //GET /Roles/Add
        public IActionResult Add()
        {
            return View(_model);
        }
    }
}
