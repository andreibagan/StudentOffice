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
    public class AudienceController : Controller
    {
        private readonly ApplicationContext _context;

        public AudienceController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Audience
        public async Task<IActionResult> Index()
        {
            return View(await _context.Audiences.ToListAsync());
        }

        // GET: Audience/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var audience = await _context.Audiences
                .FirstOrDefaultAsync(m => m.AudienceId == id);
            if (audience == null)
            {
                return NotFound();
            }

            return View(audience);
        }

        // GET: Audience/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Audience/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AudienceId,AudienceName,AudienceNameShort,AudienceType")] Audience audience)
        {
            if (ModelState.IsValid)
            {
                _context.Add(audience);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(audience);
        }

        // GET: Audience/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var audience = await _context.Audiences.FindAsync(id);
            if (audience == null)
            {
                return NotFound();
            }
            return View(audience);
        }

        // POST: Audience/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AudienceId,AudienceName,AudienceNameShort,AudienceType")] Audience audience)
        {
            if (id != audience.AudienceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(audience);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AudienceExists(audience.AudienceId))
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
            return View(audience);
        }

        // GET: Audience/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var audience = await _context.Audiences
                .FirstOrDefaultAsync(m => m.AudienceId == id);
            if (audience == null)
            {
                return NotFound();
            }

            return View(audience);
        }

        // POST: Audience/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var audience = await _context.Audiences.FindAsync(id);
            _context.Audiences.Remove(audience);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AudienceExists(int id)
        {
            return _context.Audiences.Any(e => e.AudienceId == id);
        }
    }
}
