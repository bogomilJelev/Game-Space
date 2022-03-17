using GameSpace.Data;
using GameSpace.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GameSpace.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly GameSpaceDbContext dbcontext;

        public HomeController(ILogger<HomeController> logger, GameSpaceDbContext _dbcontext)
        {
            dbcontext = _dbcontext;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
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