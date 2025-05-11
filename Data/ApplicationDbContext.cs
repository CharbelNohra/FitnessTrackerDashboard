using Microsoft.EntityFrameworkCore;
using FitnessTrackerDashboard.Models;

namespace FitnessTrackerDashboard.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<FitnessEntry> FitnessEntries { get; set; }
    }
}
