using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediscreenWebUI.Configurations.Entities
{
    public class UserRoleSeedConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "ba59f0f7-5f9a-4c17-a14f-06a48c61b172",
                    UserId = "e8955c70-c7f3-4206-8f83-c21422e83988",
                },
                new IdentityUserRole<string>
                {
                    RoleId = "8d20b755-5c8f-40e4-9d41-39e899c15f6d",
                    UserId = "21dd7821-00bc-47b6-bf1d-ed0be1f0cd77",
                }
            );
        }
    }
}
