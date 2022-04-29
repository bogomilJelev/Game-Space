using AutoMapper;
using GameSpace.Data;
using GameSpace.Data.Models;
using GameSpace.Interfaces;
using GameSpace.Models.Games;

namespace GameSpace.Services
{
    public class GameService: IGameService
    {
        private readonly GameSpaceDbContext gameSpaceDbContext;

        public GameService(GameSpaceDbContext gameSpaceDbContext)
        {
            this.gameSpaceDbContext = gameSpaceDbContext;
        }

        public void AddGame(AddGameFormModel input)
        {
            var game = new Game
            {
                Name = input.Name,
                Description = input.Description,
                ImageUrl = input.ImageUrl,
                Year = input.Year,
                CategoryId = input.CategoryId, 
            };

            gameSpaceDbContext.Games.Add(game);
            gameSpaceDbContext.SaveChanges();
        }
    }
}
