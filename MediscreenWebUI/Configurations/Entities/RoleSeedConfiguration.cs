using MediscreenWebUI.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediscreenWebUI.Configurations.Entities
{
    public class RoleSeedConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "be93fbd7-6349-4274-bb88-7a970752e53c",
                    Name = Roles.Administrator,
                    NormalizedName = Roles.Administrator.ToUpper()
                },
                new IdentityRole
                {
                    Id = "8f036251-fdf3-4f03-b890-90b06e55b014",
                    Name = Roles.Doctor,
                    NormalizedName = Roles.Doctor.ToUpper()
                },
                new IdentityRole
                {
                    Id = "46e5faf4-44cd-4809-bb6a-eef9f23ec6a0",
                    Name = Roles.Scheduler,
                    NormalizedName = Roles.Scheduler.ToUpper()
                }
            );
        }
    }
}
