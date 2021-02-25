using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using StudentOffice.Models.DataBase;
using StudentOffice.ViewModels;

namespace StudentOffice.Controllers
{
    public class TimeTableController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly UserManager<User> _userManager;

        public TimeTableController(ApplicationContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        //[HttpGet]
        //public async Task<IActionResult> Index()
        //{
        //    var currentUser = await _userManager.Users.Include(i => i.Group).FirstOrDefaultAsync(i => i.UserName == User.Identity.Name);

        //    var timeTableGroup = new List<TimeTableGroup>();

        //    if (currentUser?.Group != null)
        //    {
        //        timeTableGroup = await _context.TimeTableGroups
        //           .Include(i => i.TimeTable)
        //           .ThenInclude(i => i.Semester)
        //           .Include(i => i.Group)
        //           .Include(i => i.Couples)
        //           .ThenInclude(i => i.Discipline)
        //           .Include(i => i.Couples)
        //           .ThenInclude(i => i.Audience)
        //           .Include(i => i.Couples)
        //           .ThenInclude(i => i.TimeWindow)
        //           .Include(i => i.Couples)
        //           .ThenInclude(i => i.User)
        //           .Where(i => i.Group.GroupName == currentUser.Group.GroupName && i.TimeTable.DateTime.Date == DateTime.Now.Date).ToListAsync();
        //    }
        //    else
        //    {
        //        timeTableGroup = await _context.TimeTableGroups
        //           .Include(i => i.TimeTable)
        //           .ThenInclude(i => i.Semester)
        //           .Include(i => i.Group)
        //           .Include(i => i.Couples)
        //           .ThenInclude(i => i.Discipline)
        //           .Include(i => i.Couples)
        //           .ThenInclude(i => i.Audience)
        //           .Include(i => i.Couples)
        //           .ThenInclude(i => i.TimeWindow)
        //           .Include(i => i.Couples)
        //           .ThenInclude(i => i.User)
        //           .Where(i => i.TimeTable.DateTime.Date == DateTime.Now.Date).ToListAsync();
        //    }
        //    //--------------------------------------------------
        //    //timeTable = await _context.TimeTables
        //    //    .Include(i => i.Semester)
        //    //    .Include(i => i.TimeTableGroups)
        //    //    .ThenInclude(i => i.Group)
        //    //    .Include(i => i.TimeTableGroups)
        //    //    .ThenInclude(i => i.Couples)
        //    //    .ThenInclude(i => i.Discipline)
        //    //    .Include(i => i.TimeTableGroups)
        //    //    .ThenInclude(i => i.Couples)
        //    //    .ThenInclude(i => i.Audience)
        //    //    .Include(i => i.TimeTableGroups)
        //    //    .ThenInclude(i => i.Couples)
        //    //    .ThenInclude(i => i.TimeWindow)
        //    //    .Include(i => i.TimeTableGroups)
        //    //    .ThenInclude(i => i.Couples)
        //    //    .ThenInclude(i => i.User).ToListAsync();
        //    ////.FirstOrDefaultAsync(i => i.DateTime.Date == DateTime.Now.Date);
        //    ///-----------------------------------------------------

        //    return View(timeTableGroup);
        //}

        [HttpGet]
        public async Task<IActionResult> Create(int? CoupleCount)
        {
            TimeTableViewModel model = new TimeTableViewModel();

            if (CoupleCount != null && CoupleCount > 0)
            {
                model.Audiences = await _context.Audiences.ToListAsync();
                model.Disciplines = await _context.Disciplines.ToListAsync();
                model.Groups = await _context.Groups.ToListAsync();
                model.Teachers = await _userManager.GetUsersInRoleAsync("преподаватель");

                for (int i = 0; i < CoupleCount; i++)
                {
                    model.Couples.Add(new CoupleViewModel());
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TimeTableViewModel model)
        {
            if (ModelState.IsValid)
            {
                TimeTable timeTable = new TimeTable
                {
                    DateTime = model.DateTime,
                    DayNumber = model.DateTime.Day,
                    PatternType = "Рабочий",
                    SemesterId = null, //TODO: Нужен ли семестр?
                };

                await _context.TimeTables.AddAsync(timeTable);
                await _context.SaveChangesAsync();

                TimeTableGroup timeTableGroup = new TimeTableGroup
                {
                    GroupId = model.GroupId,
                    TimeTableId = timeTable.TimeTableId
                };

                await _context.TimeTableGroups.AddAsync(timeTableGroup);
                await _context.SaveChangesAsync();

                List<Couple> Couples = model.Couples.Select(i => new Couple
                {
                    IsSubgroups = false,
                    Subgroups = 0,
                    DisciplineId = i.DisciplineId,
                    AudienceId = i.AudienceId,
                    TimeWindowId = null, //TODO: Временное окно?
                    UserId = i.TeacherId,
                    TimeTableGroupId = timeTableGroup.TimeTableGroupId
                }).ToList();

                await _context.Couples.AddRangeAsync(Couples);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            else
            {
                model.Audiences = await _context.Audiences.ToListAsync();
                model.Disciplines = await _context.Disciplines.ToListAsync();
                model.Groups = await _context.Groups.ToListAsync();
                model.Teachers = await _userManager.GetUsersInRoleAsync("преподаватель");

                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Unload()
        {
            //TimeTable timeTable = await _context.TimeTables
            //    .Include(i => i.Semester)
            //    .Include(i => i.TimeTableGroups)
            //    .ThenInclude(i => i.Group)
            //    .Include(i => i.TimeTableGroups)
            //    .ThenInclude(i => i.Couples)
            //    .ThenInclude(i => i.Discipline)
            //    .Include(i => i.TimeTableGroups)
            //    .ThenInclude(i => i.Couples)
            //    .ThenInclude(i => i.Audience)
            //    .Include(i => i.TimeTableGroups)
            //    .ThenInclude(i => i.Couples)
            //    .ThenInclude(i => i.TimeWindow)
            //    .Include(i => i.TimeTableGroups)
            //    .ThenInclude(i => i.Couples)
            //    .ThenInclude(i => i.User)
            //    .FirstOrDefaultAsync();

            //using (StreamWriter fs = new StreamWriter("timetable.json"))
            //{
            //    await fs.WriteLineAsync(JsonConvert.SerializeObject(timeTable));
            //}

            //return Content("Сериализован");


            UnloadViewModel model = new UnloadViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Unload(UnloadViewModel model)
        {
            string json = string.Empty;

            using (var fs = System.IO.File.OpenRead(model.Path))
            {
                using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
                {
                    json = sr.ReadToEnd();
                }
            }

            var timeTables = JsonConvert.DeserializeObject<List<TimeTable>>(json);

            if (timeTables == null)
            {
                return Content("Ошибка чтения файла");
            }

            foreach (var timetable in timeTables)
            {
                await _context.TimeTables.AddAsync(timetable);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Unload");
        }
    }
}
