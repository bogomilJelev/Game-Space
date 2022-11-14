using GameSpace.Data.Models;
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
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Game>()
                .HasOne(e=>e.Category)
                .WithMany(e=>e.Games)
                .HasForeignKey(e=>e.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
            
            
            builder.Entity<Game>()
                .HasMany(r=>r.Rates)
                .WithOne(r=>r.Game)
                .OnDelete(DeleteBehavior.Restrict)
                ;


            base.OnModelCreating(builder);
        }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Game> Games { get; set; }
    }
}