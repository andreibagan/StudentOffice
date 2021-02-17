using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index()
        {
            return View();
        }


    }
}
