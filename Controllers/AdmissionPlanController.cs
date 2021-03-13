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
    public class AdmissionPlanController : Controller
    {
        private readonly ApplicationContext _context;

        public AdmissionPlanController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: AdmissionPlan
        public async Task<IActionResult> Index()
        {
            var admissionPlans = _context.AdmissionPlan.Include(a => a.SelectionСommittee);
            return View(await admissionPlans.ToListAsync());
        }

        // GET: AdmissionPlan/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admissionPlan = await _context.AdmissionPlan
                .Include(a => a.SelectionСommittee)
                .FirstOrDefaultAsync(m => m.AdmissionPlanId == id);
            if (admissionPlan == null)
            {
                return NotFound();
            }

            return View(admissionPlan);
        }

        // GET: AdmissionPlan/Create
        public IActionResult Create()
        {
            ViewData["SelectionСommitteeId"] = new SelectList(_context.SelectionСommittee, "SelectionСommitteeId", "Name");
            return View();
        }

        // POST: AdmissionPlan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AdmissionPlanId,TypeAdmission,DateStart,DateEnd,SelectionСommitteeId")] AdmissionPlan admissionPlan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(admissionPlan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SelectionСommitteeId"] = new SelectList(_context.SelectionСommittee, "SelectionСommitteeId", "Name", admissionPlan.SelectionСommitteeId);
            return View(admissionPlan);
        }

        // GET: AdmissionPlan/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admissionPlan = await _context.AdmissionPlan.FindAsync(id);
            if (admissionPlan == null)
            {
                return NotFound();
            }
            ViewData["SelectionСommitteeId"] = new SelectList(_context.SelectionСommittee, "SelectionСommitteeId", "Name", admissionPlan.SelectionСommitteeId);
            return View(admissionPlan);
        }

        // POST: AdmissionPlan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AdmissionPlanId,TypeAdmission,DateStart,DateEnd,SelectionСommitteeId")] AdmissionPlan admissionPlan)
        {
            if (id != admissionPlan.AdmissionPlanId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(admissionPlan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdmissionPlanExists(admissionPlan.AdmissionPlanId))
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
            ViewData["SelectionСommitteeId"] = new SelectList(_context.SelectionСommittee, "SelectionСommitteeId", "Name", admissionPlan.SelectionСommitteeId);
            return View(admissionPlan);
        }

        // GET: AdmissionPlan/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admissionPlan = await _context.AdmissionPlan
                .Include(a => a.SelectionСommittee)
                .FirstOrDefaultAsync(m => m.AdmissionPlanId == id);
            if (admissionPlan == null)
            {
                return NotFound();
            }

            return View(admissionPlan);
        }

        // POST: AdmissionPlan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var admissionPlan = await _context.AdmissionPlan.FindAsync(id);
            _context.AdmissionPlan.Remove(admissionPlan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdmissionPlanExists(int id)
        {
            return _context.AdmissionPlan.Any(e => e.AdmissionPlanId == id);
        }
    }
}
