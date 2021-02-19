using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentOffice.Models.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentOffice.Controllers
{
    public class TimeTableController : Controller
    {
        private readonly ApplicationContext _context;

        public TimeTableController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var timeTable = await _context.TimeTables
                .Include(i => i.Semester)
                .Include(i => i.TimeTableGroups)
                .ThenInclude(i => i.Group)
                .Include(i => i.TimeTableGroups)
                .ThenInclude(i => i.Couples)
                .ThenInclude(i => i.Discipline)
                .Include(i => i.TimeTableGroups)
                .ThenInclude(i => i.Couples)
                .ThenInclude(i => i.Audience)
                .Include(i => i.TimeTableGroups)
                .ThenInclude(i => i.Couples)
                .ThenInclude(i => i.TimeWindow)
                .Include(i => i.TimeTableGroups)
                .ThenInclude(i => i.Couples)
                .ThenInclude(i => i.User).ToListAsync();
                //.FirstOrDefaultAsync(i => i.DateTime.Date == DateTime.Now.Date);
            return View(timeTable);
        }


    }
}
