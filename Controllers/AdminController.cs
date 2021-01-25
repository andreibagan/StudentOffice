using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentOffice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentOffice.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private ApplicationContext _context;

        public AdminController(ApplicationContext context)
        {
            _context = context;
        }

        //[HttpGet]
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Users.Include(i => i.Role).ToListAsync());
        //}

    }
}
