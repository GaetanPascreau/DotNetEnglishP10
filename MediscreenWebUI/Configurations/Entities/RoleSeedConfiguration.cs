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
                    Id = "ba59f0f7-5f9a-4c17-a14f-06a48c61b172",
                    Name = Roles.Administrator,
                    NormalizedName = Roles.Administrator.ToUpper()
                },
                new IdentityRole
                {
                    Id = "8d20b755-5c8f-40e4-9d41-39e899c15f6d",
                    Name = Roles.Doctor,
                    NormalizedName = Roles.Doctor.ToUpper()
                }
            );
        }
    }
}
