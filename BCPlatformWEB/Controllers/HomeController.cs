using BCPlatformWEB.Data;
using BCPlatformWEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BCPlatformWEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext dBContext;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext DBContext)
        {
            _logger = logger;
            dBContext = DBContext;
        }

        public IActionResult Index()
        {
            return View(dBContext.Posts.ToList());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}