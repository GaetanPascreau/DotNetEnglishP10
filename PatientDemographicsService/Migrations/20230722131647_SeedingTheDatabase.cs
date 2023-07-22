using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PatientDemographicsService.Migrations
{
    /// <inheritdoc />
    public partial class SeedingTheDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "DateOfBirth", "FirstName", "HomeAdress", "LastName", "PhoneNumber", "Sex" },
                values: new object[,]
                {
                    { 1, new DateTime(1968, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lucas", "2 Warren Street", "Ferguson", "387-866-1399", "M" },
                    { 2, new DateTime(1952, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pippa", "745 West Valley Farms Drive", "Rees", "628-423-0993", "F" },
                    { 3, new DateTime(1952, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Edward", "599 East Garden Ave", "Arnold", "123-727-2779", "M" },
                    { 4, new DateTime(1946, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anthony", "894 Hall Street", "Sharp", "451-761-8383", "M" },
                    { 5, new DateTime(1958, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wendy", "4 Southampton Road", "Ince", "802-911-9975", "F" },
                    { 6, new DateTime(1949, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tracey", "40 Sulphur Springs Dr", "Ross", "131-396-5049", "F" },
                    { 7, new DateTime(1966, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Claire", "12 Cobblestone St", "Wilson", "300-452-1091", "F" },
                    { 8, new DateTime(1945, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Max", "193 Vale St", "Buckland", "833-534-0864", "M" },
                    { 9, new DateTime(1964, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Natalie", "12 Beechwood Road", "Clark", "241-467-9197", "F" },
                    { 10, new DateTime(1954, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Piers", "1202 Bumble Dr", "Bailey", "747-815-0557", "M" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
