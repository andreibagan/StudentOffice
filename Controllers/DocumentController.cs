using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentOffice.Models.DataBase;
using System;
using System.Net;
using System.Threading.Tasks;

namespace StudentOffice.Controllers
{
    public class DocumentController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IWebHostEnvironment _appEnvironment;

        public DocumentController(ApplicationContext context, UserManager<User> userManager, IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _userManager = userManager;
            _appEnvironment = appEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ApplicationOfApplicant(string id)
        {

            User user = await _userManager.Users.Include(i => i.Anketa).ThenInclude(i => i.DocumentType).Include(i => i.Anketa).ThenInclude(i => i.Specialty).ThenInclude(i => i.Group).FirstOrDefaultAsync(i => i.UserName == id);

            if (user?.Anketa == null)
            {
                return Content("Пожалуйста, заполните анкету");
            }

            return View(user);
        }

        [HttpPost]
        public async Task<FileResult> ApplicationOfApplicant()
        {
            User user = await _userManager.FindByNameAsync(User.Identity.Name);

            using (WebClient client = new WebClient())
            {
                Uri location = new Uri($"{Request.Scheme}://{Request.Host}/Document/ApplicationOfApplicantDownload/{user.UserName}");
                string file_type = "text/doc";
                string file_name = $"Заявление абитуриента от {DateTime.Now.ToShortDateString()}.doc";
                return File(client.DownloadData(location), file_type, file_name);
            }
        }

        [HttpGet]
        public async Task<IActionResult> ApplicationOfApplicantDownload(string id)
        {
            User user = await _userManager.Users.Include(i => i.Anketa).ThenInclude(i => i.DocumentType).Include(i => i.Anketa).ThenInclude(i => i.Specialty).ThenInclude(i => i.Group).FirstOrDefaultAsync(i => i.UserName == id);

            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> DormitoryApplication(string id)
        {
            User user = await _userManager.Users.Include(i => i.Anketa).ThenInclude(i => i.Specialty).ThenInclude(i => i.Group).FirstOrDefaultAsync(i => i.UserName == id);

            if (user?.Anketa == null)
            {
                return Content("Пожалуйста, заполните анкету");
            }

            return View(user);

        }

        [HttpPost]
        public async Task<FileResult> DormitoryApplication()
        {
            User user = await _userManager.FindByNameAsync(User.Identity.Name);

            using (WebClient client = new WebClient())
            {
                Uri location = new Uri($"{Request.Scheme}://{Request.Host}/Document/DormitoryApplicationDownload/{user.UserName}");
                string file_type = "text/doc";
                string file_name = $"Заявление на общежитие от {DateTime.Now.ToShortDateString()}.doc";
                return File(client.DownloadData(location), file_type, file_name);
            }
        }

        [HttpGet]
        public async Task<IActionResult> DormitoryApplicationDownload(string id)
        {
            User user = await _userManager.Users.Include(i => i.Anketa).ThenInclude(i => i.Specialty).ThenInclude(i => i.Group).FirstOrDefaultAsync(i => i.UserName == id);

            return View(user);
        }



        [HttpGet]
        public async Task<IActionResult> ApplicationForPaymentInTwoSteps(string id)
        {

            User user = await _userManager.Users.Include(i => i.Anketa).ThenInclude(i => i.Specialty).ThenInclude(i => i.Group).FirstOrDefaultAsync(i => i.UserName == id);

            if (user?.Anketa == null)
            {
                return Content("Пожалуйста, заполните анкету");
            }

            return View(user);
        }

        [HttpPost]
        public async Task<FileResult> ApplicationForPaymentInTwoSteps()
        {
            User user = await _userManager.FindByNameAsync(User.Identity.Name);

            using (WebClient client = new WebClient())
            {
                Uri location = new Uri($"{Request.Scheme}://{Request.Host}/Document/ApplicationForPaymentInTwoStepsDownload/{user.UserName}");
                string file_type = "text/doc";
                string file_name = $"Заявление на оплату в два этапа от {DateTime.Now.ToShortDateString()}.doc";
                return File(client.DownloadData(location), file_type, file_name);
            }
        }

        [HttpGet]
        public async Task<IActionResult> ApplicationForPaymentInTwoStepsDownload(string id)
        {
            User user = await _userManager.Users.Include(i => i.Anketa).ThenInclude(i => i.Specialty).ThenInclude(i => i.Group).FirstOrDefaultAsync(i => i.UserName == id);

            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> ApplicationForPaymentInSeveralStages(string id)
        {
            User user = await _userManager.Users.Include(i => i.Anketa).ThenInclude(i => i.Specialty).ThenInclude(i => i.Group).FirstOrDefaultAsync(i => i.UserName == id);

            if (user?.Anketa == null)
            {
                return Content("Пожалуйста, заполните анкету");
            }

            return View(user);
        }

        [HttpPost]
        public async Task<FileResult> ApplicationForPaymentInSeveralStages()
        {
            User user = await _userManager.FindByNameAsync(User.Identity.Name);

            using (WebClient client = new WebClient())
            {
                Uri location = new Uri($"{Request.Scheme}://{Request.Host}/Document/ApplicationForPaymentInSeveralStagesDownload/{user.UserName}");
                string file_type = "text/doc";
                string file_name = $"Заявление на оплату в несколько этапов от {DateTime.Now.ToShortDateString()}.doc";
                return File(client.DownloadData(location), file_type, file_name);
            }
        }

        [HttpGet]
        public async Task<IActionResult> ApplicationForPaymentInSeveralStagesDownload(string id)
        {
            User user = await _userManager.Users.Include(i => i.Anketa).ThenInclude(i => i.Specialty).ThenInclude(i => i.Group).FirstOrDefaultAsync(i => i.UserName == id);

            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> ApplicationForPaymentMonthly(string id)
        {
            User user = await _userManager.Users.Include(i => i.Anketa).ThenInclude(i => i.Specialty).ThenInclude(i => i.Group).FirstOrDefaultAsync(i => i.UserName == id);

            if (user?.Anketa == null)
            {
                return Content("Пожалуйста, заполните анкету");
            }

            return View(user);
        }


        [HttpPost]
        public async Task<FileResult> ApplicationForPaymentMonthly()
        {
            User user = await _userManager.FindByNameAsync(User.Identity.Name);

            using (WebClient client = new WebClient())
            {
                Uri location = new Uri($"{Request.Scheme}://{Request.Host}/Document/ApplicationForPaymentMonthlyDownload/{user.UserName}");
                string file_type = "text/doc";
                string file_name = $"Заявление на оплату ежемесячно от {DateTime.Now.ToShortDateString()}.doc";
                return File(client.DownloadData(location), file_type, file_name);
            }
        }

        [HttpGet]
        public async Task<IActionResult> ApplicationForPaymentMonthlyDownload(string id)
        {
            User user = await _userManager.Users.Include(i => i.Anketa).ThenInclude(i => i.Specialty).ThenInclude(i => i.Group).FirstOrDefaultAsync(i => i.UserName == id);

            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> ApplicationForPaymentForThePeriod(string id)
        {
            User user = await _userManager.Users.Include(i => i.Anketa).ThenInclude(i => i.Specialty).ThenInclude(i => i.Group).FirstOrDefaultAsync(i => i.UserName == id);

            if (user?.Anketa == null)
            {
                return Content("Пожалуйста, заполните анкету");
            }

            return View(user);
        }

        [HttpPost]
        public async Task<FileResult> ApplicationForPaymentForThePeriod()
        {
            User user = await _userManager.FindByNameAsync(User.Identity.Name);

            using (WebClient client = new WebClient())
            {
                Uri location = new Uri($"{Request.Scheme}://{Request.Host}/Document/ApplicationForPaymentForThePeriodDownload/{user.UserName}");
                string file_type = "text/doc";
                string file_name = $"Заявление на оплату за период от {DateTime.Now.ToShortDateString()}.doc";
                return File(client.DownloadData(location), file_type, file_name);
            }
        }

        [HttpGet]
        public async Task<IActionResult> ApplicationForPaymentForThePeriodDownload(string id)
        {
            User user = await _userManager.Users.Include(i => i.Anketa).ThenInclude(i => i.Specialty).ThenInclude(i => i.Group).FirstOrDefaultAsync(i => i.UserName == id);

            return View(user);
        }
    }
}
