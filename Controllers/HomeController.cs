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
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;

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
            //ViewBag.DocumentTypeId = new SelectList(await _context.DocumentTypes.ToListAsync(), "DocumentTypeId", "Name");
            //ViewBag.SpecialtyId = new SelectList(await _context.Specialties.ToListAsync(), "SpecialtyId", "Name");

            var documentTypes = await _context.DocumentTypes.ToListAsync();
            var specialties = await _context.Specialties.ToListAsync();

            AnketaViewModel model = new AnketaViewModel { DocumentTypes = documentTypes, Specialties = specialties };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Anketa(AnketaViewModel model)
        {
            if (ModelState.IsValid)
            {

                User user = await _context.Users.Include(i => i.Anketa).FirstOrDefaultAsync(i => i.UserName == User.Identity.Name);

                if (user == null)
                {
                    return RedirectToAction("Index", "Home");
                }

                await _context.Anketas.AddAsync(model.Anketa);
                await _context.SaveChangesAsync();

                user.AnketaId = model.Anketa.AnketaId;

                _context.Update(user);

                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Home");
            }

            var documentTypes = await _context.DocumentTypes.ToListAsync();
            var specialties = await _context.Specialties.ToListAsync();

            model.DocumentTypes = documentTypes;
            model.Specialties = specialties;
            
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
            model.Groups = await _context.Groups.ToListAsync();

            return View(model);
        }

        [Authorize(Roles = "учащийся, admin")]
        [HttpPost]
        public async Task<IActionResult> Spravka(SpravkaViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _context.Users.FirstOrDefaultAsync(i => i.UserName == User.Identity.Name);

                if (model.Spravka != null && user != null)
                {
                    await _context.Spravkas.AddAsync(model.Spravka);
                    await _context.SaveChangesAsync();

                    SpravkaOrder spravkaOrder = new SpravkaOrder()
                    {
                        UserId = user.Id,
                        SpravkaId = model.Spravka.SpravkaId,
                        DateTimeNow = DateTime.Now
                    };

                    await _context.SpravkaOrders.AddAsync(spravkaOrder);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("Index", "Home");
                }

                return NotFound();
            }

            model.TypeOfSpravkas = await _context.TypeOfSpravkas.ToListAsync();
            model.Groups = await _context.Groups.ToListAsync();

            return View(model);

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
            User user = await _context.Users.Include(i => i.Anketa).FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);

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
                document.Replace("ParentType", user.Anketa.KinshipTypeMother.ToString().ToUpper(), false, true);
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
                .Include(i => i.Anketa).ThenInclude(i => i.Specialty)
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

                document.Replace("SpecialtyName", user.Anketa.Specialty.Name, false, true);
                document.Replace("PostCode", user.Anketa.Postcode.ToString(), false, true);
                document.Replace("Area", user.Anketa.Region.ToString(), false, true);
                document.Replace("District", user.Anketa.HullNumber, false, true);
                document.Replace("Town", user.Anketa.NameOfSettlement, false, true);
                document.Replace("Street", user.Anketa.StreetName, false, true);
                document.Replace("HomeNumber", user.Anketa.HouseNumber, false, true);
                document.Replace("Apartment", user.Anketa.ApartmentNumber, false, true);
                document.Replace("Phone", user.Anketa.HomePhone, false, true);
                document.Replace("YearOfEnding", user.Anketa.YearOfEnding.ToShortDateString(), false, true);
                document.Replace("EducationLevel", user.Anketa.EducationLevel.ToString(), false, true);
                document.Replace("Institution ", user.Anketa.Institution, false, true);
                document.Replace("Birthday", user.Anketa.Birthday.ToLongDateString(), false, true);
                document.Replace("FatherFullName", user.GetFullNameFather, false, true);
                document.Replace("FullName", user.GetFullNameR, false, true);
                document.Replace("MotherFullName", user.GetFullNameMother, false, true);
                document.Replace("DocumentType", user.Anketa.DocumentType.Name, false, true);
                document.Replace("Passport", user.Anketa.PassportSeries + user.Anketa.PassportNumber, false, true);
                document.Replace("DateOfIssue", user.Anketa.DateOfIssue.ToShortDateString(), false, true);
                document.Replace("IssuedBy", user.Anketa.IssuedBy, false, true);
                document.Replace("IdentityNumber", user.Anketa.IdentityNumber, false, true);
                document.Replace("DateTimeNow", DateTime.Now.ToShortDateString(), false, true);
                document.SaveToFile(Path.Combine(_appEnvironment.ContentRootPath, "Files\\zav123.docx"), FileFormat.Docx);

                return RedirectToAction("index");
            }
        }

        public async Task<IActionResult> Serialize()
        {
            using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
            {
                User user = await _context.Users.FirstOrDefaultAsync(i => i.UserName == User.Identity.Name);
                await JsonSerializer.SerializeAsync<User>(fs, user);
            }
             
            return Content("Объект был успешно сериализован");
        }
    }
}

