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
                .Include(i => i.MarkUsers)
                .ThenInclude(i => i.MarkExams)
                .ThenInclude(i => i.GroupExam)
                .ThenInclude(i => i.Exam)
                .Include(i => i.MarkUsers)
                .ThenInclude(i => i.Marks)
                .ThenInclude(i => i.GroupDiscipline)
                .ThenInclude(i => i.Discipline)
                .Include(i => i.MarkUsers)
                .ThenInclude(i => i.User)
                .ThenInclude(i => i.Anketa)
                .Include(i => i.MarkUsers)
                .ThenInclude(i => i.Omission)
                .FirstOrDefaultAsync();

            return View(markLog);
        }


        //[HttpGet]
        //public IActionResult Create()
        //{

        //}

        //[HttpPost]
        //public IActionResult Create()
        //{

        //}
    }
}
