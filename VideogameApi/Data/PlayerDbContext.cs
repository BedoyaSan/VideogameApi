using Microsoft.EntityFrameworkCore;
using VideogameApi.Models;

namespace VideogameApi.Data
{
    public class PlayerDbContext(DbContextOptions<PlayerDbContext> options): DbContext(options)
    {
        public DbSet<Player> Players => Set<Player>();
    }
}
