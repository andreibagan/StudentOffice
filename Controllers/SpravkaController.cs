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
using StudentOffice.ViewModels;

namespace StudentOffice.Controllers
{
    //[Authorize]
    public class SpravkaController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly UserManager<User> _userManager;

        public SpravkaController(ApplicationContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Spravka
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            List<Spravka> model;

            if(await _userManager.IsInRoleAsync(user, "admin"))
            {
                //model = await _context.SpravkaOrders
                //      .Include(s => s.Spravka).ThenInclude(s => s.TypeOfSpravka)
                //      .Include(s => s.Spravka).ThenInclude(s => s.Group)
                //      .Include(s => s.User).Select(i => new SpravkaViewModel1
                //      {
                //          SpravkaId = i.SpravkaId,
                //          Name = i.Spravka.Name,
                //          Surname = i.Spravka.Surname,
                //          Middlename = i.Spravka.Middlename,
                //          OrganizationName = i.Spravka.OrganizationName,
                //          GroupId = i.Spravka.GroupId,
                //          AdditionalInformation = i.Spravka.AdditionalInformation,
                //          TypeOfSpravkaId = i.Spravka.TypeOfSpravkaId,
                //          DateTime = i.DateTimeNow
                //      }).ToListAsync();

                model = await _context.Spravkas
                    .Include(i => i.Group)
                    .Include(i => i.TypeOfSpravka)
                    .Include(i => i.SpravkaOrders)
                    .ThenInclude(i => i.User)
                    .ToListAsync();
            }
            else
            {
                //model = await _context.SpravkaOrders
                //       .Include(s => s.Spravka).ThenInclude(s => s.TypeOfSpravka)
                //      .Include(s => s.Spravka).ThenInclude(s => s.Group)
                //      .Include(s => s.User).Select(i => new SpravkaViewModel1
                //      {
                //          SpravkaId = i.SpravkaId,
                //          Name = i.Spravka.Name,
                //          Surname = i.Spravka.Surname,
                //          Middlename = i.Spravka.Middlename,
                //          OrganizationName = i.Spravka.OrganizationName,
                //          GroupId = i.Spravka.GroupId,
                //          AdditionalInformation = i.Spravka.AdditionalInformation,
                //          TypeOfSpravkaId = i.Spravka.TypeOfSpravkaId,
                //          DateTime = i.DateTimeNow
                //      }).ToListAsync();
                model = await _context.Spravkas
                   .Include(i => i.Group)
                   .Include(i => i.TypeOfSpravka)
                   .Include(i => i.SpravkaOrders)
                   .ThenInclude(i => i.User)
                   .Where(i => i.SpravkaOrders.FirstOrDefault().User.UserName == user.UserName)
                   .ToListAsync();
            }

            return View(model);
        }

        // GET: Spravka/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spravka = await _context.Spravkas
                   .Include(i => i.Group)
                   .Include(i => i.TypeOfSpravka)
                   .Include(i => i.SpravkaOrders)
                   .ThenInclude(i => i.User)
                   .FirstOrDefaultAsync(s => s.SpravkaId == id);

            if (spravka == null)
            {
                return NotFound();
            }

            return View(spravka);
        }


        [HttpGet]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            ViewData["GroupId"] = new SelectList(_context.Groups.OrderBy(i => i.GroupName), "GroupId", "GroupName");
            ViewData["TypeOfSpravkaId"] = new SelectList(_context.TypeOfSpravkas, "TypeOfSpravkaId", "TypeOfSpravkaName");

            if (id == 0)
            {
                var user = await _userManager.Users.Include(i => i.Anketa).FirstOrDefaultAsync(i => i.UserName == User.Identity.Name);
                Spravka spravka = new Spravka();

                if (user?.Anketa != null)
                {
                    spravka.Name = user.Anketa.Name;
                    spravka.Surname = user.Anketa.Surname;
                    spravka.Middlename = user.Anketa.Middlename;
                }

                return View(spravka);
            }
            else
            {
                var spravka = await _context.Spravkas.FindAsync(id);

                if (spravka == null)
                {
                    return NotFound("Не удалось найти справку");
                }

                //SpravkaViewModel1 model = new SpravkaViewModel1();
                //model.SpravkaId = spravkaOrder.SpravkaId;
                //model.Name = spravkaOrder.Spravka.Name;
                //model.Surname = spravkaOrder.Spravka.Surname;
                //model.Middlename = spravkaOrder.Spravka.Middlename;
                //model.OrganizationName = spravkaOrder.Spravka.OrganizationName;
                //model.GroupId = spravkaOrder.Spravka.GroupId;
                //model.AdditionalInformation = spravkaOrder.Spravka.AdditionalInformation;
                //model.TypeOfSpravkaId = spravkaOrder.Spravka.TypeOfSpravkaId;
                //model.DateTime = spravkaOrder.DateTimeNow;




                return View(spravka);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("SpravkaId,Name,Surname,Middlename,OrganizationName,GroupId,AdditionalInformation,TypeOfSpravkaId")] Spravka model)
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

                    await _context.Spravkas.AddAsync(model);
                    await _context.SaveChangesAsync();

                    SpravkaOrder spravkaOrder = new SpravkaOrder();
                    spravkaOrder.DateTimeNow = DateTime.Now;
                    spravkaOrder.UserId = user.Id;
                    spravkaOrder.SpravkaId = model.SpravkaId;

                    await _context.SpravkaOrders.AddAsync(spravkaOrder);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    try
                    {
                        SpravkaOrder spravkaOrder = await _context.SpravkaOrders.FirstOrDefaultAsync(i => i.SpravkaId == model.SpravkaId);
                        spravkaOrder.DateTimeNow = DateTime.Now;

                        _context.Spravkas.Update(model);
                        _context.SpravkaOrders.Update(spravkaOrder);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!SpravkaExists(model.SpravkaId))
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
            ViewData["GroupId"] = new SelectList(_context.Groups.OrderBy(i => i.GroupName), "GroupId", "GroupName");
            ViewData["TypeOfSpravkaId"] = new SelectList(_context.TypeOfSpravkas, "TypeOfSpravkaId", "TypeOfSpravkaName");
            return View(model);
        }

        // GET: Spravka/Create
        //public IActionResult Create()
        //{
        //    ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "GroupName");
        //    ViewData["TypeOfSpravkaId"] = new SelectList(_context.TypeOfSpravkas, "TypeOfSpravkaId", "TypeOfSpravkaName");
        //    return View();
        //}

        //// POST: Spravka/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("SpravkaId,Name,Surname,Middlename,OrganizationName,GroupId,AdditionalInformation,TypeOfSpravkaId")] SpravkaOrder model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(spravka);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "GroupName", spravka.GroupId);
        //    ViewData["TypeOfSpravkaId"] = new SelectList(_context.TypeOfSpravkas, "TypeOfSpravkaId", "TypeOfSpravkaName", spravka.TypeOfSpravkaId);
        //    return View(spravka);
        //}

        //// GET: Spravka/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var spravka = await _context.Spravkas.FindAsync(id);
        //    if (spravka == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "GroupName", spravka.GroupId);
        //    ViewData["TypeOfSpravkaId"] = new SelectList(_context.TypeOfSpravkas, "TypeOfSpravkaId", "TypeOfSpravkaName", spravka.TypeOfSpravkaId);
        //    return View(spravka);
        //}

        //// POST: Spravka/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("SpravkaId,Name,Surname,Middlename,OrganizationName,GroupId,AdditionalInformation,TypeOfSpravkaId")] Spravka spravka)
        //{
        //    if (id != spravka.SpravkaId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(spravka);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!SpravkaExists(spravka.SpravkaId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "GroupName", spravka.GroupId);
        //    ViewData["TypeOfSpravkaId"] = new SelectList(_context.TypeOfSpravkas, "TypeOfSpravkaId", "TypeOfSpravkaName", spravka.TypeOfSpravkaId);
        //    return View(spravka);
        //}

        // GET: Spravka/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spravka = await _context.Spravkas
                .Include(s => s.Group)
                .Include(s => s.TypeOfSpravka)
                .Include(s => s.SpravkaOrders)
                .FirstOrDefaultAsync(m => m.SpravkaId == id);
            if (spravka == null)
            {
                return NotFound();
            }

            return View(spravka);
        }

        // POST: Spravka/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var spravka = await _context.Spravkas.FindAsync(id);
            _context.Spravkas.Remove(spravka);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpravkaExists(int id)
        {
            return _context.Spravkas.Any(e => e.SpravkaId == id);
        }
    }
}
