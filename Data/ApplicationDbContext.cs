using CarpoolAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarpoolAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Drive> Drives { get; set; }
    }
}
