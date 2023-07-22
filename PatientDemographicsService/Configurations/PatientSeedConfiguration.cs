using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PatientDemographicsService.Models;

namespace PatientDemographicsService.Configurations
{
    public class PatientSeedConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasData(
                new Patient
                {
                    Id = 1,
                    FirstName = "Lucas",
                    LastName = "Ferguson",
                    DateOfBirth = new DateTime(1968, 06, 22),
                    Sex = 'M',
                    HomeAdress = "2 Warren Street",
                    PhoneNumber = "387-866-1399"
                },
                new Patient
                {
                    Id = 2,
                    FirstName = "Pippa",
                    LastName = "Rees",
                    DateOfBirth = new DateTime(1952, 09, 27),
                    Sex = 'F',
                    HomeAdress = "745 West Valley Farms Drive",
                    PhoneNumber = "628-423-0993"
                },
                new Patient
                {
                    Id = 3,
                    FirstName = "Edward",
                    LastName = "Arnold",
                    DateOfBirth = new DateTime(1952, 11, 11),
                    Sex = 'M',
                    HomeAdress = "599 East Garden Ave",
                    PhoneNumber = "123-727-2779"
                },
                new Patient
                {
                    Id = 4,
                    FirstName = "Anthony",
                    LastName = "Sharp",
                    DateOfBirth = new DateTime(1946, 11, 26),
                    HomeAdress = "894 Hall Street",
                    Sex = 'M',
                    PhoneNumber = "451-761-8383"
                },
                new Patient
                {
                    Id = 5,
                    FirstName = "Wendy",
                    LastName = "Ince",
                    DateOfBirth = new DateTime(1958, 06, 29),
                    Sex = 'F',
                    HomeAdress = "4 Southampton Road",
                    PhoneNumber = "802-911-9975"
                },
                new Patient
                {
                    Id = 6,
                    FirstName = "Tracey",
                    LastName = "Ross",
                    DateOfBirth = new DateTime(1949, 12, 07),
                    Sex = 'F',
                    HomeAdress = "40 Sulphur Springs Dr",
                    PhoneNumber = "131-396-5049"
                },
                new Patient
                {
                    Id = 7,
                    FirstName = "Claire",
                    LastName = "Wilson",
                    DateOfBirth = new DateTime(1966, 12, 31),
                    Sex = 'F',
                    HomeAdress = "12 Cobblestone St",
                    PhoneNumber = "300-452-1091"
                },
                new Patient
                {
                    Id = 8,
                    FirstName = "Max",
                    LastName = "Buckland",
                    DateOfBirth = new DateTime(1945, 06, 24),
                    Sex = 'M',
                    HomeAdress = "193 Vale St",
                    PhoneNumber = "833-534-0864"
                },
                new Patient
                {
                    Id = 9,
                    FirstName = "Natalie",
                    LastName = "Clark",
                    DateOfBirth = new DateTime(1964, 06, 18),
                    Sex = 'F',
                    HomeAdress = "12 Beechwood Road",
                    PhoneNumber = "241-467-9197"
                },
                 new Patient
                 {
                     Id = 10,
                     FirstName = "Piers",
                     LastName = "Bailey",
                     DateOfBirth = new DateTime(1954, 06, 28),
                     Sex = 'M',
                     HomeAdress = "1202 Bumble Dr",
                     PhoneNumber = "747-815-0557"
                 }
             );
        }
    }
}