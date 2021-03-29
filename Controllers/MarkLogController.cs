using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentOffice.Models.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentOffice.Controllers
{
    public class MarkLogController : Controller
    {
        private ApplicationContext _context;

        public MarkLogController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            MarkLog markLog = await _context.MarkLogs
                .Include(i => i.Semester)
                .Include(i => i.Group)
                .Include(i => i.MarkUsers)
                .ThenInclude(i => i.User)
                .ThenInclude(i => i.Anketa)
                .Include(i => i.MarkUsers)
                .ThenInclude(i => i.MarkExams)
                .ThenInclude(i => i.Exam)
                .Include(i => i.MarkUsers)
                .ThenInclude(i => i.Marks)
                .ThenInclude(i => i.Discipline)
                .FirstOrDefaultAsync();

            return View(markLog);
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id = 0)
        {
            if (id == 0)
            {
                List<MarkLog> markLogs = await _context.MarkLogs
                    .Include(i => i.Semester)
                    .Include(i => i.Group)
                    .Include(i => i.MarkUsers)
                    .ThenInclude(i => i.User)
                    .Include(i => i.MarkUsers)
                    .ThenInclude(i => i.MarkExams)
                    .ThenInclude(i => i.Exam)
                    .Include(i => i.MarkUsers)
                    .ThenInclude(i => i.Marks)
                    .ThenInclude(i => i.Discipline)
                    .ToListAsync();

                return Json(markLogs);
            }
            else
            {
                MarkLog markLog = await _context.MarkLogs
                  .Include(i => i.Semester)
                  .Include(i => i.Group)
                  .Include(i => i.MarkUsers)
                  .ThenInclude(i => i.User)
                  .Include(i => i.MarkUsers)
                  .ThenInclude(i => i.MarkExams)
                  .ThenInclude(i => i.Exam)
                  .Include(i => i.MarkUsers)
                  .ThenInclude(i => i.Marks)
                  .ThenInclude(i => i.Discipline)
                  .FirstOrDefaultAsync(i => i.MarkLogId == id);

                return Json(markLog);
            }

        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Post([FromBody] List<MarkLog> markLogs)
        {
            if (markLogs == null)
            {
                new ObjectResult(markLogs);
            }

            await _context.MarkLogs.AddRangeAsync(markLogs);

            await _context.SaveChangesAsync();

            return Ok(markLogs);
        }
    }
}
