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
                new IdentityUserRole<string> // Administrator
                {
                    RoleId = "be93fbd7-6349-4274-bb88-7a970752e53c",
                    UserId = "0cc28956-1a8c-48cd-8ca0-17f63fa43488",
                },
                new IdentityUserRole<string> // Doctor
                {
                    RoleId = "8f036251-fdf3-4f03-b890-90b06e55b014",
                    UserId = "23b3144a-e506-469a-a5f7-4df5def8a698",
                },
                 new IdentityUserRole<string> // Scheduler
                 {
                     RoleId = "46e5faf4-44cd-4809-bb6a-eef9f23ec6a0",
                     UserId = "693eaea0-4a6c-4ff2-8f65-18be5aac2546",
                 }
            );
        }
    }
}
