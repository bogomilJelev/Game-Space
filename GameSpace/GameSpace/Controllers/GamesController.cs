using GameSpace.Models.Games;
using Microsoft.AspNetCore.Mvc;

namespace GameSpace.Controllers
{
    public class GamesController : Controller
    {
        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Add(AddGameFormModel game)
        {
            return View();
        }
    }
}
