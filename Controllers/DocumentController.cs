using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Packaging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpGet]
        public async Task<FileResult> LetterOfIndemnity()
        {
            User user = await _userManager.Users.Include(i => i.Anketa).ThenInclude(i => i.Specialty).FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);

            string path = string.Empty;
            string file_name = string.Empty;
            string file_type = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";

            if (user?.Anketa == null)
            {
                path = Path.Combine(_appEnvironment.ContentRootPath, "Files/Гарантийное письмо.docx");
                FileStream fs = new FileStream(path, FileMode.Open);
                file_name = $"Гарантийное письмо.docx";

                return File(fs, file_type, file_name);
            }
            else
            {
                ////using(Stream stream = new Stream())
                //using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(Path.Combine(_appEnvironment.ContentRootPath, "Files/Гарантийное письмоPattern.docx"), true))
                //{
                //    string docText = null;
                //    file_name = $"Гарантийное письмо от {DateTime.Now.ToShortDateString()}.docx";

                //    //using (Stream stream = new FileStream(Path.Combine(_appEnvironment.ContentRootPath, "Files/Гарантийное письмо.docx"), FileMode.Open, FileAccess.Read, FileShare.Read);)
                //    //{

                //    //    byte[] buffer = new byte[16 * 1024];

                //    //    using (MemoryStream ms = new MemoryStream())
                //    //    {
                //    //        int read;
                //    //        while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                //    //        {
                //    //            ms.Write(buffer, 0, read);
                //    //        }

                //    //        return File(ms.ToArray(), file_type, file_name);
                //    //    }
                //    //}



                //    using (StreamReader sr = new StreamReader(wordDoc.MainDocumentPart.GetStream()))
                //    {
                //        docText = sr.ReadToEnd();

                //        Regex ParentFullName = new Regex("ParentFullName");
                //        Regex ParentType = new Regex("ParentType");
                //        Regex Sexvalue = new Regex("Sex");
                //        Regex FullName = new Regex("FullName");
                //        Regex DateTimeNow = new Regex("DateTimeNow");

                //        docText = ParentFullName.Replace(docText, user.GetFullNameMother);
                //        docText = ParentType.Replace(docText, EnumHelper<KinshipTypeMother>.GetDisplayValue(user.Anketa.KinshipTypeMother));
                //        docText = Sexvalue.Replace(docText, user.Anketa.Sex == Sex.Male ? "СВОЕГО СЫНА" : "СВОЕЙ ДОЧЕРИ");
                //        docText = FullName.Replace(docText, user.GetFullNameR);
                //        docText = DateTimeNow.Replace(docText, user.GetFullNameMother);

                //        byte[] buffer = new byte[16 * 1024];
                //        using (MemoryStream ms = new MemoryStream())
                //        {
                //            int read;
                //            while ((read = wordDoc.MainDocumentPart.GetStream().Read(buffer, 0, buffer.Length)) > 0)
                //            {
                //                ms.Write(buffer, 0, read);
                //            }
                //            return File(ms.ToArray(), file_type, file_name);
                //        }   
                //    }



                //    //wordDoc.SaveAs(Path.Combine(_appEnvironment.ContentRootPath, $"Files/Гарантийное письмо {user.GetFullNameR}.docx"));
                //    //using (StreamWriter sw = new StreamWriter(wordDoc.MainDocumentPart.GetStream(FileMode.Create)))
                //    //{
                //    //    sw.Write(docText);
                //    //}


                //}

                //using (MemoryStream mem = new MemoryStream())
                //{
                //    using (WordprocessingDocument wordDoc = WordprocessingDocument.Create(mem, DocumentFormat.OpenXml.WordprocessingDocumentType.Document, true))
                //    {
                //        wordDoc.MainDocumentPart.Document = "";
                //        wordDoc.Close();
                //    }
                //    return File(mem.ToArray(), "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "ABC.docx");
                //}

                return File("", "");

            }


        }


        [HttpGet]
        public async Task<FileResult> ApplicationOfApplicant()
        {
            User user = await _userManager.Users.Include(i => i.Anketa).ThenInclude(i => i.Specialty).FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);

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
                //Regex SpecialtyName = new Regex("SpecialtyName");
                //Regex PostCode = new Regex("PostCode");
                //Regex Area = new Regex("Area");
                //Regex District = new Regex("District");
                //Regex Town = new Regex("Town");
                //Regex Street = new Regex("Street");
                //Regex HomeNumber = new Regex("HomeNumber");
                //Regex Apartment = new Regex("Apartment");
                //Regex Phone = new Regex("Phone");
                //Regex YearOfEnding = new Regex("YearOfEnding");
                //Regex EducationLevel = new Regex("EducationLevel");
                //Regex Institution = new Regex("Institution");
                //Regex Birthday = new Regex("Birthday");
                //Regex FatherFullName = new Regex("FatherFullName");
                //Regex FullName = new Regex("FullName");
                //Regex MotherFullName = new Regex("MotherFullName");
                //Regex DocumentType = new Regex("DocumentType");
                //Regex Passport = new Regex("Passport");
                //Regex DateOfIssue = new Regex("DateOfIssue");
                //Regex IssuedBy = new Regex("IssuedBy");
                //Regex IdentityNumber = new Regex("IdentityNumber");
                //Regex DateTimeNow = new Regex("DateTimeNow");

                //docText = SpecialtyName.Replace(docText, user.Anketa.Specialty.Name);
                //docText = PostCode.Replace(docText, user.Anketa.Postcode);
                //docText = Area.Replace(docText, user.Anketa.Region);
                //docText = District.Replace(docText, user.Anketa.PlaceOfBirth);
                //docText = Town.Replace(docText, user.Anketa.NameOfSettlement);
                //docText = Street.Replace(docText, user.Anketa.StreetName);
                //docText = HomeNumber.Replace(docText, user.Anketa.HouseNumber);
                //docText = Apartment.Replace(docText, user.Anketa.ApartmentNumber);
                //docText = Phone.Replace(docText, user.Anketa.HomePhone);
                //docText = YearOfEnding.Replace(docText, user.Anketa.YearOfEnding);
                //docText = EducationLevel.Replace(docText, user.Anketa.EducationLevel);
                //docText = Institution.Replace(docText, user.Anketa.Institution);
                //docText = Birthday.Replace(docText, user.Anketa.Birthday);
                //docText = FatherFullName.Replace(docText, user.GetFullNameFather);
                //docText = FullName.Replace(docText, user.FullName);
                //docText = MotherFullName.Replace(docText, user.GetFullNameMother);
                //docText = DocumentType.Replace(docText, user.Anketa.DocumentType.Name);
                //docText = Passport.Replace(docText, user.Anketa.PassportNumber);
                //docText = DateOfIssue.Replace(docText, user.Anketa.DateOfIssue);
                //docText = IssuedBy.Replace(docText, user.Anketa.IssuedBy);
                //docText = IdentityNumber.Replace(docText, user.Anketa.IdentityNumber);
                //docText = DateTimeNow.Replace(docText, DateTime.Now.ToShortDateString());

                return File("", "");
            }
        }
    }
}
