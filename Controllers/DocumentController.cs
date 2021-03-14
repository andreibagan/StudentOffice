using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Packaging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentOffice.Helpers;
using StudentOffice.Models.DataBase;

namespace StudentOffice.Controllers
{
    public class DocumentController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IWebHostEnvironment _appEnvironment;

        public DocumentController(ApplicationContext context, UserManager<User> userManager, IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _userManager = userManager;
            _appEnvironment = appEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //[HttpGet]
        //public async Task<FileResult> LetterOfIndemnity()
        //{
        //    User user = await _userManager.Users.Include(i => i.Anketa).ThenInclude(i => i.Specialty).FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);

        //    string path = string.Empty;
        //    string file_name = string.Empty;
        //    string file_type = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";

        //    if (user?.Anketa == null)
        //    {
        //        path = Path.Combine(_appEnvironment.ContentRootPath, "Files/Гарантийное письмо.docx");
        //        FileStream fs = new FileStream(path, FileMode.Open);
        //        file_name = $"Гарантийное письмо.docx";

        //        return File(fs, file_type, file_name);
        //    }
        //    else
        //    {
        //        path = Path.Combine(_appEnvironment.ContentRootPath, "Files/Гарантийное письмоPattern.docx");
        //        file_name = $"Гарантийное письмо от {DateTime.Now.ToShortDateString()}.docx";
        //        string docText = string.Empty;

        //        using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(path, true))
        //        {

        //            using (StreamReader sr = new StreamReader(wordDoc.MainDocumentPart.GetStream()))
        //            {
        //                docText = await sr.ReadToEndAsync();
        //            }

        //            Regex ParentFullName = new Regex("ParentFullName");
        //            Regex ParentType = new Regex("ParentType");
        //            Regex Sexvalue = new Regex("Sex");
        //            Regex FullName = new Regex("FullName");
        //            Regex DateTimeNow = new Regex("DateTimeNow");

        //            if ((int)user.Anketa.KinshipTypeMother != 0)
        //            {
        //                docText = ParentFullName.Replace(docText, user.GetFullNameMother.ToUpper());
        //                docText = ParentType.Replace(docText, EnumHelper<KinshipTypeMother>.GetDisplayValue(user.Anketa.KinshipTypeMother).ToUpper());
        //            }
        //            else
        //            {
        //                docText = ParentFullName.Replace(docText, user.GetFullNameFather);
        //                docText = ParentType.Replace(docText, EnumHelper<KinshipTypeFather>.GetDisplayValue(user.Anketa.KinshipTypeFather));
        //            }

        //            docText = Sexvalue.Replace(docText, user.Anketa.Sex == Sex.Male ? "СВОЕГО СЫНА" : "СВОЕЙ ДОЧЕРИ");
        //            docText = FullName.Replace(docText, user.GetFullNameR.ToUpper());
        //            docText = DateTimeNow.Replace(docText, DateTime.Now.ToShortDateString());
        //        }

        //        using (MemoryStream mem = new MemoryStream())
        //        {
        //            using (WordprocessingDocument wordDocNew = WordprocessingDocument.Create(mem, DocumentFormat.OpenXml.WordprocessingDocumentType.Document, true))
        //            {
        //                wordDocNew.AddMainDocumentPart();

        //                using (StreamWriter sw = new StreamWriter(wordDocNew.MainDocumentPart.GetStream(FileMode.Create)))
        //                {
        //                    await sw.WriteAsync(docText);
        //                }
        //            }

        //            return File(mem.ToArray(), file_type, file_name);
        //        }
        //    }
        //}


        [HttpGet]
        public async Task<FileResult> ApplicationOfApplicant()
        {
            User user = await _userManager.Users.Include(i => i.Anketa).ThenInclude(i => i.Specialty).Include(i => i.Anketa).ThenInclude(i => i.DocumentType).FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);

            string path = string.Empty;
            string file_name = string.Empty;
            string file_type = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";

            if (user?.Anketa == null)
            {
                path = Path.Combine(_appEnvironment.ContentRootPath, "Files/Заявление абитуриента.docx");
                FileStream fs = new FileStream(path, FileMode.Open);
                file_name = $"Заявление абитуриента.docx";

                return File(fs, file_type, file_name);
            }
            else
            {
                path = Path.Combine(_appEnvironment.ContentRootPath, "Files/Заявление абитуриентаPattern.docx");
                file_name = $"Заявление абитуриента от {DateTime.Now.ToShortDateString()}.docx";
                string docText = string.Empty;

                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(path, true))
                {

                    using (StreamReader sr = new StreamReader(wordDoc.MainDocumentPart.GetStream()))
                    {
                        docText = await sr.ReadToEndAsync();
                    }

                    Regex SpecialtyName = new Regex("SpecialtyName");
                    Regex PostCode = new Regex("PostCode");
                    Regex Area = new Regex("Area");
                    Regex District = new Regex("District");
                    Regex Town = new Regex("Town");
                    Regex Street = new Regex("Street");
                    Regex HomeNumber = new Regex("HomeNumber");
                    Regex Apartment = new Regex("Apartment");
                    Regex Phone = new Regex("Phone");
                    Regex YearOfEnding = new Regex("YearOfEnding");
                    Regex EducationLevel = new Regex("EducationLevel");
                    Regex Institution = new Regex("Institution");
                    Regex Birthday = new Regex("Birthday");
                    Regex FatherFullName = new Regex("FatherFullName");
                    Regex FullName = new Regex("FullName");
                    Regex MotherFullName = new Regex("MotherFullName");
                    Regex DocumentType = new Regex("DocumentType");
                    Regex Passport = new Regex("Passport");
                    Regex DateOfIssue = new Regex("DateOfIssue");
                    Regex IssuedBy = new Regex("IssuedBy");
                    Regex IdentityNumber = new Regex("IdentityNumber");
                    Regex DateTimeNow = new Regex("DateTimeNow");
                    Regex Branch= new Regex("Branch");
                    Regex AddressFather = new Regex("AddressFather");
                    Regex AddressMother = new Regex("AddressMother");
                    Regex KinshipTypeFather = new Regex("KinshipTypeFather");
                    Regex KinshipTypeMother = new Regex("KinshipTypeMother");
                    Regex SocialBehavior = new Regex("SocialBehavior");
                    Regex PlaceOfWorkAndPosition = new Regex("PlaceOfWorkAndPosition");
                    Regex SeniorityProfileSpecialty = new Regex("SeniorityProfileSpecialty");

                    docText = SeniorityProfileSpecialty.Replace(docText, user.Anketa.SeniorityProfileSpecialty);
                    docText = PlaceOfWorkAndPosition.Replace(docText, user.Anketa.PlaceOfWorkAndPosition);
                    docText = SocialBehavior.Replace(docText, user.Anketa.SocialBehavior ? "ДА" : "Нет");
                    docText = KinshipTypeFather.Replace(docText, EnumHelper<KinshipTypeFather>.GetDisplayValue(user.Anketa.KinshipTypeFather));
                    docText = KinshipTypeMother.Replace(docText, EnumHelper<KinshipTypeMother>.GetDisplayValue(user.Anketa.KinshipTypeMother));
                    docText = AddressFather.Replace(docText, user.Anketa.AddressFather);
                    docText = AddressMother.Replace(docText, user.Anketa.AddressMother);
                    docText = Branch.Replace(docText, EnumHelper<Branch>.GetDisplayValue(user.Anketa.Specialty.Branch).ToLower());
                    docText = SpecialtyName.Replace(docText, user.Anketa.Specialty.Name);
                    docText = PostCode.Replace(docText, user.Anketa.Postcode.ToString());
                    docText = Area.Replace(docText, EnumHelper<Region>.GetDisplayValue(user.Anketa.Region));
                    docText = District.Replace(docText, user.Anketa.PlaceOfBirth);
                    docText = Town.Replace(docText, EnumHelper<TypeOfSettlement>.GetDisplayValue(user.Anketa.TypeOfSettlement) + " " + user.Anketa.NameOfSettlement);
                    docText = Street.Replace(docText, EnumHelper<StreetType>.GetDisplayValue(user.Anketa.StreetType) + " " + user.Anketa.StreetName);
                    docText = HomeNumber.Replace(docText, "дом № " + user.Anketa.HouseNumber);
                    docText = Apartment.Replace(docText, "квартира " + user.Anketa.ApartmentNumber);
                    docText = Phone.Replace(docText, user.Anketa.HomePhone);
                    docText = YearOfEnding.Replace(docText, user.Anketa.YearOfEnding.Year.ToString());
                    docText = EducationLevel.Replace(docText, user.Anketa.EducationLevel == Models.DataBase.EducationLevel.Average ? "11 классов" : user.Anketa.EducationLevel == Models.DataBase.EducationLevel.Basic ? "9 классов" : "");
                    docText = Institution.Replace(docText, user.Anketa.Institution);
                    docText = Birthday.Replace(docText, user.Anketa.Birthday.ToString("D"));
                    docText = FatherFullName.Replace(docText, user.GetFullNameFather);
                    docText = MotherFullName.Replace(docText, user.GetFullNameMother);
                    docText = FullName.Replace(docText, user.GetFullNameR);
                    docText = DocumentType.Replace(docText, user.Anketa.DocumentType.Name);
                    docText = Passport.Replace(docText, user.Anketa.PassportSeries + user.Anketa.PassportNumber);
                    docText = DateOfIssue.Replace(docText, user.Anketa.DateOfIssue.ToShortDateString());
                    docText = IssuedBy.Replace(docText, user.Anketa.IssuedBy);
                    docText = IdentityNumber.Replace(docText, user.Anketa.IdentityNumber);
                    docText = DateTimeNow.Replace(docText, DateTime.Now.ToString("D"));
                }

                using (MemoryStream mem = new MemoryStream())
                {
                    using (WordprocessingDocument wordDocNew = WordprocessingDocument.Create(mem, DocumentFormat.OpenXml.WordprocessingDocumentType.Document, true))
                    {
                        wordDocNew.AddMainDocumentPart();

                        using (StreamWriter sw = new StreamWriter(wordDocNew.MainDocumentPart.GetStream(FileMode.Create)))
                        {
                            await sw.WriteAsync(docText);
                        }
                    }

                    return File(mem.ToArray(), file_type, file_name);
                }
            }
        }

        [HttpGet]
        public async Task<IActionResult> Zav1(string id)
        {
            //User user = await _userManager.Users.Include(i => i.Anketa).ThenInclude(i => i.Specialty).Include(i => i.Anketa).ThenInclude(i => i.DocumentType).FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);

            //string path = string.Empty;
            //string file_name = string.Empty;
            //string file_type = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";

            //if (user?.Anketa == null)
            //{
            //    path = Path.Combine(_appEnvironment.ContentRootPath, "Files/Заявление на общежитие.docx");
            //    FileStream fs = new FileStream(path, FileMode.Open);
            //    file_name = $"Заявление на общежитие.docx";

            //    return File(fs, file_type, file_name);
            //}
            //else
            //{
            //    path = Path.Combine(_appEnvironment.ContentRootPath, "Files/Заявление на общежитиеPattern.docx");
            //    file_name = $"Заявление на общежитие от {DateTime.Now.ToShortDateString()}.docx";
            //    string docText = string.Empty;

            //    using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(path, true))
            //    {

            //        using (StreamReader sr = new StreamReader(wordDoc.MainDocumentPart.GetStream()))
            //        {
            //            docText = await sr.ReadToEndAsync();
            //        }

            //        Regex FullName = new Regex("FullName");
            //        Regex Address = new Regex("Address");
            //        Regex Specialty = new Regex("Specialty");
            //        Regex DateTimeNow = new Regex("DateTimeNow");

            //        docText = FullName.Replace(docText, user.GetFullName);
            //        docText = Address.Replace(docText, user.Address);
            //        docText = Specialty.Replace(docText, user.Anketa.Specialty.Name);
            //        docText = DateTimeNow.Replace(docText, DateTime.Now.ToString("D"));

            //    }

            //    using (MemoryStream mem = new MemoryStream())
            //    {
            //        using (WordprocessingDocument wordDocNew = WordprocessingDocument.Create(mem, DocumentFormat.OpenXml.WordprocessingDocumentType.Document, true))
            //        {
            //            wordDocNew.AddMainDocumentPart();

            //            using (StreamWriter sw = new StreamWriter(wordDocNew.MainDocumentPart.GetStream(FileMode.Create)))
            //            {
            //                await sw.WriteAsync(docText);
            //            }
            //        }

            //        return File(mem.ToArray(), file_type, file_name);
            //    }
            //}

            //Uri location = new Uri($"{Request.Scheme}://{Request.Host}/Reports/SavingReport/{id}");
            //using (WebClient client = new WebClient())
            //{
            //    string file_type = "text/doc";
            //    string file_name = $"Председатели райпо - резерв {DateTime.Now.ToString()}.doc";
            //    return File(client.DownloadData(location), file_type, file_name);
            //}

            //string docText = string.Empty;


            //using (StreamReader sr = new StreamReader(Path.Combine(_appEnvironment.ContentRootPath, "Zav.html")))
            //{
            //    docText = await sr.ReadToEndAsync();
            //}

            //Uri location = new Uri($"{Request.Scheme}://{Request.Host}/Reports/SavingReport/{id}");
            //using (WebClient client = new WebClient())
            //{
            //    string file_type = "text/doc";
            //    string file_name = $"Председатели райпо - резерв {DateTime.Now.ToString()}.doc";
            //    return File(client.DownloadData(location), file_type, file_name);
            //}

            //using (WebClient client = new WebClient())
            //{
            //    Uri location = new Uri($"{Request.Scheme}://{Request.Host}/Document/Zav1");
            //    string file_type = "text/doc";
            //    string file_name = $"Заявление на общежитие от {DateTime.Now.ToShortDateString()}.doc";
            //    return File(client.DownloadData(location), file_type, file_name);
            //}
            User user = await _userManager.Users.Include(i => i.Anketa).FirstOrDefaultAsync(i => i.UserName == id);

            if (user?.Anketa == null)
            {
                return Content("Пожалуйста, заполните анкету");
            }

            return View(user);

        }

        [HttpPost]
        public async Task<FileResult> Zav1()
        {
            User user = await _userManager.FindByNameAsync(User.Identity.Name);

            using (WebClient client = new WebClient())
            {
                Uri location = new Uri($"{Request.Scheme}://{Request.Host}/Document/Zav1D/{user.UserName}");
                string file_type = "text/doc";
                string file_name = $"Заявление на общежитие от {DateTime.Now.ToShortDateString()}.doc";
                return File(client.DownloadData(location), file_type, file_name);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Zav1D(string id)
        {
            User user = await _userManager.Users.Include(i => i.Anketa).FirstOrDefaultAsync(i => i.UserName == id);

            if (user?.Anketa == null)
            {
                return Content("Пожалуйста, заполните анкету");
            }

            return View(user);
        }

            [HttpGet]
        public async Task<FileResult> ApplicationForPaymentInTwoSteps()
        {
            User user = await _userManager.Users.Include(i => i.Anketa).ThenInclude(i => i.Specialty).ThenInclude(i => i.Groups).Include(i => i.Anketa).ThenInclude(i => i.DocumentType).FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);

            string path = string.Empty;
            string file_name = string.Empty;
            string file_type = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";

            if (user?.Anketa == null)
            {
                path = Path.Combine(_appEnvironment.ContentRootPath, "Files/Заявление на оплату в два этапа.docx");
                FileStream fs = new FileStream(path, FileMode.Open);
                file_name = $"Заявление на оплату в два этапа.docx";

                return File(fs, file_type, file_name);
            }
            else
            {
                path = Path.Combine(_appEnvironment.ContentRootPath, "Files/Заявление на оплату в два этапаPattern.docx");
                file_name = $"Заявление на оплату в два этапа от {DateTime.Now.ToShortDateString()}.docx";
                string docText = string.Empty;

                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(path, true))
                {

                    using (StreamReader sr = new StreamReader(wordDoc.MainDocumentPart.GetStream()))
                    {
                        docText = await sr.ReadToEndAsync();
                    }

                    Regex Group = new Regex("Group");
                    Regex MotherFullName = new Regex("MotherFullName");
                    Regex Specialty = new Regex("Specialty");
                    Regex Address = new Regex("Address");
                    Regex Branch = new Regex("Branch");
                    Regex Phone = new Regex("Phone");

                    docText = Group.Replace(docText, user.Anketa.Specialty.Groups?.FirstOrDefault()?.GroupName == null ? "" : user.Anketa.Specialty.Groups?.FirstOrDefault()?.GroupName);
                    docText = Address.Replace(docText, user.Address);
                    docText = Specialty.Replace(docText, user.Anketa.Specialty.Name);
                    docText = MotherFullName.Replace(docText, user.GetFullNameMother);
                    docText = Branch.Replace(docText, user.Anketa.Specialty.Branch == Models.DataBase.Branch.Daytime ? "Дневного" : "Заочного");
                    docText = Phone.Replace(docText, user.Anketa.HomePhone);
                }

                using (MemoryStream mem = new MemoryStream())
                {
                    using (WordprocessingDocument wordDocNew = WordprocessingDocument.Create(mem, DocumentFormat.OpenXml.WordprocessingDocumentType.Document, true))
                    {
                        wordDocNew.AddMainDocumentPart();

                        using (StreamWriter sw = new StreamWriter(wordDocNew.MainDocumentPart.GetStream(FileMode.Create)))
                        {
                            await sw.WriteAsync(docText);
                        }
                    }

                    return File(mem.ToArray(), file_type, file_name);
                }
            }
        }

        [HttpGet]
        public async Task<FileResult> ApplicationForPaymentInSeveralStages()
        {
            User user = await _userManager.Users.Include(i => i.Anketa).ThenInclude(i => i.Specialty).ThenInclude(i => i.Groups).Include(i => i.Anketa).ThenInclude(i => i.DocumentType).FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);

            string path = string.Empty;
            string file_name = string.Empty;
            string file_type = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";

            if (user?.Anketa == null)
            {
                path = Path.Combine(_appEnvironment.ContentRootPath, "Files/Заявление на оплату в несколько этапов.docx");
                FileStream fs = new FileStream(path, FileMode.Open);
                file_name = $"Заявление на оплату в несколько этапов.docx";

                return File(fs, file_type, file_name);
            }
            else
            {
                path = Path.Combine(_appEnvironment.ContentRootPath, "Files/Заявление на оплату в несколько этаповPattern.docx");
                file_name = $"Заявление на оплату в несколько этапов от {DateTime.Now.ToShortDateString()}.docx";
                string docText = string.Empty;

                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(path, true))
                {

                    using (StreamReader sr = new StreamReader(wordDoc.MainDocumentPart.GetStream()))
                    {
                        docText = await sr.ReadToEndAsync();
                    }

                    Regex Group = new Regex("Group");
                    Regex MotherFullName = new Regex("MotherFullName");
                    Regex Specialty = new Regex("Specialty");
                    Regex Address = new Regex("Address");
                    Regex Branch = new Regex("Branch");
                    Regex Phone = new Regex("Phone");

                    docText = Group.Replace(docText, user.Anketa.Specialty.Groups?.FirstOrDefault()?.GroupName == null ? "" : user.Anketa.Specialty.Groups?.FirstOrDefault()?.GroupName);
                    docText = Address.Replace(docText, user.Address);
                    docText = Specialty.Replace(docText, user.Anketa.Specialty.Name);
                    docText = MotherFullName.Replace(docText, user.GetFullNameMother);
                    docText = Branch.Replace(docText, user.Anketa.Specialty.Branch == Models.DataBase.Branch.Daytime ? "Дневного" : "Заочного");
                    docText = Phone.Replace(docText, user.Anketa.HomePhone);
                }

                using (MemoryStream mem = new MemoryStream())
                {
                    using (WordprocessingDocument wordDocNew = WordprocessingDocument.Create(mem, DocumentFormat.OpenXml.WordprocessingDocumentType.Document, true))
                    {
                        wordDocNew.AddMainDocumentPart();

                        using (StreamWriter sw = new StreamWriter(wordDocNew.MainDocumentPart.GetStream(FileMode.Create)))
                        {
                            await sw.WriteAsync(docText);
                        }
                    }

                    return File(mem.ToArray(), file_type, file_name);
                }
            }
        }

        [HttpGet]
        public async Task<FileResult> ApplicationForPaymentMonthly()
        {
            User user = await _userManager.Users.Include(i => i.Anketa).ThenInclude(i => i.Specialty).ThenInclude(i => i.Groups).Include(i => i.Anketa).ThenInclude(i => i.DocumentType).FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);

            string path = string.Empty;
            string file_name = string.Empty;
            string file_type = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";

            if (user?.Anketa == null)
            {
                path = Path.Combine(_appEnvironment.ContentRootPath, "Files/Заявление на оплату ежемесячно.docx");
                FileStream fs = new FileStream(path, FileMode.Open);
                file_name = $"Заявление на оплату ежемесячно.docx";

                return File(fs, file_type, file_name);
            }
            else
            {
                path = Path.Combine(_appEnvironment.ContentRootPath, "Files/Заявление на оплату ежемесячноPattern.docx");
                file_name = $"Заявление на оплату ежемесячно от {DateTime.Now.ToShortDateString()}.docx";
                string docText = string.Empty;

                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(path, true))
                {

                    using (StreamReader sr = new StreamReader(wordDoc.MainDocumentPart.GetStream()))
                    {
                        docText = await sr.ReadToEndAsync();
                    }

                    Regex Group = new Regex("Group");
                    Regex MotherFullName = new Regex("MotherFullName");
                    Regex Specialty = new Regex("Specialty");
                    Regex Address = new Regex("Address");
                    Regex Branch = new Regex("Branch");
                    Regex Phone = new Regex("Phone");

                    docText = Group.Replace(docText, user.Anketa.Specialty.Groups?.FirstOrDefault()?.GroupName == null ? "" : user.Anketa.Specialty.Groups?.FirstOrDefault()?.GroupName);
                    docText = Address.Replace(docText, user.Address);
                    docText = Specialty.Replace(docText, user.Anketa.Specialty.Name);
                    docText = MotherFullName.Replace(docText, user.GetFullNameMother);
                    docText = Branch.Replace(docText, user.Anketa.Specialty.Branch == Models.DataBase.Branch.Daytime ? "Дневного" : "Заочного");
                    docText = Phone.Replace(docText, user.Anketa.HomePhone);
                }

                using (MemoryStream mem = new MemoryStream())
                {
                    using (WordprocessingDocument wordDocNew = WordprocessingDocument.Create(mem, DocumentFormat.OpenXml.WordprocessingDocumentType.Document, true))
                    {
                        wordDocNew.AddMainDocumentPart();

                        using (StreamWriter sw = new StreamWriter(wordDocNew.MainDocumentPart.GetStream(FileMode.Create)))
                        {
                            await sw.WriteAsync(docText);
                        }
                    }

                    return File(mem.ToArray(), file_type, file_name);
                }
            }
        }

        [HttpGet]
        public async Task<FileResult> ApplicationForPaymentForThePeriod()
        {
            User user = await _userManager.Users.Include(i => i.Anketa).ThenInclude(i => i.Specialty).ThenInclude(i => i.Groups).Include(i => i.Anketa).ThenInclude(i => i.DocumentType).FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);

            string path = string.Empty;
            string file_name = string.Empty;
            string file_type = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";

            if (user?.Anketa == null)
            {
                path = Path.Combine(_appEnvironment.ContentRootPath, "Files/Заявление на оплату за период.docx");
                FileStream fs = new FileStream(path, FileMode.Open);
                file_name = $"Заявление на оплату за период.docx";

                return File(fs, file_type, file_name);
            }
            else
            {
                path = Path.Combine(_appEnvironment.ContentRootPath, "Files/Заявление на оплату за периодPattern.docx");
                file_name = $"Заявление на оплату за период от {DateTime.Now.ToShortDateString()}.docx";
                string docText = string.Empty;

                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(path, true))
                {

                    using (StreamReader sr = new StreamReader(wordDoc.MainDocumentPart.GetStream()))
                    {
                        docText = await sr.ReadToEndAsync();
                    }

                    Regex Group = new Regex("Group");
                    Regex MotherFullName = new Regex("MotherFullName");
                    Regex Specialty = new Regex("Specialty");
                    Regex Address = new Regex("Address");
                    Regex Branch = new Regex("Branch");
                    Regex Phone = new Regex("Phone");

                    docText = Group.Replace(docText, user.Anketa.Specialty.Groups?.FirstOrDefault()?.GroupName == null ? "" : user.Anketa.Specialty.Groups?.FirstOrDefault()?.GroupName);
                    docText = Address.Replace(docText, user.Address);
                    docText = Specialty.Replace(docText, user.Anketa.Specialty.Name);
                    docText = MotherFullName.Replace(docText, user.GetFullNameMother);
                    docText = Branch.Replace(docText, user.Anketa.Specialty.Branch == Models.DataBase.Branch.Daytime ? "Дневного" : "Заочного");
                    docText = Phone.Replace(docText, user.Anketa.HomePhone);
                }

                using (MemoryStream mem = new MemoryStream())
                {
                    using (WordprocessingDocument wordDocNew = WordprocessingDocument.Create(mem, DocumentFormat.OpenXml.WordprocessingDocumentType.Document, true))
                    {
                        wordDocNew.AddMainDocumentPart();

                        using (StreamWriter sw = new StreamWriter(wordDocNew.MainDocumentPart.GetStream(FileMode.Create)))
                        {
                            await sw.WriteAsync(docText);
                        }
                    }

                    return File(mem.ToArray(), file_type, file_name);
                }
            }
        }
    }
}
