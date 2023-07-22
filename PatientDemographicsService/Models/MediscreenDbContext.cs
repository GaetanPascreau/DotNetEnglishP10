using Microsoft.EntityFrameworkCore;

namespace PatientDemographicsService.Models
{
    public class MediscreenDbContext : DbContext
    {
        public MediscreenDbContext(DbContextOptions<MediscreenDbContext> options) : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
