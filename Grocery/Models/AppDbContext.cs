using Microsoft.EntityFrameworkCore;
using Grocery.Models;

namespace Grocery.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
                : base(options)
        {
        }
        public DbSet<Grocery> Grocery { get; set; }
    }
}