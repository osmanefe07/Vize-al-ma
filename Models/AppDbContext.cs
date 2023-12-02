using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VizeÇalışma.Controllers;

namespace VizeÇalışma.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }

        public DbSet<Car> Cars { get; set; }

        
    }
}
