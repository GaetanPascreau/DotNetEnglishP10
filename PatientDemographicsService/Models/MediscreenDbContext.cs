using Microsoft.EntityFrameworkCore;
using PatientDemographicsService.Configurations;

namespace PatientDemographicsService.Models
{
    public class MediscreenDbContext : DbContext
    {
        public MediscreenDbContext(DbContextOptions<MediscreenDbContext> options) : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }

        // Seed patients at building
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new PatientSeedConfiguration());
        }
    }
}
