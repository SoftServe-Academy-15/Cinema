﻿using BusinessLogic.DTOs;
using BusinessLogic.Interfaces.Services;
using BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View(_userService.GetAll());
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(UserDTO user)
        {
            _userService.Create(user);
            return View();
        }
    }
}
