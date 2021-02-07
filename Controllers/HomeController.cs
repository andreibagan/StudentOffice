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
using StudentOffice.ViewModels;

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
        public async Task<IActionResult> Anketa()
        {
            AnketaViewModel model = new AnketaViewModel();
            model.DocumentTypes = await _context.DocumentTypes.ToListAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Anketa(AnketaViewModel model)
        {
            if (ModelState.IsValid)
            {

                Enrollee enrollee = _context.Enrollees.Include(i => i.User).Include(i => i.Anketa).FirstOrDefault(i => i.User.UserName == User.Identity.Name);

                if (enrollee != null)
                {
                    return RedirectToAction("Index", "Home");
                }

                await _context.Anketas.AddAsync(model.Anketa);
                await _context.SaveChangesAsync();

                enrollee.AnketaId = model.Anketa.AnketaId;

                _context.Update(enrollee);

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

        [Authorize(Roles = "учащийся, admin")]
        [HttpGet]
        public async Task<IActionResult> Spravka()
        {
            SpravkaViewModel model = new SpravkaViewModel();

            model.TypeOfSpravkas = await _context.TypeOfSpravkas.ToListAsync();
            //model.Spravka.TypeOfSpravkaId = 1;

            return View(model);
        }

        [Authorize(Roles = "учащийся, admin")]
        [HttpPost]
        public async Task<IActionResult> Spravka(SpravkaViewModel model)
        {
           
            Student student = await _context.Students.Include(i => i.User).FirstOrDefaultAsync(i => i.User.UserName == User.Identity.Name);
          
            if (model.Spravka != null && student != null)
            {
                await _context.Spravkas.AddAsync(model.Spravka);
                await _context.SaveChangesAsync();

                SpravkaOrder spravkaOrder = new SpravkaOrder()
                {
                    StudentId = student.StudentId,
                    SpravkaId = model.Spravka.SpravkaId,
                    DateTimeNow = DateTime.Now
                };

                await _context.SpravkaOrders.AddAsync(spravkaOrder);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Home");
            }

            return NotFound();
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
            Enrollee enrollee = await _context.Enrollees.Include(i => i.Anketa).ThenInclude(i => i.Mother).Include(i => i.Anketa).ThenInclude(i => i.Father).FirstOrDefaultAsync(u => u.User.UserName == User.Identity.Name);

            if (enrollee.Anketa == null)
            {
                return Content("Вы не заполнили анкету!");
            }
            else
            {
                string file_path = Path.Combine(_appEnvironment.ContentRootPath, "Files\\123.docx");

                Document document = new Document();
                document.LoadFromFile(file_path);

                document.Replace("ParentFullName", enrollee.GetFullNameMother.ToUpper(), false, true);
                document.Replace("ParentType", enrollee.Anketa.Mother.KinshipType.ToUpper(), false, true);
                document.Replace("Sex", enrollee.Anketa.Sex == Sex.Male ? "СВОЕГО СЫНА" : "СВОЕЙ ДОЧЕРИ", false, true);
                document.Replace("FullName", enrollee.GetFullNameR.ToUpper(), false, true);
                document.Replace("DateTimeNow", DateTime.Now.ToShortDateString(), false, true);

                document.SaveToFile(Path.Combine(_appEnvironment.ContentRootPath, "Files\\123123.docx"), FileFormat.Docx);

                return RedirectToAction("index");
            }
        }

        public async Task<IActionResult> GetFile2()
        {
            Enrollee enrollee = await _context.Enrollees
                .Include(i => i.Anketa).ThenInclude(i => i.Mother)
                .Include(i => i.Anketa).ThenInclude(i => i.Father)
                .Include(i => i.Anketa).ThenInclude(i => i.Specialty)
                .Include(i => i.Anketa).ThenInclude(i => i.Accommodation)
                .Include(i => i.Anketa).ThenInclude(i => i.Education)
                .Include(i => i.Anketa).ThenInclude(i => i.Passport)
                .FirstOrDefaultAsync(u => u.User.UserName == User.Identity.Name);

            if (enrollee.Anketa == null)
            {
                return Content("Вы не заполнили анкету!");
            }
            else
            {
                string file_path = Path.Combine(_appEnvironment.ContentRootPath, "Files\\zav.docx");

                Document document = new Document();
                document.LoadFromFile(file_path);

                document.Replace("SpecialtyName", enrollee.Anketa.Specialty.SpecialtyName, false, true);
                document.Replace("PostCode", enrollee.Anketa.Accommodation.Address.Postcode.ToString(), false, true);
                document.Replace("Area", enrollee.Anketa.Accommodation.Address.Locality.District.Area.NameArea, false, true);
                document.Replace("District", enrollee.Anketa.Accommodation.Address.Locality.District.NameDistrict, false, true);
                document.Replace("Town", enrollee.Anketa.Accommodation.Address.Locality.Namelocality, false, true);
                document.Replace("Street", enrollee.Anketa.Accommodation.Address.StreetName, false, true);
                document.Replace("HomeNumber", enrollee.Anketa.Accommodation.Address.HouseNumber, false, true);
                document.Replace("Apartment", enrollee.Anketa.Accommodation.Address.ApartmentNumber, false, true);
                document.Replace("Phone", enrollee.Anketa.Accommodation.HomePhone, false, true);
                document.Replace("YearOfEnding", enrollee.Anketa.Education.YearOfEnding.Year.ToString(), false, true);
                document.Replace("EducationLevel", enrollee.Anketa.Education.EducationLevel, false, true);
                document.Replace("Institution ", enrollee.Anketa.Education.Institution, false, true);
                document.Replace("Birthday", enrollee.Anketa.Birthday.ToLongDateString(), false, true);
                document.Replace("FatherFullName", enrollee.GetFullNameFather, false, true);
                document.Replace("FullName", enrollee.GetFullNameR, false, true);
                document.Replace("MotherFullName", enrollee.GetFullNameMother, false, true);
                document.Replace("DocumentType", enrollee.Anketa.Passport.DocumentType.ToString(), false, true);
                document.Replace("Passport", enrollee.Anketa.Passport.PassportSeries + enrollee.Anketa.Passport.PassportNumber, false, true);
                document.Replace("DateOfIssue", enrollee.Anketa.Passport.DateOfIssue.ToShortDateString(), false, true);
                document.Replace("IssuedBy", enrollee.Anketa.Passport.IssuedBy, false, true);
                document.Replace("IdentityNumber", enrollee.Anketa.Passport.IdentityNumber, false, true);
                document.Replace("DateTimeNow", DateTime.Now.ToShortDateString(), false, true);
                document.SaveToFile(Path.Combine(_appEnvironment.ContentRootPath, "Files\\zav123.docx"), FileFormat.Docx);

                return RedirectToAction("index");
            }
        }
    }
}

