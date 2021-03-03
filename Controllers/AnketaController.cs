using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentOffice.Models.DataBase;

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
            ViewData["SpecialtyId"] = new SelectList(_context.Specialties, "SpecialtyId", "GetSpecialtyNameBranch");

            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (user?.AnketaId == null)
            {
                return View(new Anketa());
            }
            else
            {
                var anketa = await _context.Anketas.FindAsync(user.AnketaId);

                if (anketa == null)
                {
                    return NotFound("Анкета не найдена");
                }
                return View(anketa);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("AnketaId,Surname,Name,Middlename,SurnameR,NameR,MiddlenameR,Birthday,Sex,IdentityNumber,PassportSeries,PassportNumber,DateOfIssue,DateOfValidity,IssuedBy,PlaceOfBirth,Postcode,Region,TypeOfSettlement,NameOfSettlement,StreetType,StreetName,HouseNumber,HullNumber,ApartmentNumber,HomePhone,SocialBehavior,KinshipTypeFather,SurnameFather,NameFather,MiddlenameFather,AddressFather,KinshipTypeMother,SurnameMother,NameMother,MiddlenameMother,AddressMother,EducationLevel,Institution,YearOfEnding,PlaceOfWorkAndPosition,SeniorityGeneral,SeniorityProfileSpecialty,SpecialtyId,DocumentTypeId")] Anketa anketa)
        {

            if (ModelState.IsValid)
            {
                if (id == 0)
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
                }
                else
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
                }
                
                return RedirectToAction("Index", "Home");
            }
            ViewData["DocumentTypeId"] = new SelectList(_context.DocumentTypes, "DocumentTypeId", "Name", anketa.DocumentTypeId);
            ViewData["SpecialtyId"] = new SelectList(_context.Specialties, "SpecialtyId", "GetSpecialtyNameBranch", anketa.SpecialtyId);
            return View(anketa);
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
