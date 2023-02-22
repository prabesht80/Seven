using Microsoft.EntityFrameworkCore;
using Seven.Models;

namespace Seven.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext>options):base(options) { }
        public DbSet<LoginData>logins { get; set; }
    }
}
