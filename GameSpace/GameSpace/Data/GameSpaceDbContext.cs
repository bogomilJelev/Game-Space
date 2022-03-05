using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GameSpace.Data
{
    public class GameSpaceDbContext : IdentityDbContext
    {
        public GameSpaceDbContext(DbContextOptions<GameSpaceDbContext> options)
            : base(options)
        {
        }
    }
}