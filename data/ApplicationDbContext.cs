using Microsoft.EntityFrameworkCore;
using AnimalRescueApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore; 

namespace AnimalRescueApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Animal> Animals { get; set; }
    }
}