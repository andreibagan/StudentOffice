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
            var applicationContext = _context.MainPlans.Include(m => m.AdmissionPlan).ThenInclude(i => i.SelectionСommittee).Include(m => m.User).ThenInclude(i => i.Anketa).ThenInclude(i => i.Specialty);
            return View(await applicationContext.ToListAsync());
        }


        [HttpGet]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            ViewData["AdmissionPlanId"] = new SelectList(_context.AdmissionPlans, "AdmissionPlanId", "GetName");
            //ViewData["TypeOfSpravkaId"] = new SelectList(_context.TypeOfSpravkas, "TypeOfSpravkaId", "TypeOfSpravkaName");

            if (id == 0)
            {
                var user = await _userManager.Users.Include(i => i.Anketa).FirstOrDefaultAsync(i => i.UserName == User.Identity.Name);
                MainPlan mainPlan = new MainPlan();

                //if (user?.Anketa != null)
                //{
                //    spravka.Name = user.Anketa.Name;
                //    spravka.Surname = user.Anketa.Surname;
                //    spravka.Middlename = user.Anketa.Middlename;
                //}

                return View(mainPlan);
            }
            else
            {
                var mainPlan = await _context.MainPlans.FindAsync(id);

                if (mainPlan == null)
                {
                    return NotFound("Не удалось найти план");
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




                return View(mainPlan);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, MainPlan model)
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
                    model.UserId = user.Id;

                    await _context.MainPlans.AddAsync(model);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    try
                    {
                        MainPlan mainPlan = await _context.MainPlans.FirstOrDefaultAsync(i => i.MainPlanId == model.MainPlanId);

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

                return RedirectToAction(nameof(Index));
            }
            ViewData["AdmissionPlanId"] = new SelectList(_context.AdmissionPlans, "AdmissionPlanId", "GetName");
            //ViewData["TypeOfSpravkaId"] = new SelectList(_context.TypeOfSpravkas, "TypeOfSpravkaId", "TypeOfSpravkaName");
            return View(model);
        }

        // GET: MainPlan/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mainPlan = await _context.MainPlans
                .Include(m => m.AdmissionPlan)
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
            ViewData["AdmissionPlanId"] = new SelectList(_context.AdmissionPlans, "AdmissionPlanId", "AdmissionPlanId");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: MainPlan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MainPlanId,AdmissionPlanId,UserId,DateTime")] MainPlan mainPlan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mainPlan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdmissionPlanId"] = new SelectList(_context.AdmissionPlans, "AdmissionPlanId", "AdmissionPlanId", mainPlan.AdmissionPlanId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", mainPlan.UserId);
            return View(mainPlan);
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
            ViewData["AdmissionPlanId"] = new SelectList(_context.AdmissionPlans, "AdmissionPlanId", "AdmissionPlanId", mainPlan.AdmissionPlanId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", mainPlan.UserId);
            return View(mainPlan);
        }

        // POST: MainPlan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MainPlanId,AdmissionPlanId,UserId,DateTime")] MainPlan mainPlan)
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
            ViewData["AdmissionPlanId"] = new SelectList(_context.AdmissionPlans, "AdmissionPlanId", "AdmissionPlanId", mainPlan.AdmissionPlanId);
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
                .Include(m => m.AdmissionPlan)
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
