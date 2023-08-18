﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PatientDemographicsService.Models;

#nullable disable

namespace PatientDemographicsService.Migrations
{
    [DbContext(typeof(MediscreenDbContext))]
    partial class MediscreenDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PatientDemographicsService.Models.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HomeAdress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("Id");

                    b.ToTable("Patients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateOfBirth = new DateTime(1968, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Lucas",
                            HomeAdress = "2 Warren Street",
                            LastName = "Ferguson",
                            PhoneNumber = "387-866-1399",
                            Sex = "M"
                        },
                        new
                        {
                            Id = 2,
                            DateOfBirth = new DateTime(1952, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Pippa",
                            HomeAdress = "745 West Valley Farms Drive",
                            LastName = "Rees",
                            PhoneNumber = "628-423-0993",
                            Sex = "F"
                        },
                        new
                        {
                            Id = 3,
                            DateOfBirth = new DateTime(1952, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Edward",
                            HomeAdress = "599 East Garden Ave",
                            LastName = "Arnold",
                            PhoneNumber = "123-727-2779",
                            Sex = "M"
                        },
                        new
                        {
                            Id = 4,
                            DateOfBirth = new DateTime(1946, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Anthony",
                            HomeAdress = "894 Hall Street",
                            LastName = "Sharp",
                            PhoneNumber = "451-761-8383",
                            Sex = "M"
                        },
                        new
                        {
                            Id = 5,
                            DateOfBirth = new DateTime(1958, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Wendy",
                            HomeAdress = "4 Southampton Road",
                            LastName = "Ince",
                            PhoneNumber = "802-911-9975",
                            Sex = "F"
                        },
                        new
                        {
                            Id = 6,
                            DateOfBirth = new DateTime(1949, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Tracey",
                            HomeAdress = "40 Sulphur Springs Dr",
                            LastName = "Ross",
                            PhoneNumber = "131-396-5049",
                            Sex = "F"
                        },
                        new
                        {
                            Id = 7,
                            DateOfBirth = new DateTime(1966, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Claire",
                            HomeAdress = "12 Cobblestone St",
                            LastName = "Wilson",
                            PhoneNumber = "300-452-1091",
                            Sex = "F"
                        },
                        new
                        {
                            Id = 8,
                            DateOfBirth = new DateTime(1945, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Max",
                            HomeAdress = "193 Vale St",
                            LastName = "Buckland",
                            PhoneNumber = "833-534-0864",
                            Sex = "M"
                        },
                        new
                        {
                            Id = 9,
                            DateOfBirth = new DateTime(1964, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Natalie",
                            HomeAdress = "12 Beechwood Road",
                            LastName = "Clark",
                            PhoneNumber = "241-467-9197",
                            Sex = "F"
                        },
                        new
                        {
                            Id = 10,
                            DateOfBirth = new DateTime(1954, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Piers",
                            HomeAdress = "1202 Bumble Dr",
                            LastName = "Bailey",
                            PhoneNumber = "747-815-0557",
                            Sex = "M"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
