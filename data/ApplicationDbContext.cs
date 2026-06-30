using Microsoft.EntityFrameworkCore;
using AnimalRescueApp.Models;

namespace AnimalRescueApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Animal> Animals { get; set; }
    }
}