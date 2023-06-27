using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using System.Diagnostics;
using Microsoft.Extensions.Options;
using Portfolio.Services;
using Portfolio.Interfaces;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProjectsRepository _projectsRepository;
        private readonly IEmailService _emailService;


        public HomeController(ILogger<HomeController> logger, IProjectsRepository projectsRepository, IEmailService emailService)
        {
            _logger = logger;
            _projectsRepository = projectsRepository;
            _emailService = emailService;
        }


        public IActionResult Index()
        {
            var projects = _projectsRepository.GetProjects().Take(3).ToList();

            var model = new HomeIndexViewModel()
            {
                Projects  = projects
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Projects()
        {
            var allProjects = _projectsRepository.GetProjects();
            return View(allProjects);
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contact(ContactDTO contactDTO)
        {
            await _emailService.Send(contactDTO);
            return RedirectToAction("Thanks");
        }

        public IActionResult Thanks()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}