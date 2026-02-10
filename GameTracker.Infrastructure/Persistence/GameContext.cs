using GameTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameTracker.Infrastructure.Persistence
{
    public class GameContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public GameContext(DbContextOptions<GameContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Game>(entity =>
            {
                entity.HasKey(g => g.Id);
                entity.Property(g => g.Title).IsRequired();
                entity.Property(g => g.Platform).HasConversion<string>();
                entity.Property(g => g.Status).HasConversion<string>();
                entity.Property(g => g.Rating).HasConversion<int>();
                entity.Property(g => g.playtimeHours);
            });
        }
    }
}
