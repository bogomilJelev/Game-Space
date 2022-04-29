using GameSpace.Data;
using GameSpace.Models;
using GameSpace.Models.Games;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GameSpace.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly GameSpaceDbContext data;

        public HomeController(ILogger<HomeController> logger, GameSpaceDbContext _data)
        {
            data = _data;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var games = this.data
                .Games
                .OrderByDescending(c=>c.Id)
                .Select(x => new GameListVIewModel
                {
                    Id = x.Id,
                    ImageUrl = x.ImageUrl,
                    Description = x.Description,
                    Name = x.Name,
                    Year = x.Year,
                    Category = x.Category.Name

                })
                .Take(3)
                .ToList();
            return View(games);
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