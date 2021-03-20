using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StudentOffice.Models;
using StudentOffice.Models.DataBase;
using StudentOffice.ViewModels;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Text.RegularExpressions;
using System.Linq;
using Newtonsoft.Json;

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
        public async Task<IActionResult> qwe()
        {
            TimeTable timeTable = await _context.TimeTables
                .Include(i => i.Semester)
                .Include(i => i.TimeTableGroups)
                .Include(i => i.TimeTableGroups)
                .ThenInclude(i => i.Couples)
                .ThenInclude(i => i.Discipline)
                .Include(i => i.TimeTableGroups)
                .ThenInclude(i => i.Couples)
                .ThenInclude(i => i.Audience)
                .Include(i => i.TimeTableGroups)
                .ThenInclude(i => i.Couples)
                .ThenInclude(i => i.TimeWindow)
                .Include(i => i.TimeTableGroups)
                .ThenInclude(i => i.Couples)
                .FirstOrDefaultAsync();
            return Json(timeTable);
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

       
       
        public async Task<FileResult> qwerty123()
        {
            WebRequest request = WebRequest.Create("https://www.google.com/");
            using (WebResponse response = await request.GetResponseAsync())
            {
                using (Stream stream = response.GetResponseStream())
                {

                    byte[] buffer = new byte[16 * 1024];

                    using (MemoryStream ms = new MemoryStream())
                    {
                        int read;
                        while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            ms.Write(buffer, 0, read);
                        }

                        string file_type = "application/msword";
                        string file_name = "sample.doc";
                        return File(ms.ToArray(), file_type, file_name);
                    }
                }
            }
        }
 
       

     

        public async Task<IActionResult> SerializeUser()
        {
            using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
            {
                User user = await _context.Users.FirstOrDefaultAsync(i => i.UserName == User.Identity.Name);
                await System.Text.Json.JsonSerializer.SerializeAsync<User>(fs, user);
            }

            return Content("Объект был успешно сериализован");
        }

        public async Task<IActionResult> SerializeTimeTable()
        {
            //using (FileStream fs = new FileStream("timetable2.json", FileMode.OpenOrCreate))
            //{
                TimeTable timeTable = await _context.TimeTables.Include(i => i.Semester)
                .Include(i => i.Semester)
                .Include(i => i.TimeTableGroups)
                .ThenInclude(i => i.Group)
                .Include(i => i.TimeTableGroups)
                .ThenInclude(i => i.Couples)
                .ThenInclude(i => i.Discipline)
                .Include(i => i.TimeTableGroups)
                .ThenInclude(i => i.Couples)
                .ThenInclude(i => i.Audience)
                .Include(i => i.TimeTableGroups)
                .ThenInclude(i => i.Couples)
                .ThenInclude(i => i.TimeWindow)
                .Include(i => i.TimeTableGroups)
                .ThenInclude(i => i.Couples)
                .ThenInclude(i => i.User)
                .OrderByDescending(i => i.TimeTableId)
                .FirstOrDefaultAsync();
                //await JsonSerializer.SerializeAsync<TimeTable>(fs, timeTable);
            //}

            using (StreamWriter fs = new StreamWriter("timetable2.json"))
            {
                await fs.WriteLineAsync(JsonConvert.SerializeObject(timeTable));
            }

            //return Content("Сериализован");

            return Content("Объект был успешно сериализован");
        }


        

    }
}

