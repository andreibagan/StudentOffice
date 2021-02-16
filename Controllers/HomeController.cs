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
using Spire.Doc;
using StudentOffice.Models;
using StudentOffice.Models.DataBase;
using StudentOffice.ViewModels;

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

        [HttpGet]
        public async Task<IActionResult> Anketa(string id)
        {
            var documentTypes = await _context.DocumentTypes.ToListAsync();
            var specialties = await _context.Specialties.ToListAsync();

            AnketaViewModel model = new AnketaViewModel { DocumentTypes = documentTypes, Specialties = specialties };

            if (id != null && User.IsInRole("admin"))
            {
                User user = await _userManager.Users.Include(i => i.Anketa).FirstOrDefaultAsync(i => i.Id == id);

                if (user.Anketa != null)
                {
                    model.Anketa = user.Anketa;
                }
            }
            else
            {
                Anketa anketa = _context.Users.Include(i => i.Anketa).FirstOrDefaultAsync(i => i.UserName == User.Identity.Name).Result.Anketa;
                if (anketa != null)
                {
                    model.Anketa = anketa;
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Anketa(AnketaViewModel model)
        {
            if (ModelState.IsValid)
            {
                Anketa anketa = await _context.Anketas.FindAsync(model.Anketa.AnketaId);

                if (anketa != null)
                {
                    anketa.AddressFather = model.Anketa.AddressFather;
                    anketa.AddressMother = model.Anketa.AddressMother;
                    anketa.ApartmentNumber = model.Anketa.ApartmentNumber;
                    anketa.Birthday = model.Anketa.Birthday;
                    anketa.DateOfIssue = model.Anketa.DateOfIssue;
                    anketa.DateOfValidity = model.Anketa.DateOfValidity;
                    anketa.DocumentTypeId = model.Anketa.DocumentTypeId;
                    anketa.EducationLevel = model.Anketa.EducationLevel;
                    anketa.HomePhone = model.Anketa.HomePhone;
                    anketa.HouseNumber = model.Anketa.HouseNumber;
                    anketa.HullNumber = model.Anketa.HullNumber;
                    anketa.IdentityNumber = model.Anketa.IdentityNumber;
                    anketa.Institution = model.Anketa.Institution;
                    anketa.IssuedBy = model.Anketa.IssuedBy;
                    anketa.KinshipTypeFather = model.Anketa.KinshipTypeFather;
                    anketa.KinshipTypeMother = model.Anketa.KinshipTypeMother;
                    anketa.Middlename = model.Anketa.Middlename;
                    anketa.MiddlenameFather = model.Anketa.MiddlenameFather;
                    anketa.MiddlenameMother = model.Anketa.MiddlenameMother;
                    anketa.MiddlenameR = model.Anketa.MiddlenameR;
                    anketa.Name = model.Anketa.Name;
                    anketa.NameFather = model.Anketa.NameFather;
                    anketa.NameMother = model.Anketa.NameMother;
                    anketa.NameOfSettlement = model.Anketa.NameOfSettlement;
                    anketa.NameR = model.Anketa.NameR;
                    anketa.PassportNumber = model.Anketa.PassportNumber;
                    anketa.PassportSeries = model.Anketa.PassportSeries;
                    anketa.PlaceOfBirth = model.Anketa.PlaceOfBirth;
                    anketa.PlaceOfWorkAndPosition = model.Anketa.PlaceOfWorkAndPosition;
                    anketa.Postcode = model.Anketa.Postcode;
                    anketa.Region = model.Anketa.Region;
                    anketa.SeniorityGeneral = model.Anketa.SeniorityGeneral;
                    anketa.SeniorityProfileSpecialty = model.Anketa.SeniorityProfileSpecialty;
                    anketa.Sex = model.Anketa.Sex;
                    anketa.SocialBehavior = model.Anketa.SocialBehavior;
                    anketa.SpecialtyId = model.Anketa.SpecialtyId;
                    anketa.StreetName = model.Anketa.StreetName;
                    anketa.StreetType = model.Anketa.StreetType;
                    anketa.Surname = model.Anketa.Surname;
                    anketa.SurnameFather = model.Anketa.AddressFather;
                    anketa.SurnameMother = model.Anketa.SurnameMother;
                    anketa.SurnameR = model.Anketa.SurnameR;
                    anketa.TypeOfSettlement = model.Anketa.TypeOfSettlement;
                    anketa.YearOfEnding = model.Anketa.YearOfEnding;

                    _context.Anketas.Update(anketa);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("Index", "Home");
                }

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

        //public void Reser()
        //{
        //    using (var client = new WebClient())
        //    {
        //        string html = client.DownloadString("https://google.com");


        //        using (FileStream fstream = new FileStream($"google.html", FileMode.OpenOrCreate))
        //        {
        //            // преобразуем строку в байты
        //            byte[] array = System.Text.Encoding.Default.GetBytes(html);
        //            // запись массива байтов в файл
        //            fstream.Write(array, 0, array.Length);
        //        }
        //    }
        //}
    }
}

