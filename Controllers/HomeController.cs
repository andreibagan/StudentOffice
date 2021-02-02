using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentOffice.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace StudentOffice.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly IWebHostEnvironment _appEnvironment;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationContext context, IWebHostEnvironment appEnvironment)
        {
            _logger = logger;
            _context = context;
            _appEnvironment = appEnvironment;
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

        [HttpGet]
        public IActionResult Anketa()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Anketa(Anketa model)
        {
            if (ModelState.IsValid)
            {

                var user = _context.Users.Include(i => i.Anketa).FirstOrDefault(i => i.UserName == User.Identity.Name);

                if (user.Anketa != null)
                {
                    return RedirectToAction("Index", "Home");
                }

                _context.Anketa.Add(model);
                await _context.SaveChangesAsync();

                user.AnketaId = model.AnketaId;

                _context.Update(user);

                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
        public IActionResult About()
        {
            return Content("Authorized");
        }
        [Authorize(Roles = "admin")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult GetFile()
        {
            string file_path = Path.Combine(_appEnvironment.ContentRootPath, "Files\\Unity1.pdf");

            string file_type = "application/pdf";

            string file_name = "Unity1.pdf";

            return PhysicalFile(file_path, file_type, file_name);
        }
    }
}
