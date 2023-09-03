using AuthenticationService.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthenticationService.Configurations.Entities
{
    public class RoleSeedConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "5a705804-cec4-461f-886c-d7fff06e2a6b",
                    Name = Roles.Administrator,
                    NormalizedName = Roles.Administrator.ToUpper(),
                },
                new IdentityRole
                {
                    Id = "3ea342f0-a7f8-4cb5-82eb-acb4e2b2e609",
                    Name = Roles.Doctor,
                    NormalizedName = Roles.Doctor.ToUpper(),
                }
            );
        }
    }
}
