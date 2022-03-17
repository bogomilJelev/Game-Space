using GameSpace.Data;
using GameSpace.Data.Models;

namespace GameSpace.Infrastrocture
{
    public static class AppBuilderExtL 
    {
        public static IApplicationBuilder PreppDb (this IApplicationBuilder app)
        {
            using var scopedService = app.ApplicationServices.CreateScope();
            var data = scopedService.ServiceProvider.GetService<GameSpaceDbContext>();
            SeedCategory(data);
            return app;
        }
        private static void SeedCategory(GameSpaceDbContext data)
        {
            if (data.Categories.Any())
            {
                return;
            }
            data.Categories.AddRange(new []
            {
                new Category { Name = "Horror" },
                new Category { Name = "Rpg" },
                new Category { Name = "Fps" },
                new Category { Name = "Fighting" },
                new Category { Name = "MMORPG" },
                new Category { Name = "Strategy " },
            });
        }
    }
}
