using GameSpace.Data;
using GameSpace.Data.Models;
using GameSpace.Interfaces;
using GameSpace.Models.Games;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace GameSpace.Controllers
{
    public class GamesController : Controller
    {
        private readonly GameSpaceDbContext data;
        private readonly IGameService gameService;

        public GamesController(GameSpaceDbContext data, IGameService gameService)
        {
            this.data = data;
            this.gameService = gameService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Add() => View(new AddGameFormModel
        {
            Categories = this.GetGameCategories()
        });

        [HttpPost]
        [Authorize]
        public IActionResult Add(AddGameFormModel game)
        {
            gameService.AddGame(game);
            return Redirect(nameof(All));

        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var gameid = data.Games.Where(x=>x.Id==id).FirstOrDefault();

            return View(new GameDetailModel
            {
                Name = gameid.Name,
                Description = gameid.Description,
                ImageUrl = gameid.ImageUrl,
                
            });;

        }
        public IActionResult All([FromQuery] AllGameQueryModel query)
        {

            var gamequery = this.data.Games.AsQueryable();
            if (!string.IsNullOrWhiteSpace(query.SearchTerm))
            {
                gamequery = gamequery.Where(g =>
                g.Name.ToLower().Contains(query.SearchTerm.ToLower()) ||
                g.Description.ToLower().Contains(query.SearchTerm.ToLower()));
            }
            var games = gamequery
                .Skip((query.CurrentPage-1)*AllGameQueryModel.GamePerPage)
                .Take(AllGameQueryModel.GamePerPage)
                 .Select(x => new GameListVIewModel
                 {
                     Id = x.Id,
                     ImageUrl = x.ImageUrl,
                     Description = x.Description,
                     Name = x.Name,
                     Year = x.Year,
                     Category = x.Category.Name,
                 }) ;
            var totalgames = gamequery.Count();
            query.Games = games;
            query.TotalGames = totalgames;
            return View(query) ;
          
        }
        private IEnumerable<GameCategoryViewModel> GetGameCategories() =>

            this.data.Categories.Select(c => new GameCategoryViewModel
            {
                Id = c.Id,
                Name = c.Name,
            })
                .ToList();
                
        
    }
}
