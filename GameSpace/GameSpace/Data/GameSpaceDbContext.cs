﻿using GameSpace.Data.Models;
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
                

            base.OnModelCreating(builder);
        }
        public DbSet<Game> Games { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}