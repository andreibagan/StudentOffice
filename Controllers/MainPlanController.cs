using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentOffice.Models.DataBase;

namespace StudentOffice.Controllers
{
    public class MainPlanController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly UserManager<User> _userManager;

        public MainPlanController(ApplicationContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: MainPlan
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.MainPlans.Include(m => m.GetSelectionСommittee).Include(m => m.User);
            return View(await applicationContext.ToListAsync());
        }

        // GET: MainPlan/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mainPlan = await _context.MainPlans
                .Include(m => m.GetSelectionСommittee)
                .Include(m => m.User)
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
            ViewData["SelectionСommitteeId"] = new SelectList(_context.SelectionСommitties, "SelectionСommitteeId", "Name");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: MainPlan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MainPlanId,SelectionСommitteeId,UserId,DateTime")] MainPlan mainPlan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mainPlan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SelectionСommitteeId"] = new SelectList(_context.SelectionСommitties, "SelectionСommitteeId", "Name", mainPlan.SelectionСommitteeId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", mainPlan.UserId);
            return View(mainPlan);
        }

        [HttpGet]
        public async Task<IActionResult> AddOrEdit()
        {

            var user = await _userManager.Users.Include(i => i.Anketa).ThenInclude(i => i.Specialty).ThenInclude(i => i.Specialization).Include(i => i.MainPlans).FirstOrDefaultAsync(i => i.UserName == User.Identity.Name);

            if (user?.Anketa == null)
            {
                return Content("Пожалуйста заполните анкету абитуриента");
            }

            if (user?.MainPlans?.OrderByDescending(i => i.MainPlanId).FirstOrDefault() == null)
            {
                ViewData["SelectionСommitteeId"] = new SelectList(_context.SelectionСommitties, "SelectionСommitteeId", "Name");
                MainPlan mainPlan = new MainPlan();

                if (user?.Anketa != null)
                {
                    mainPlan.UserId = user.Id;
                    mainPlan.User = user;
                }
                var selectionСommittee = await _context.SelectionСommitties.OrderByDescending(i => i.SelectionСommitteeId).FirstOrDefaultAsync();

                if (selectionСommittee == null)
                {
                    return NotFound("Комиссия не найдена");
                }

                mainPlan.SelectionСommitteeId = selectionСommittee.SelectionСommitteeId;
                mainPlan.GetSelectionСommittee = selectionСommittee;
                return View(mainPlan);
            }
            else
            {
                var mainplanid = user.MainPlans.OrderByDescending(i => i.MainPlanId).FirstOrDefault().MainPlanId;
                MainPlan mainPlan = _context.MainPlans.Include(i => i.User).Include(i => i.GetSelectionСommittee).FirstOrDefault(i => i.MainPlanId == mainplanid);
                if (mainPlan == null)
                {
                    return NotFound("План приема не найден");
                }
                return View(mainPlan);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("MainPlanId,SelectionСommitteeId,UserId,DateTime")] MainPlan model)
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

                    await _context.MainPlans.AddAsync(model);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    try
                    {
                        _context.MainPlans.Update(model);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!MainPlanExists(model.MainPlanId))
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
            //ViewData["GroupId"] = new SelectList(_context.Groups.OrderBy(i => i.GroupName), "GroupId", "GroupName");
            //ViewData["TypeOfSpravkaId"] = new SelectList(_context.TypeOfSpravkas, "TypeOfSpravkaId", "TypeOfSpravkaName");

            ViewData["SelectionСommitteeId"] = new SelectList(_context.SelectionСommitties, "SelectionСommitteeId", "Name", model.SelectionСommitteeId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "UserName", model.UserId);

            return View(model);
        }

        // GET: MainPlan/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mainPlan = await _context.MainPlans.FindAsync(id);
            if (mainPlan == null)
            {
                return NotFound();
            }
            ViewData["SelectionСommitteeId"] = new SelectList(_context.SelectionСommitties, "SelectionСommitteeId", "Name", mainPlan.SelectionСommitteeId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", mainPlan.UserId);
            return View(mainPlan);
        }

        // POST: MainPlan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MainPlanId,SelectionСommitteeId,UserId,DateTime")] MainPlan mainPlan)
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
            ViewData["SelectionСommitteeId"] = new SelectList(_context.SelectionСommitties, "SelectionСommitteeId", "Name", mainPlan.SelectionСommitteeId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", mainPlan.UserId);
            return View(mainPlan);
        }



        // GET: MainPlan/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mainPlan = await _context.MainPlans
                .Include(m => m.GetSelectionСommittee)
                .Include(m => m.User)
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
            var mainPlan = await _context.MainPlans.FindAsync(id);
            _context.MainPlans.Remove(mainPlan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MainPlanExists(int id)
        {
            return _context.MainPlans.Any(e => e.MainPlanId == id);
        }
    }
}
