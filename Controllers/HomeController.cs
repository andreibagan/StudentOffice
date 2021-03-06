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



        //public FileResult GetFile()
        //{
        //    //string file_path = Path.Combine(_appEnvironment.ContentRootPath, "Files\\Unity1.pdf");

        //    //string file_type = "application/pdf";

        //    //string file_name = "Unity1.pdf";

        //    //return PhysicalFile(file_path, file_type, file_name);


        //    //WordDocument document = new WordDocument();
        //    //WSection section = document.AddSection() as WSection;
        //    //MemoryStream stream = new MemoryStream();
        //    //document.Save(stream, FormatType.Docx);
        //    //stream.Position = 0;
        //    //return File(stream, "application/msword", "Sample.docx");








        //}

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

                Spire.Doc.Document document = new Spire.Doc.Document();
                document.LoadFromFile(file_path);

                document.Replace("ParentFullName", user.GetFullNameMother.ToUpper(), false, true);
                document.Replace("ParentType", user.Anketa.KinshipTypeMother.ToString().ToUpper(), false, true);
                document.Replace("Sex", user.Anketa.Sex == Sex.Male ? "СВОЕГО СЫНА" : "СВОЕЙ ДОЧЕРИ", false, true);
                document.Replace("FullName", user.GetFullNameR.ToUpper(), false, true);
                document.Replace("DateTimeNow", DateTime.Now.ToShortDateString(), false, true);

                document.SaveToFile(Path.Combine(_appEnvironment.ContentRootPath, "Files\\123123.docx"), FileFormat.Docx);


                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(Path.Combine(_appEnvironment.ContentRootPath, "Files\\123123.docx"), true))
                {
                    string docText = null;
                    using (StreamReader sr = new StreamReader(wordDoc.MainDocumentPart.GetStream()))
                    {
                        docText = sr.ReadToEnd();
                    }

                    Regex regexText = new Regex("Evaluation Warning: The document was created with Spire.Doc for .NET.");
                    docText = regexText.Replace(docText, "");

                    using (StreamWriter sw = new StreamWriter(wordDoc.MainDocumentPart.GetStream(FileMode.Create)))
                    {
                        sw.Write(docText);
                    }
                }


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

                Spire.Doc.Document document = new Spire.Doc.Document();
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

