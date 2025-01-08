using Microsoft.EntityFrameworkCore;
using VideogameApi.Models;

namespace VideogameApi.Data
{
    public class PlayerDbContext(DbContextOptions<PlayerDbContext> options) : DbContext(options)
    {
        public DbSet<Player> Players => Set<Player>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Player>().HasData(
                new Player
                {
                    Id = 1,
                    Level = 0,
                    Name = "Spencer",
                    Score = 0,
                },
                new Player
                {
                    Id = 2,
                    Level = 0,
                    Name = "Harold",
                    Score = 0,
                },
                new Player
                {
                    Id = 3,
                    Level = 0,
                    Name = "Jacob",
                    Score = 0,
                }
            );
        }
    }
}
