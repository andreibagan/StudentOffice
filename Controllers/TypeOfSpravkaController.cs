using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentOffice.Helpers;
using StudentOffice.Models.DataBase;
using System.Linq;
using System.Threading.Tasks;

namespace StudentOffice.Controllers
{
    public class TypeOfSpravkaController : Controller
    {
        private readonly ApplicationContext _context;

        public TypeOfSpravkaController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: TypeOfSpravka
        public async Task<IActionResult> Index()
        {
            return View(await _context.TypeOfSpravkas.ToListAsync());
        }

        // GET: TypeOfSpravka/AddOrEdit
        // GET: TypeOfSpravka/AddOrEdit/2
        //[NoDirectAccess]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new TypeOfSpravka());
            }
            else
            {
                var typeOfSpravka = await _context.TypeOfSpravkas.FindAsync(id);
                if (typeOfSpravka == null)
                {
                    return NotFound();
                }
                return View(typeOfSpravka);
            }

        }

        // POST: TypeOfSpravka/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("TypeOfSpravkaId,TypeOfSpravkaName")] TypeOfSpravka typeOfSpravka)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    _context.Add(typeOfSpravka);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    try
                    {
                        _context.Update(typeOfSpravka);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TypeOfSpravkaExists(typeOfSpravka.TypeOfSpravkaId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }

                return Json(new { isValid = true, html = RazorViewHelper.RenderRazorViewToString(this, "_ViewAll", _context.TypeOfSpravkas.ToList()) });
            }
            return Json(new { isValid = false, html = RazorViewHelper.RenderRazorViewToString(this, "AddOrEdit", typeOfSpravka) });
        }


        // POST: TypeOfSpravka/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var typeOfSpravka = await _context.TypeOfSpravkas.FindAsync(id);
            _context.TypeOfSpravkas.Remove(typeOfSpravka);
            await _context.SaveChangesAsync();
            return Json(new { html = RazorViewHelper.RenderRazorViewToString(this, "_ViewAll", _context.TypeOfSpravkas.ToList()) });
        }

        private bool TypeOfSpravkaExists(int id)
        {
            return _context.TypeOfSpravkas.Any(e => e.TypeOfSpravkaId == id);
        }
    }
}
