using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentOffice.Helpers;
using StudentOffice.Models.DataBase;
using StudentOffice.ViewModels;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StudentOffice.Controllers
{
    [Authorize]
    public class AnketaController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly UserManager<User> _userManager;

        public AnketaController(ApplicationContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Anketa
        public async Task<IActionResult> Index()
        {
            var anketa = _context.Anketas.Include(a => a.DocumentType).Include(a => a.Specialty);
            return View(await anketa.ToListAsync());
        }

        // GET: Anketa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anketa = await _context.Anketas
                .Include(a => a.DocumentType)
                .Include(a => a.Specialty)
                .FirstOrDefaultAsync(m => m.AnketaId == id);
            if (anketa == null)
            {
                return NotFound();
            }

            return View(anketa);
        }

        //GET: Anketa/Create
        public IActionResult Create()
        {
            ViewData["DocumentTypeId"] = new SelectList(_context.DocumentTypes, "DocumentTypeId", "Name");
            ViewData["SpecialtyId"] = new SelectList(_context.Specialties, "SpecialtyId", "GetSpecialtyNameBranch");
            return View();
        }

        //POST: Anketa/Create
        //To protect from overposting attacks, enable the specific properties you want to bind to.
        //For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AnketaId,Surname,Name,Middlename,SurnameR,NameR,MiddlenameR,Birthday,Sex,IdentityNumber,PassportSeries,PassportNumber,DateOfIssue,DateOfValidity,IssuedBy,PlaceOfBirth,Postcode,Region,TypeOfSettlement,NameOfSettlement,StreetType,StreetName,HouseNumber,HullNumber,ApartmentNumber,HomePhone,SocialBehavior,KinshipTypeFather,SurnameFather,NameFather,MiddlenameFather,AddressFather,KinshipTypeMother,SurnameMother,NameMother,MiddlenameMother,AddressMother,EducationLevel,Institution,YearOfEnding,PlaceOfWorkAndPosition,SeniorityGeneral,SeniorityProfileSpecialty,SpecialtyId,DocumentTypeId")] Anketa anketa)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);

                if (user == null)
                {
                    return NotFound("Пользователь не найден");
                }

                await _context.AddAsync(anketa);
                await _context.SaveChangesAsync();

                user.AnketaId = anketa.AnketaId;
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DocumentTypeId"] = new SelectList(_context.DocumentTypes, "DocumentTypeId", "Name", anketa.DocumentTypeId);
            ViewData["SpecialtyId"] = new SelectList(_context.Specialties, "SpecialtyId", "GetSpecialtyNameBranch", anketa.SpecialtyId);
            return View(anketa);
        }
        [HttpGet]
        public async Task<IActionResult> AddOrEdit()
        {
            ViewData["DocumentTypeId"] = new SelectList(_context.DocumentTypes, "DocumentTypeId", "Name");

            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (user?.AnketaId == null)
            {
                return View(new AnketaViewModel());
            }
            else
            {
                var anketa = await _context.Anketas.Include(i => i.Specialty).FirstOrDefaultAsync(i => i.AnketaId == user.AnketaId);

                if (anketa == null)
                {
                    return NotFound("Анкета не найдена");
                }

                if (EnumHelper<Branch>.GetDisplayValue(anketa.Specialty.Branch) == "Дневное")
                {
                    ViewData["SpecialtyId"] = new SelectList(_context.Specialties.Where(i => i.Branch == Branch.Daytime).ToList(), "SpecialtyId", "Name", Branch.Daytime);
                }
                else
                if (EnumHelper<Branch>.GetDisplayValue(anketa.Specialty.Branch) == "Заочное")
                {
                    ViewData["SpecialtyId"] = new SelectList(_context.Specialties.Where(i => i.Branch == Branch.Correspondence).ToList(), "SpecialtyId", "Name", Branch.Correspondence);
                }

                ViewData["BranchId"] = new SelectList(Enum.GetNames(typeof(Branch)), "2");

                AnketaViewModel anketaViewModel = new AnketaViewModel();

                anketaViewModel.AnketaId = anketa.AnketaId;
                anketaViewModel.AddressFather = anketa.AddressFather;
                anketaViewModel.AddressMother = anketa.AddressMother;
                anketaViewModel.ApartmentNumber = anketa.ApartmentNumber;
                anketaViewModel.Birthday = anketa.Birthday;
                anketaViewModel.DateOfIssue = anketa.DateOfIssue;
                anketaViewModel.DateOfValidity = anketa.DateOfValidity;
                anketaViewModel.DocumentTypeId = anketa.DocumentTypeId;
                anketaViewModel.EducationLevel = anketa.EducationLevel;
                anketaViewModel.HomePhone = anketa.HomePhone;
                anketaViewModel.HouseNumber = anketa.HouseNumber;
                anketaViewModel.HullNumber = anketa.HullNumber;
                anketaViewModel.IdentityNumber = anketa.IdentityNumber;
                anketaViewModel.Institution = anketa.Institution;
                anketaViewModel.IssuedBy = anketa.IssuedBy;
                anketaViewModel.KinshipTypeFather = anketa.KinshipTypeFather;
                anketaViewModel.KinshipTypeMother = anketa.KinshipTypeMother;
                anketaViewModel.Middlename = anketa.Middlename;
                anketaViewModel.MiddlenameFather = anketa.MiddlenameFather;
                anketaViewModel.MiddlenameMother = anketa.MiddlenameMother;
                anketaViewModel.MiddlenameR = anketa.MiddlenameR;
                anketaViewModel.Name = anketa.Name;
                anketaViewModel.NameFather = anketa.NameFather;
                anketaViewModel.NameMother = anketa.NameMother;
                anketaViewModel.NameOfSettlement = anketa.NameOfSettlement;
                anketaViewModel.NameR = anketa.NameR;
                anketaViewModel.PassportNumber = anketa.PassportNumber;
                anketaViewModel.PassportSeries = anketa.PassportSeries;
                anketaViewModel.PlaceOfBirth = anketa.PlaceOfBirth;
                anketaViewModel.PlaceOfWorkAndPosition = anketa.PlaceOfWorkAndPosition;
                anketaViewModel.Postcode = anketa.Postcode;
                anketaViewModel.Region = anketa.Region;
                anketaViewModel.SeniorityGeneral = anketa.SeniorityGeneral;
                anketaViewModel.SeniorityProfileSpecialty = anketa.SeniorityProfileSpecialty;
                anketaViewModel.Sex = anketa.Sex;
                anketaViewModel.SocialBehavior = anketa.SocialBehavior;
                anketaViewModel.SpecialtyId = anketa.SpecialtyId;
                anketaViewModel.StreetName = anketa.StreetName;
                anketaViewModel.StreetType = anketa.StreetType;
                anketaViewModel.Surname = anketa.Surname;
                anketaViewModel.SurnameFather = anketa.SurnameFather;
                anketaViewModel.SurnameMother = anketa.SurnameMother;
                anketaViewModel.SurnameR = anketa.SurnameR;
                anketaViewModel.TypeOfSettlement = anketa.TypeOfSettlement;
                anketaViewModel.YearOfEnding = anketa.YearOfEnding;
                anketaViewModel.Branch = anketa.Specialty.Branch;

                return View(anketaViewModel);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("AnketaId,Surname,Name,Middlename,SurnameR,NameR,MiddlenameR,Birthday,Sex,IdentityNumber,PassportSeries,PassportNumber,DateOfIssue,DateOfValidity,IssuedBy,PlaceOfBirth,Postcode,Region,TypeOfSettlement,NameOfSettlement,StreetType,StreetName,HouseNumber,HullNumber,ApartmentNumber,HomePhone,SocialBehavior,KinshipTypeFather,SurnameFather,NameFather,MiddlenameFather,AddressFather,KinshipTypeMother,SurnameMother,NameMother,MiddlenameMother,AddressMother,EducationLevel,Institution,YearOfEnding,PlaceOfWorkAndPosition,SeniorityGeneral,SeniorityProfileSpecialty,SpecialtyId,DocumentTypeId,XeracopyPassportFirst,XeracopyPassportSecond,Registration,CertificateFirst,CertificateSecond,MedicalCertificateFirst,MedicalCertificateSecond")] AnketaViewModel anketaViewModel)
        {

            if (ModelState.IsValid)
            {

                if (id == 0)
                {
                    Anketa anketa = new Anketa();

                    var user = await _userManager.FindByNameAsync(User.Identity.Name);

                    if (user == null)
                    {
                        return NotFound("Пользователь не найден");
                    }

                    #region MyRegion


                    if (anketaViewModel.XeracopyPassportFirst != null)
                    {
                        byte[] imageData = null;

                        using (var binaryReader = new BinaryReader(anketaViewModel.XeracopyPassportFirst.OpenReadStream()))
                        {
                            imageData = binaryReader.ReadBytes((int)anketaViewModel.XeracopyPassportFirst.Length);
                        }
                        // установка массива байтов
                        anketaViewModel.XeracopyPassportFirstHash = imageData;
                    }

                    if (anketaViewModel.XeracopyPassportSecond != null)
                    {
                        byte[] imageData = null;

                        using (var binaryReader = new BinaryReader(anketaViewModel.XeracopyPassportSecond.OpenReadStream()))
                        {
                            imageData = binaryReader.ReadBytes((int)anketaViewModel.XeracopyPassportSecond.Length);
                        }
                        // установка массива байтов
                        anketaViewModel.XeracopyPassportSecondHash = imageData;
                    }

                    if (anketaViewModel.Registration != null)
                    {
                        byte[] imageData = null;

                        using (var binaryReader = new BinaryReader(anketaViewModel.Registration.OpenReadStream()))
                        {
                            imageData = binaryReader.ReadBytes((int)anketaViewModel.Registration.Length);
                        }
                        // установка массива байтов
                        anketaViewModel.RegistrationHash = imageData;
                    }

                    if (anketaViewModel.CertificateFirst != null)
                    {
                        byte[] imageData = null;

                        using (var binaryReader = new BinaryReader(anketaViewModel.CertificateFirst.OpenReadStream()))
                        {
                            imageData = binaryReader.ReadBytes((int)anketaViewModel.CertificateFirst.Length);
                        }
                        // установка массива байтов
                        anketaViewModel.CertificateFirstHash = imageData;
                    }

                    if (anketaViewModel.CertificateSecond != null)
                    {
                        byte[] imageData = null;

                        using (var binaryReader = new BinaryReader(anketaViewModel.CertificateSecond.OpenReadStream()))
                        {
                            imageData = binaryReader.ReadBytes((int)anketaViewModel.CertificateSecond.Length);
                        }
                        // установка массива байтов
                        anketaViewModel.CertificateSecondHash = imageData;
                    }

                    if (anketaViewModel.MedicalCertificateFirst != null)
                    {
                        byte[] imageData = null;

                        using (var binaryReader = new BinaryReader(anketaViewModel.MedicalCertificateFirst.OpenReadStream()))
                        {
                            imageData = binaryReader.ReadBytes((int)anketaViewModel.MedicalCertificateFirst.Length);
                        }
                        // установка массива байтов
                        anketaViewModel.MedicalCertificateFirstHash = imageData;
                    }

                    if (anketaViewModel.MedicalCertificateSecond != null)
                    {
                        byte[] imageData = null;

                        using (var binaryReader = new BinaryReader(anketaViewModel.MedicalCertificateSecond.OpenReadStream()))
                        {
                            imageData = binaryReader.ReadBytes((int)anketaViewModel.MedicalCertificateSecond.Length);
                        }
                        // установка массива байтов
                        anketaViewModel.MedicalCertificateSecondHash = imageData;
                    }

                    anketa.AddressFather = anketaViewModel.AddressFather;
                    anketa.AddressMother = anketaViewModel.AddressMother;
                    anketa.ApartmentNumber = anketaViewModel.ApartmentNumber;
                    anketa.Birthday = anketaViewModel.Birthday;
                    anketa.CertificateFirstHash = anketaViewModel.CertificateFirstHash;
                    anketa.CertificateSecondHash = anketaViewModel.CertificateSecondHash;
                    anketa.DateOfIssue = anketaViewModel.DateOfIssue;
                    anketa.DateOfValidity = anketaViewModel.DateOfValidity;
                    anketa.DocumentTypeId = anketaViewModel.DocumentTypeId;
                    anketa.EducationLevel = anketaViewModel.EducationLevel;
                    anketa.HomePhone = anketaViewModel.HomePhone;
                    anketa.HouseNumber = anketaViewModel.HouseNumber;
                    anketa.HullNumber = anketaViewModel.HullNumber;
                    anketa.IdentityNumber = anketaViewModel.IdentityNumber;
                    anketa.Institution = anketaViewModel.Institution;
                    anketa.IssuedBy = anketaViewModel.IssuedBy;
                    anketa.KinshipTypeFather = anketaViewModel.KinshipTypeFather;
                    anketa.KinshipTypeMother = anketaViewModel.KinshipTypeMother;
                    anketa.MedicalCertificateFirstHash = anketaViewModel.MedicalCertificateFirstHash;
                    anketa.MedicalCertificateSecondHash = anketaViewModel.MedicalCertificateSecondHash;
                    anketa.Middlename = anketaViewModel.Middlename;
                    anketa.MiddlenameFather = anketaViewModel.MiddlenameFather;
                    anketa.MiddlenameMother = anketaViewModel.MiddlenameMother;
                    anketa.MiddlenameR = anketaViewModel.MiddlenameR;
                    anketa.Name = anketaViewModel.Name;
                    anketa.NameFather = anketaViewModel.NameFather;
                    anketa.NameMother = anketaViewModel.NameMother;
                    anketa.NameOfSettlement = anketaViewModel.NameOfSettlement;
                    anketa.NameR = anketaViewModel.NameR;
                    anketa.PassportNumber = anketaViewModel.PassportNumber;
                    anketa.PassportSeries = anketaViewModel.PassportSeries;
                    anketa.PlaceOfBirth = anketaViewModel.PlaceOfBirth;
                    anketa.PlaceOfWorkAndPosition = anketaViewModel.PlaceOfWorkAndPosition;
                    anketa.Postcode = anketaViewModel.Postcode;
                    anketa.Region = anketaViewModel.Region;
                    anketa.RegistrationHash = anketaViewModel.RegistrationHash;
                    anketa.SeniorityGeneral = anketaViewModel.SeniorityGeneral;
                    anketa.SeniorityProfileSpecialty = anketaViewModel.SeniorityProfileSpecialty;
                    anketa.Sex = anketaViewModel.Sex;
                    anketa.SocialBehavior = anketaViewModel.SocialBehavior;
                    anketa.SpecialtyId = anketaViewModel.SpecialtyId;
                    anketa.StreetName = anketaViewModel.StreetName;
                    anketa.StreetType = anketaViewModel.StreetType;
                    anketa.Surname = anketaViewModel.Surname;
                    anketa.SurnameFather = anketaViewModel.SurnameFather;
                    anketa.SurnameMother = anketaViewModel.SurnameMother;
                    anketa.SurnameR = anketaViewModel.SurnameR;
                    anketa.TypeOfSettlement = anketaViewModel.TypeOfSettlement;
                    anketa.XeracopyPassportFirstHash = anketaViewModel.XeracopyPassportFirstHash;
                    anketa.XeracopyPassportSecondHash = anketaViewModel.XeracopyPassportSecondHash;
                    anketa.YearOfEnding = anketaViewModel.YearOfEnding;
                    #endregion

                    await _context.AddAsync(anketa);
                    await _context.SaveChangesAsync();

                    user.AnketaId = anketa.AnketaId;
                    _context.Users.Update(user);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    try
                    {
                        #region MyRegion

                        Anketa anketa = await _context.Anketas.FindAsync(id);

                        if (anketaViewModel.XeracopyPassportFirst != null)
                        {
                            byte[] imageData = null;

                            using (var binaryReader = new BinaryReader(anketaViewModel.XeracopyPassportFirst.OpenReadStream()))
                            {
                                imageData = binaryReader.ReadBytes((int)anketaViewModel.XeracopyPassportFirst.Length);
                            }
                            // установка массива байтов
                            anketa.XeracopyPassportFirstHash = imageData;
                        }


                        if (anketaViewModel.XeracopyPassportSecond != null)
                        {
                            byte[] imageData = null;

                            using (var binaryReader = new BinaryReader(anketaViewModel.XeracopyPassportSecond.OpenReadStream()))
                            {
                                imageData = binaryReader.ReadBytes((int)anketaViewModel.XeracopyPassportSecond.Length);
                            }
                            // установка массива байтов
                            anketa.XeracopyPassportSecondHash = imageData;
                        }


                        if (anketaViewModel.Registration != null)
                        {
                            byte[] imageData = null;

                            using (var binaryReader = new BinaryReader(anketaViewModel.Registration.OpenReadStream()))
                            {
                                imageData = binaryReader.ReadBytes((int)anketaViewModel.Registration.Length);
                            }
                            // установка массива байтов
                            anketa.RegistrationHash = imageData;
                        }


                        if (anketaViewModel.CertificateFirst != null)
                        {
                            byte[] imageData = null;

                            using (var binaryReader = new BinaryReader(anketaViewModel.CertificateFirst.OpenReadStream()))
                            {
                                imageData = binaryReader.ReadBytes((int)anketaViewModel.CertificateFirst.Length);
                            }
                            // установка массива байтов
                            anketa.CertificateFirstHash = imageData;
                        }


                        if (anketaViewModel.CertificateSecond != null)
                        {
                            byte[] imageData = null;

                            using (var binaryReader = new BinaryReader(anketaViewModel.CertificateSecond.OpenReadStream()))
                            {
                                imageData = binaryReader.ReadBytes((int)anketaViewModel.CertificateSecond.Length);
                            }
                            // установка массива байтов
                            anketa.CertificateSecondHash = imageData;
                        }


                        if (anketaViewModel.MedicalCertificateFirst != null)
                        {
                            byte[] imageData = null;

                            using (var binaryReader = new BinaryReader(anketaViewModel.MedicalCertificateFirst.OpenReadStream()))
                            {
                                imageData = binaryReader.ReadBytes((int)anketaViewModel.MedicalCertificateFirst.Length);
                            }
                            // установка массива байтов
                            anketa.MedicalCertificateFirstHash = imageData;
                        }


                        if (anketaViewModel.MedicalCertificateSecond != null)
                        {
                            byte[] imageData = null;

                            using (var binaryReader = new BinaryReader(anketaViewModel.MedicalCertificateSecond.OpenReadStream()))
                            {
                                imageData = binaryReader.ReadBytes((int)anketaViewModel.MedicalCertificateSecond.Length);
                            }
                            // установка массива байтов
                            anketa.MedicalCertificateSecondHash = imageData;
                        }

                        anketa.AddressFather = anketaViewModel.AddressFather;
                        anketa.AddressMother = anketaViewModel.AddressMother;
                        anketa.ApartmentNumber = anketaViewModel.ApartmentNumber;
                        anketa.Birthday = anketaViewModel.Birthday;
                        anketa.DateOfIssue = anketaViewModel.DateOfIssue;
                        anketa.DateOfValidity = anketaViewModel.DateOfValidity;
                        anketa.DocumentTypeId = anketaViewModel.DocumentTypeId;
                        anketa.EducationLevel = anketaViewModel.EducationLevel;
                        anketa.HomePhone = anketaViewModel.HomePhone;
                        anketa.HouseNumber = anketaViewModel.HouseNumber;
                        anketa.HullNumber = anketaViewModel.HullNumber;
                        anketa.IdentityNumber = anketaViewModel.IdentityNumber;
                        anketa.Institution = anketaViewModel.Institution;
                        anketa.IssuedBy = anketaViewModel.IssuedBy;
                        anketa.KinshipTypeFather = anketaViewModel.KinshipTypeFather;
                        anketa.KinshipTypeMother = anketaViewModel.KinshipTypeMother;
                        anketa.Middlename = anketaViewModel.Middlename;
                        anketa.MiddlenameFather = anketaViewModel.MiddlenameFather;
                        anketa.MiddlenameMother = anketaViewModel.MiddlenameMother;
                        anketa.MiddlenameR = anketaViewModel.MiddlenameR;
                        anketa.Name = anketaViewModel.Name;
                        anketa.NameFather = anketaViewModel.NameFather;
                        anketa.NameMother = anketaViewModel.NameMother;
                        anketa.NameOfSettlement = anketaViewModel.NameOfSettlement;
                        anketa.NameR = anketaViewModel.NameR;
                        anketa.PassportNumber = anketaViewModel.PassportNumber;
                        anketa.PassportSeries = anketaViewModel.PassportSeries;
                        anketa.PlaceOfBirth = anketaViewModel.PlaceOfBirth;
                        anketa.PlaceOfWorkAndPosition = anketaViewModel.PlaceOfWorkAndPosition;
                        anketa.Postcode = anketaViewModel.Postcode;
                        anketa.Region = anketaViewModel.Region;
                        anketa.SeniorityGeneral = anketaViewModel.SeniorityGeneral;
                        anketa.SeniorityProfileSpecialty = anketaViewModel.SeniorityProfileSpecialty;
                        anketa.Sex = anketaViewModel.Sex;
                        anketa.SocialBehavior = anketaViewModel.SocialBehavior;
                        anketa.SpecialtyId = anketaViewModel.SpecialtyId;
                        anketa.StreetName = anketaViewModel.StreetName;
                        anketa.StreetType = anketaViewModel.StreetType;
                        anketa.Surname = anketaViewModel.Surname;
                        anketa.SurnameFather = anketaViewModel.SurnameFather;
                        anketa.SurnameMother = anketaViewModel.SurnameMother;
                        anketa.SurnameR = anketaViewModel.SurnameR;
                        anketa.TypeOfSettlement = anketaViewModel.TypeOfSettlement;
                        anketa.YearOfEnding = anketaViewModel.YearOfEnding;

                        #endregion

                        _context.Anketas.Update(anketa);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!AnketaExists(anketaViewModel.AnketaId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }

                return RedirectToAction("Index", "Home");
            }
            ViewData["DocumentTypeId"] = new SelectList(_context.DocumentTypes, "DocumentTypeId", "Name", anketaViewModel.DocumentTypeId);
            //ViewData["SpecialtyId"] = new SelectList(_context.Specialties, "SpecialtyId", "GetSpecialtyNameBranch", anketa.SpecialtyId);
            return View(anketaViewModel);
        }

        // GET: Anketa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anketa = await _context.Anketas.FindAsync(id);
            if (anketa == null)
            {
                return NotFound();
            }
            ViewData["DocumentTypeId"] = new SelectList(_context.DocumentTypes, "DocumentTypeId", "Name", anketa.DocumentTypeId);
            ViewData["SpecialtyId"] = new SelectList(_context.Specialties, "SpecialtyId", "GetSpecialtyNameBranch", anketa.SpecialtyId);
            return View(anketa);
        }

        // POST: Anketa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AnketaId,Surname,Name,Middlename,SurnameR,NameR,MiddlenameR,Birthday,Sex,IdentityNumber,PassportSeries,PassportNumber,DateOfIssue,DateOfValidity,IssuedBy,PlaceOfBirth,Postcode,Region,TypeOfSettlement,NameOfSettlement,StreetType,StreetName,HouseNumber,HullNumber,ApartmentNumber,HomePhone,SocialBehavior,KinshipTypeFather,SurnameFather,NameFather,MiddlenameFather,AddressFather,KinshipTypeMother,SurnameMother,NameMother,MiddlenameMother,AddressMother,EducationLevel,Institution,YearOfEnding,PlaceOfWorkAndPosition,SeniorityGeneral,SeniorityProfileSpecialty,SpecialtyId,DocumentTypeId")] Anketa anketa)
        {
            if (id != anketa.AnketaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anketa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnketaExists(anketa.AnketaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DocumentTypeId"] = new SelectList(_context.DocumentTypes, "DocumentTypeId", "Name", anketa.DocumentTypeId);
            ViewData["SpecialtyId"] = new SelectList(_context.Specialties, "SpecialtyId", "GetSpecialtyNameBranch", anketa.SpecialtyId);
            return View(anketa);
        }

        // GET: Anketa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anketa = await _context.Anketas
                .Include(a => a.DocumentType)
                .Include(a => a.Specialty)
                .FirstOrDefaultAsync(m => m.AnketaId == id);
            if (anketa == null)
            {
                return NotFound();
            }

            return View(anketa);
        }

        // POST: Anketa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var anketa = await _context.Anketas.FindAsync(id);
            _context.Anketas.Remove(anketa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnketaExists(int id)
        {
            return _context.Anketas.Any(e => e.AnketaId == id);
        }
    }
}
