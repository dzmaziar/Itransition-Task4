﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Task_4.Models;

namespace Task_4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [Authorize]
       
            [AllowAnonymous]
            public IActionResult Index()
            {
                if (User.Identity.IsAuthenticated)
                {
                    return Content(User.Identity.Name);
                }
                return Content("не аутентифицирован");
            }
            public IActionResult About()
            {
                return Content("Authorized");
            }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}