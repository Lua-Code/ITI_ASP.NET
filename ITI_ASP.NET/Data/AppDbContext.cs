using Microsoft.EntityFrameworkCore;
using ITI_ASP.NET.Models;

namespace ITI_ASP.NET.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
