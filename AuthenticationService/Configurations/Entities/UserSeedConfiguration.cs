using AuthenticationService.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthenticationService.Configurations.Entities
{
    public class UserSeedConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            var hasher = new PasswordHasher<Doctor>();

            builder.HasData(
                new Doctor
                {
                    Id = "78ceef92-e0e6-4a33-9b02-52a19351a6ac",
                    FirstName = "System",
                    LastName = "Admin",
                    Specialty = "none",
                    UserName= "admin@localhost.com",
                    NormalizedUserName= "ADMIN@LOCALHOST.COM",
                    Email = "admin@localhost.com",
                    NormalizedEmail = "ADMIN@LOCALHOST.COM",
                    PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                    EmailConfirmed = true
                },
                new Doctor
                {
                    Id = "f677742b-3b4d-454c-9719-7844a2692651",
                    FirstName = "System",
                    LastName = "Doctor",
                    Specialty = "diabetologist",
                    UserName = "doctor@localhost.com",
                    NormalizedUserName = "DOCTOR@LOCALHOST.COM",
                    Email = "doctor@localhost.com",
                    NormalizedEmail = "DOCTOR@LOCALHOST.COM",
                    PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                    EmailConfirmed = true
                }
            );
        }
    }
}
