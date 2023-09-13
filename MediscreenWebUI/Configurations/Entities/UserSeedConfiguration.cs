using MediscreenWebUI.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediscreenWebUI.Configurations.Entities
{
    public class UserSeedConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                new ApplicationUser 
                {
                    Id = "0cc28956-1a8c-48cd-8ca0-17f63fa43488",
                    FirstName = "System",
                    LastName = "Administrator",
                    Email = "admin@localhost.com",
                    NormalizedEmail = "ADMIN@LOCALHOST.COM",
                    UserName = "admin@localhost.com",
                    NormalizedUserName = "ADMIN@LOCALHOST.COM",
                    PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                    EmailConfirmed = true
                },
                new ApplicationUser
                {
                    Id = "23b3144a-e506-469a-a5f7-4df5def8a698",
                    FirstName = "System",
                    LastName = "Doctor",
                    Email = "doctor@localhost.com",
                    NormalizedEmail = "DOCTOR@LOCALHOST.COM",
                    UserName = "doctor@localhost.com",
                    NormalizedUserName = "DOCTOR@LOCALHOST.COM",
                    PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                    EmailConfirmed = true
                },
                new ApplicationUser
                {
                    Id = "693eaea0-4a6c-4ff2-8f65-18be5aac2546",
                    FirstName = "System",
                    LastName = "Scheduler",
                    Email = "scheduler@localhost.com",
                    NormalizedEmail = "SCHEDULER@LOCALHOST.COM",
                    UserName = "scheduler@localhost.com",
                    NormalizedUserName = "SCHEDULER@LOCALHOST.COM",
                    PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                    EmailConfirmed = true
                }
            );
        }
    }
}
