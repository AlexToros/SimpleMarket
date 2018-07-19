using System.Data.Entity;

namespace GameStore
{
    public class EFDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
    }
}