using MediscreenWebUI.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediscreenWebUI.Configurations.Entities
{
    public class UserSeedConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            var hasher = new PasswordHasher<Doctor>();
            builder.HasData(
                new Doctor 
                {
                    Id = "e8955c70-c7f3-4206-8f83-c21422e83988",
                    FirstName = "System",
                    LastName = "Administrator",
                    Specialty = "none",
                    Email = "admin@localhost.com",
                    NormalizedEmail = "ADMIN@LOCALHOST.COM",
                    UserName = "admin@localhost.com",
                    NormalizedUserName = "ADMIN@LOCALHOST.COM",
                    PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                    EmailConfirmed = true
                },
                new Doctor
                {
                    Id = "21dd7821-00bc-47b6-bf1d-ed0be1f0cd77",
                    FirstName = "System",
                    LastName = "Doctor",
                    Specialty = "Diabetologist",
                    Email = "doctor@localhost.com",
                    NormalizedEmail = "DOCTOR@LOCALHOST.COM",
                    UserName = "doctor@localhost.com",
                    NormalizedUserName = "DOCTOR@LOCALHOST.COM",
                    PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                    EmailConfirmed = true
                }
            );
        }
    }
}
