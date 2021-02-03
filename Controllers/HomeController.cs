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
using Spire.Doc;
using System;

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

                _context.Anketas.Add(model);
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

        public async Task<IActionResult> GetFile1()
        {
            User user = await _context.Users.Include(i => i.Anketa).ThenInclude(i => i.ParentInformation).FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);

            if (user.Anketa == null)
            {
                return Content("Вы не заполнили анкету!");
            }
            else
            {
                string file_path = Path.Combine(_appEnvironment.ContentRootPath, "Files\\123.docx");

                Document document = new Document();
                document.LoadFromFile(file_path);

                document.Replace("ParentFullName", user.GetFullNameMother.ToUpper(), false, true);
                document.Replace("ParentType", user.Anketa.ParentInformation.KinshipTypeMother.ToUpper(), false, true);
                document.Replace("Sex", user.Anketa.Sex == Sex.Male ? "СВОЕГО СЫНА" : "СВОЕЙ ДОЧЕРИ", false, true);
                document.Replace("FullName", user.GetFullNameR.ToUpper(), false, true);
                document.Replace("DateTimeNow", DateTime.Now.ToShortDateString(), false, true);

                document.SaveToFile(Path.Combine(_appEnvironment.ContentRootPath, "Files\\123123.docx"), FileFormat.Docx);

                return RedirectToAction("index");
            }
        }

        public async Task<IActionResult> GetFile2()
        {
            User user = await _context.Users
                .Include(i => i.Anketa).ThenInclude(i => i.ParentInformation)
                .Include(i => i.Anketa).ThenInclude(i => i.Specialty)
                .Include(i => i.Anketa).ThenInclude(i => i.Accommodation)
                .Include(i => i.Anketa).ThenInclude(i => i.Education)
                .Include(i => i.Anketa).ThenInclude(i => i.Passport)
                .FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);

            if (user.Anketa == null)
            {
                return Content("Вы не заполнили анкету!");
            }
            else
            {
                string file_path = Path.Combine(_appEnvironment.ContentRootPath, "Files\\zav.docx");

                Document document = new Document();
                document.LoadFromFile(file_path);

                document.Replace("SpecialtyName", user.Anketa.Specialty.SpecialtyName, false, true);
                document.Replace("PostCode", user.Anketa.Accommodation.Postcode.ToString(), false, true);
                document.Replace("Area", user.Anketa.Accommodation.Region, false, true);
                document.Replace("District", user.Anketa.Accommodation.TypeOfSettlement, false, true);
                document.Replace("Town", user.Anketa.Accommodation.NameOfSettlement, false, true);
                document.Replace("Street", user.Anketa.Accommodation.StreetName, false, true);
                document.Replace("HomeNumber", user.Anketa.Accommodation.HouseNumber, false, true);
                document.Replace("Apartment", user.Anketa.Accommodation.ApartmentNumber, false, true);
                document.Replace("Phone", user.Anketa.Accommodation.HomePhone, false, true);
                document.Replace("YearOfEnding", user.Anketa.Education.YearOfEnding.Year.ToString(), false, true);
                document.Replace("EducationLevel", user.Anketa.Education.EducationLevel, false, true);
                document.Replace("Institution ", user.Anketa.Education.Institution, false, true);
                document.Replace("Birthday", user.Anketa.Birthday.ToLongDateString(), false, true);
                document.Replace("FatherFullName", user.GetFullNameFather, false, true);
                document.Replace("FullName", user.GetFullNameR, false, true);
                document.Replace("MotherFullName", user.GetFullNameMother, false, true);
                document.Replace("DocumentType", user.Anketa.Passport.DocumentType, false, true);
                document.Replace("Passport", user.Anketa.Passport.PassportSeries + user.Anketa.Passport.PassportNumber, false, true);
                document.Replace("DateOfIssue", user.Anketa.Passport.DateOfIssue.ToShortDateString(), false, true);
                document.Replace("IssuedBy", user.Anketa.Passport.IssuedBy, false, true);
                document.Replace("IdentityNumber", user.Anketa.Passport.IdentityNumber, false, true);
                document.Replace("DateTimeNow", DateTime.Now.ToShortDateString(), false, true);

                document.SaveToFile(Path.Combine(_appEnvironment.ContentRootPath, "Files\\zav123.docx"), FileFormat.Docx);

                return RedirectToAction("index");
            }
        }
    }
}

