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
    public class MainPlanController : Controller
    {
        private readonly ApplicationContext _context;

        public MainPlanController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: MainPlan
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.MainPlan.Include(m => m.AdmissionPlan).Include(m => m.Specialty);
            return View(await applicationContext.ToListAsync());
        }

        // GET: MainPlan/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mainPlan = await _context.MainPlan
                .Include(m => m.AdmissionPlan)
                .Include(m => m.Specialty)
                .FirstOrDefaultAsync(m => m.MainPlanId == id);
            if (mainPlan == null)
            {
                return NotFound();
            }

            return View(mainPlan);
        }

        // GET: MainPlan/Create
        public IActionResult Create()
        {
            ViewData["AdmissionPlanId"] = new SelectList(_context.AdmissionPlan, "AdmissionPlanId", "GetName");
            ViewData["SpecialtyId"] = new SelectList(_context.Specialties, "SpecialtyId", "Name");
            return View();
        }

        // POST: MainPlan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MainPlanId,SpecialtyId,AdmissionPlanId")] MainPlan mainPlan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mainPlan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdmissionPlanId"] = new SelectList(_context.AdmissionPlan, "AdmissionPlanId", "GetName", mainPlan.AdmissionPlanId);
            ViewData["SpecialtyId"] = new SelectList(_context.Specialties, "SpecialtyId", "Name", mainPlan.SpecialtyId);
            return View(mainPlan);
        }

        // GET: MainPlan/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mainPlan = await _context.MainPlan.FindAsync(id);
            if (mainPlan == null)
            {
                return NotFound();
            }
            ViewData["AdmissionPlanId"] = new SelectList(_context.AdmissionPlan, "AdmissionPlanId", "GetName", mainPlan.AdmissionPlanId);
            ViewData["SpecialtyId"] = new SelectList(_context.Specialties, "SpecialtyId", "Name", mainPlan.SpecialtyId);
            return View(mainPlan);
        }

        // POST: MainPlan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MainPlanId,SpecialtyId,AdmissionPlanId")] MainPlan mainPlan)
        {
            if (id != mainPlan.MainPlanId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mainPlan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MainPlanExists(mainPlan.MainPlanId))
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
            ViewData["AdmissionPlanId"] = new SelectList(_context.AdmissionPlan, "AdmissionPlanId", "GetName", mainPlan.AdmissionPlanId);
            ViewData["SpecialtyId"] = new SelectList(_context.Specialties, "SpecialtyId", "Name", mainPlan.SpecialtyId);
            return View(mainPlan);
        }

        // GET: MainPlan/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mainPlan = await _context.MainPlan
                .Include(m => m.AdmissionPlan)
                .Include(m => m.Specialty)
                .FirstOrDefaultAsync(m => m.MainPlanId == id);
            if (mainPlan == null)
            {
                return NotFound();
            }

            return View(mainPlan);
        }

        // POST: MainPlan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mainPlan = await _context.MainPlan.FindAsync(id);
            _context.MainPlan.Remove(mainPlan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MainPlanExists(int id)
        {
            return _context.MainPlan.Any(e => e.MainPlanId == id);
        }
    }
}
