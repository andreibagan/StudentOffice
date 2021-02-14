using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StudentOffice.Models.DataBase;
using StudentOffice.ViewModels;

namespace StudentOffice.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private ApplicationContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(ApplicationContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Unload()
        {
            UnloadViewModel model = new UnloadViewModel { Roles = _roleManager.Roles.ToList() };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Unload(UnloadViewModel model, IEnumerable<string> roles)    
        {
            string json = string.Empty;

            using (var fs = System.IO.File.OpenRead(model.Path))
            {
                using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
                {
                    json = sr.ReadToEnd();
                }
            }

            var usersviewmodel = JsonConvert.DeserializeObject<List<UserUnloadViewModel>>(json);

            if (usersviewmodel == null)
            {
                return Content("Ошибка чтения файла");
            }

            foreach (var user in usersviewmodel)
            {
                var currentuser = new User
                {
                    Email = user.Email,
                    UserName = user.Email,
                    EmailConfirmed = model.IsConfirmedEmail
                };

                await _userManager.CreateAsync(currentuser, user.Password);

                await _userManager.AddToRolesAsync(currentuser, roles);
            }

            return RedirectToAction("Unload");
        }

    }
}
