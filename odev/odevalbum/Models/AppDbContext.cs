using Microsoft.EntityFrameworkCore;

namespace odevalbum.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
   
        public DbSet<TabloSanat> Sanat { get; set; }
    }
   
}
