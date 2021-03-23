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
    public class SelectionСommitteeController : Controller
    {
        private readonly ApplicationContext _context;

        public SelectionСommitteeController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: SelectionСommittee
        public async Task<IActionResult> Index()
        {
            return View(await _context.SelectionСommitties.ToListAsync());
        }

        // GET: SelectionСommittee/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var selectionСommittee = await _context.SelectionСommitties
                .FirstOrDefaultAsync(m => m.SelectionСommitteeId == id);
            if (selectionСommittee == null)
            {
                return NotFound();
            }

            return View(selectionСommittee);
        }

        // GET: SelectionСommittee/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SelectionСommittee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SelectionСommitteeId,Name,Year,DateStart,DateEnd")] SelectionСommittee selectionСommittee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(selectionСommittee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(selectionСommittee);
        }

        // GET: SelectionСommittee/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var selectionСommittee = await _context.SelectionСommitties.FindAsync(id);
            if (selectionСommittee == null)
            {
                return NotFound();
            }
            return View(selectionСommittee);
        }

        // POST: SelectionСommittee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SelectionСommitteeId,Name,Year,DateStart,DateEnd")] SelectionСommittee selectionСommittee)
        {
            if (id != selectionСommittee.SelectionСommitteeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(selectionСommittee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SelectionСommitteeExists(selectionСommittee.SelectionСommitteeId))
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
            return View(selectionСommittee);
        }

        // GET: SelectionСommittee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var selectionСommittee = await _context.SelectionСommitties
                .FirstOrDefaultAsync(m => m.SelectionСommitteeId == id);
            if (selectionСommittee == null)
            {
                return NotFound();
            }

            return View(selectionСommittee);
        }

        // POST: SelectionСommittee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var selectionСommittee = await _context.SelectionСommitties.FindAsync(id);
            _context.SelectionСommitties.Remove(selectionСommittee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SelectionСommitteeExists(int id)
        {
            return _context.SelectionСommitties.Any(e => e.SelectionСommitteeId == id);
        }
    }
}
