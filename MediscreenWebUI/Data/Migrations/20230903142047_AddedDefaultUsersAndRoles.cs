using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MediscreenWebUI.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedDefaultUsersAndRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "54dd22fb-c3a7-411c-a046-e36220145116", null, "Doctor", "DOCTOR" },
                    { "a797d4ac-f6e3-49b8-8ccb-572633f335e3", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Specialty", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "8dad9259-3490-430c-aff2-45ba68da0457", 0, "6018eaf9-2ccb-41f0-9164-fe35d43b8b15", "doctor@localhost.com", true, "System", "Doctor", false, null, "DOCTOR@LOCALHOST.COM", "DOCTOR@LOCALHOST.COM", "AQAAAAIAAYagAAAAEI0FnK54D7u5dvHgPJ7Vtxi2IPkMKNO5n7MxwvagWikbYrppudy9oFWu9oEvAWpjIg==", null, false, "a49784a6-9000-4d57-a0cd-577ca1feaeae", "Diabetologist", false, "doctor@localhost.com" },
                    { "cc6a9885-7ae8-43db-bbaa-bd8c57caea25", 0, "3edc9dfe-b21d-4929-86b0-30ee61eff8d1", "admin@localhost.com", true, "System", "Administrator", false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEM9gG6zDFS9JHlkYzIgKsxY/IP5h5vDGZKHkIHD1YufjxC2Y7KDeSi+mH6a+S02TZg==", null, false, "10ddb2d9-1636-4221-a6e1-89edff26d822", "none", false, "admin@localhost.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "54dd22fb-c3a7-411c-a046-e36220145116", "8dad9259-3490-430c-aff2-45ba68da0457" },
                    { "a797d4ac-f6e3-49b8-8ccb-572633f335e3", "cc6a9885-7ae8-43db-bbaa-bd8c57caea25" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "54dd22fb-c3a7-411c-a046-e36220145116", "8dad9259-3490-430c-aff2-45ba68da0457" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a797d4ac-f6e3-49b8-8ccb-572633f335e3", "cc6a9885-7ae8-43db-bbaa-bd8c57caea25" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54dd22fb-c3a7-411c-a046-e36220145116");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a797d4ac-f6e3-49b8-8ccb-572633f335e3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8dad9259-3490-430c-aff2-45ba68da0457");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cc6a9885-7ae8-43db-bbaa-bd8c57caea25");
        }
    }
}
