using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentOffice.Models.DataBase;

namespace StudentOffice.Controllers
{
    public class SpecialtyController : Controller
    {
        private readonly ApplicationContext _context;

        public SpecialtyController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Specialty
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.Specialties.Include(s => s.Group).Include(s => s.Specialization);
            return View(await applicationContext.ToListAsync());
        }

        // GET: Specialty/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialty = await _context.Specialties
                .Include(s => s.Group)
                .Include(s => s.Specialization)
                .FirstOrDefaultAsync(m => m.SpecialtyId == id);
            if (specialty == null)
            {
                return NotFound();
            }

            return View(specialty);
        }

        // GET: Specialty/Create
        public IActionResult Create()
        {
            ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "GroupName");
            ViewData["SpecializationId"] = new SelectList(_context.Specializations, "SpecializationId", "SpecializationName");
            return View();
        }

        // POST: Specialty/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SpecialtyId,Name,EducationType,Branch,GroupId,SpecializationId")] Specialty specialty)
        {
            if (ModelState.IsValid)
            {
                _context.Add(specialty);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "GroupName", specialty.GroupId);
            ViewData["SpecializationId"] = new SelectList(_context.Specializations, "SpecializationId", "SpecializationName", specialty.SpecializationId);
            return View(specialty);
        }

        // GET: Specialty/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialty = await _context.Specialties.FindAsync(id);
            if (specialty == null)
            {
                return NotFound();
            }
            ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "GroupName", specialty.GroupId);
            ViewData["SpecializationId"] = new SelectList(_context.Specializations, "SpecializationId", "SpecializationName", specialty.SpecializationId);
            return View(specialty);
        }

        // POST: Specialty/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SpecialtyId,Name,EducationType,Branch,GroupId,SpecializationId")] Specialty specialty)
        {
            if (id != specialty.SpecialtyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(specialty);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpecialtyExists(specialty.SpecialtyId))
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
            ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "GroupName", specialty.GroupId);
            ViewData["SpecializationId"] = new SelectList(_context.Specializations, "SpecializationId", "SpecializationName", specialty.SpecializationId);
            return View(specialty);
        }

        // GET: Specialty/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialty = await _context.Specialties
                .Include(s => s.Group)
                .Include(s => s.Specialization)
                .FirstOrDefaultAsync(m => m.SpecialtyId == id);
            if (specialty == null)
            {
                return NotFound();
            }

            return View(specialty);
        }

        // POST: Specialty/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var specialty = await _context.Specialties.FindAsync(id);
            _context.Specialties.Remove(specialty);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpecialtyExists(int id)
        {
            return _context.Specialties.Any(e => e.SpecialtyId == id);
        }
    }
}
