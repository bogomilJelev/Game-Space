using GameSpace.Data;
using GameSpace.Data.Models;

namespace GameSpace.Infrastrocture
{
    public static class AppBuilderExtL 
    {
        public async static Task<IApplicationBuilder> PreppDb (this IApplicationBuilder app)
        {
            using var scopedService = app.ApplicationServices.CreateScope();
            var data = scopedService.ServiceProvider.GetService<GameSpaceDbContext>();
            await SeedCategory(data);

            return app;
        }
        private static async Task SeedCategory(GameSpaceDbContext data)
        {
            if (data.Categories.Any())
                return;

            await data.Categories.AddRangeAsync(new []
            {
                new Category { Name = "Horror" },
                new Category { Name = "Rpg" },
                new Category { Name = "Fps" },
                new Category { Name = "Fighting" },
                new Category { Name = "MMORPG" },
                new Category { Name = "Strategy " },
            });

            await data.SaveChangesAsync();
        }
    }
}
