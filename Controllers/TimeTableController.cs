using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using StudentOffice.Models.DataBase;
using StudentOffice.ViewModels;

namespace StudentOffice.Controllers
{
    [Authorize]
    public class TimeTableController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly UserManager<User> _userManager;

        public TimeTableController(ApplicationContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int? groupId, DateTime date) ///TODO: Модель?
        {
            List<Group> groups = await _context.Groups.ToListAsync();
            List<TimeTableGroup> currentTimeTableGroups = new List<TimeTableGroup>();
            TimeTableViewModel timeTableViewModel = new TimeTableViewModel();

            groups.Insert(0, new Group { GroupId = 0, GroupName = "Все" });

            if (date.ToShortDateString() != "01.01.0001")
            {
                if (groupId != null && groupId > 0)
                {
                    currentTimeTableGroups = await _context.TimeTableGroups
                        .Include(i => i.TimeTable)
                        .ThenInclude(i => i.Semester)
                        .Include(i => i.Group)
                        .Include(i => i.Couples)
                        .ThenInclude(i => i.Lessons)
                        .ThenInclude(i => i.User)
                        .Include(i => i.Couples)
                        .ThenInclude(i => i.Lessons)
                        .ThenInclude(i => i.Audience)
                        .Include(i => i.Couples)
                        .ThenInclude(i => i.Lessons)
                        .ThenInclude(i => i.Discipline)
                        .Where(i => i.TimeTable.DateTime.Date == date.Date && i.GroupId == groupId)
                        .ToListAsync();
                }
                else
                {
                    currentTimeTableGroups = await _context.TimeTableGroups
                        .Include(i => i.TimeTable)
                        .ThenInclude(i => i.Semester)
                        .Include(i => i.Group)
                        .Include(i => i.Couples)
                        .ThenInclude(i => i.Lessons)
                        .ThenInclude(i => i.User)
                        .Include(i => i.Couples)
                        .ThenInclude(i => i.Lessons)
                        .ThenInclude(i => i.Audience)
                        .Include(i => i.Couples)
                        .ThenInclude(i => i.Lessons)
                        .ThenInclude(i => i.Discipline)
                      .Where(i => i.TimeTable.DateTime.Date == date.Date)
                      .ToListAsync();
                }
            }
            else
            {
                if (groupId != null && groupId > 0)
                {
                    currentTimeTableGroups = await _context.TimeTableGroups
                        .Include(i => i.TimeTable)
                        .ThenInclude(i => i.Semester)
                        .Include(i => i.Group)
                        .Include(i => i.Couples)
                        .ThenInclude(i => i.Lessons)
                        .ThenInclude(i => i.User)
                        .Include(i => i.Couples)
                        .ThenInclude(i => i.Lessons)
                        .ThenInclude(i => i.Audience)
                        .Include(i => i.Couples)
                        .ThenInclude(i => i.Lessons)
                        .ThenInclude(i => i.Discipline)
                      .Where(i => i.GroupId == groupId)
                      .ToListAsync();
                }
                else
                {
                    //TODO: если пользователь имеет группу вывести ему сегодняшнюю
                    currentTimeTableGroups = await _context.TimeTableGroups
                        .Include(i => i.TimeTable)
                        .ThenInclude(i => i.Semester)
                        .Include(i => i.Group)
                        .Include(i => i.Couples)
                        .ThenInclude(i => i.Lessons)
                        .ThenInclude(i => i.User)
                        .Include(i => i.Couples)
                        .ThenInclude(i => i.Lessons)
                        .ThenInclude(i => i.Audience)
                        .Include(i => i.Couples)
                        .ThenInclude(i => i.Lessons)
                        .ThenInclude(i => i.Discipline)
                     .ToListAsync();
                }
            }

            timeTableViewModel.TimeTableGroups = currentTimeTableGroups;
            timeTableViewModel.Groups = groups;

            return View(timeTableViewModel);




            //////var currentUser = await _userManager.Users
            //////    .Include(i => i.Anketa)
            //////    .ThenInclude(i => i.Specialty)
            //////    .ThenInclude(i => i.Groups)
            //////    .FirstOrDefaultAsync(i => i.UserName == User.Identity.Name);

            //////var timeTableGroup = new List<TimeTableGroup>();

            //if (currentUser?.Anketa?.Specialty?.Groups.FirstOrDefault() != null)
            //{
            //    timeTableGroup = await _context.TimeTableGroups
            //       .Include(i => i.TimeTable)
            //       .ThenInclude(i => i.Semester)
            //       .Include(i => i.Group)
            //       .Include(i => i.Couples)
            //       .ThenInclude(i => i.Discipline)
            //       .Include(i => i.Couples)
            //       .ThenInclude(i => i.Audience)
            //       .Include(i => i.Couples)
            //       .ThenInclude(i => i.TimeWindow)
            //       .Include(i => i.Couples)
            //       .ThenInclude(i => i.User)
            //       .Where(i => i.Group.GroupName == currentUser.Anketa.Specialty.Groups.FirstOrDefault().GroupName && i.TimeTable.DateTime.Date == DateTime.Now.Date).ToListAsync();
            //}
            //else
            //////{
            //////    timeTableGroup = await _context.TimeTableGroups
            //////       .Include(i => i.TimeTable)
            //////       .ThenInclude(i => i.Semester)
            //////       .Include(i => i.Group)
            //////       .Include(i => i.Couples)
            //////       .ThenInclude(i => i.Discipline)
            //////       .Include(i => i.Couples)
            //////       .ThenInclude(i => i.Audience)
            //////       .Include(i => i.Couples)
            //////       .ThenInclude(i => i.TimeWindow)
            //////       .Include(i => i.Couples)
            //////       .ThenInclude(i => i.User)
            //////       .Where(i => i.TimeTable.DateTime.Date == DateTime.Now.Date).ToListAsync();
            //////}
            //--------------------------------------------------
            //timeTable = await _context.TimeTables
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
            //    .ThenInclude(i => i.User).ToListAsync();
            ////.FirstOrDefaultAsync(i => i.DateTime.Date == DateTime.Now.Date);
            ///-----------------------------------------------------


        }

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

        //[HttpPost]
        //public async Task<IActionResult> Create(TimeTableViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        TimeTable timeTable = new TimeTable
        //        {
        //            DateTime = model.DateTime,
        //            DayNumber = model.DateTime.Day,
        //            PatternType = "Рабочий",
        //            SemesterId = null, //TODO: Нужен ли семестр?
        //        };

        //        await _context.TimeTables.AddAsync(timeTable);
        //        await _context.SaveChangesAsync();

        //        TimeTableGroup timeTableGroup = new TimeTableGroup
        //        {
        //            GroupId = model.GroupId,
        //            TimeTableId = timeTable.TimeTableId
        //        };

        //        await _context.TimeTableGroups.AddAsync(timeTableGroup);
        //        await _context.SaveChangesAsync();

        //        List<Couple> Couples = model.Couples.Select(i => new Couple
        //        {
        //            IsSubgroups = false,
        //            Subgroups = 0,
        //            DisciplineId = i.DisciplineId,
        //            AudienceId = i.AudienceId,
        //            TimeWindowId = null, //TODO: Временное окно?
        //            UserId = i.TeacherId,
        //            TimeTableGroupId = timeTableGroup.TimeTableGroupId
        //        }).ToList();

        //        await _context.Couples.AddRangeAsync(Couples);
        //        await _context.SaveChangesAsync();

        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        model.Audiences = await _context.Audiences.ToListAsync();
        //        model.Disciplines = await _context.Disciplines.ToListAsync();
        //        model.Groups = await _context.Groups.ToListAsync();
        //        model.Teachers = await _userManager.GetUsersInRoleAsync("преподаватель");

        //        return View(model);
        //    }
        //}

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Get(int id = 0)
        {
            if (id == 0)
            {
                List<TimeTable> timeTables = await _context.TimeTables
                    .Include(i => i.Semester)
                    .Include(i => i.TimeTableGroups)
                    .ThenInclude(i => i.Group)
                    .Include(i => i.TimeTableGroups)
                    .ThenInclude(i => i.Couples)
                    .ThenInclude(i => i.Lessons)
                    .ThenInclude(i => i.User)
                    .Include(i => i.TimeTableGroups)
                    .ThenInclude(i => i.Couples)
                    .ThenInclude(i => i.Lessons)
                    .ThenInclude(i => i.Audience)
                    .Include(i => i.TimeTableGroups)
                    .ThenInclude(i => i.Couples)
                    .ThenInclude(i => i.Lessons)
                    .ThenInclude(i => i.Discipline)
                    .ToListAsync();

                return new ObjectResult(timeTables);
            }
            else
            {
                TimeTable timeTable = await _context.TimeTables
                .Include(i => i.Semester)
                .Include(i => i.TimeTableGroups)
                .ThenInclude(i => i.Group)
                .Include(i => i.TimeTableGroups)
                .ThenInclude(i => i.Couples)
                .ThenInclude(i => i.Lessons)
                .ThenInclude(i => i.User)
                .Include(i => i.TimeTableGroups)
                .ThenInclude(i => i.Couples)
                .ThenInclude(i => i.Lessons)
                .ThenInclude(i => i.Audience)
                .Include(i => i.TimeTableGroups)
                .ThenInclude(i => i.Couples)
                .ThenInclude(i => i.Lessons)
                .ThenInclude(i => i.Discipline)
                .FirstOrDefaultAsync(i => i.TimeTableId == id);

                return new ObjectResult(timeTable);
            }
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Post([FromBody] List<TimeTable> timeTables)
        {
            if (timeTables == null)
            {
                new ObjectResult(timeTables);
            }

            await _context.TimeTables.AddRangeAsync(timeTables);

            await _context.SaveChangesAsync();

            return Ok(timeTables);
        }
    }
}
