using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StudentOffice.Models;
using StudentOffice.Models.DataBase;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace StudentOffice.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IWebHostEnvironment _appEnvironment;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationContext context, IWebHostEnvironment appEnvironment, UserManager<User> userManager)
        {
            _logger = logger;
            _context = context;
            _appEnvironment = appEnvironment;
            _userManager = userManager;
        }

        //[AllowAnonymous]
        //[Authorize(Roles = "admin, user")]
        [HttpGet]
        public IActionResult Index()
        {
            //string role = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
            //return Content($"Ваша роль: {role}");

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

