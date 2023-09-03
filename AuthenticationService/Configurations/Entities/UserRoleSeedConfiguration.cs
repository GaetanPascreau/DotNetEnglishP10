using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthenticationService.Configurations.Entities
{
    public class UserRoleSeedConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "5a705804-cec4-461f-886c-d7fff06e2a6b",
                    UserId = "78ceef92-e0e6-4a33-9b02-52a19351a6ac"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "3ea342f0-a7f8-4cb5-82eb-acb4e2b2e609",
                    UserId = "f677742b-3b4d-454c-9719-7844a2692651"
                }
            );
        }
    }
}
