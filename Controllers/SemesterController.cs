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
    public class SemesterController : Controller
    {
        private readonly ApplicationContext _context;

        public SemesterController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Semester
        public async Task<IActionResult> Index()
        {
            return View(await _context.Semesters.ToListAsync());
        }

        // GET: Semester/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var semester = await _context.Semesters
                .FirstOrDefaultAsync(m => m.SemesterId == id);
            if (semester == null)
            {
                return NotFound();
            }

            return View(semester);
        }

        // GET: Semester/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Semester/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SemesterId,SemesterNumber")] Semester semester)
        {
            if (ModelState.IsValid)
            {
                _context.Add(semester);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(semester);
        }

        // GET: Semester/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var semester = await _context.Semesters.FindAsync(id);
            if (semester == null)
            {
                return NotFound();
            }
            return View(semester);
        }

        // POST: Semester/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SemesterId,SemesterNumber")] Semester semester)
        {
            if (id != semester.SemesterId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(semester);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SemesterExists(semester.SemesterId))
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
            return View(semester);
        }

        // GET: Semester/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var semester = await _context.Semesters
                .FirstOrDefaultAsync(m => m.SemesterId == id);
            if (semester == null)
            {
                return NotFound();
            }

            return View(semester);
        }

        // POST: Semester/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var semester = await _context.Semesters.FindAsync(id);
            _context.Semesters.Remove(semester);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SemesterExists(int id)
        {
            return _context.Semesters.Any(e => e.SemesterId == id);
        }
    }
}
