using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AuthenticationService.Data.Migrations
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
                    { "3ea342f0-a7f8-4cb5-82eb-acb4e2b2e609", null, "Doctor", "DOCTOR" },
                    { "5a705804-cec4-461f-886c-d7fff06e2a6b", null, "Administartor", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Specialty", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "78ceef92-e0e6-4a33-9b02-52a19351a6ac", 0, "df8412c2-fb2b-4de8-be53-386f7f9566ca", "admin@localhost.com", false, "System", "Admin", false, null, "ADMIN@LOCALHOST.COM", null, "AQAAAAIAAYagAAAAEE3eCV0PJQ8etCx5+U1h3DiA6h1YjIYJZFfDo7wQEXeVCv++FDqtEhIEnyumpiyNmw==", null, false, "9c5392ac-deb2-4f12-98b2-d1066452fd5e", "none", false, null },
                    { "f677742b-3b4d-454c-9719-7844a2692651", 0, "067bda01-cea4-412f-94f6-742ca83572b8", "doctor@localhost.com", false, "System", "Doctor", false, null, "DOCTOR@LOCALHOST.COM", null, "AQAAAAIAAYagAAAAEGUhpMNGscTQw2jpQv6lPvPh5WF89r2VO+lO0i7ZJ4IXjgeIZ98IQxyRoQBWD80ODg==", null, false, "dfdcba52-e219-4614-b3cd-ff3bac91d16f", "diabetologist", false, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "5a705804-cec4-461f-886c-d7fff06e2a6b", "78ceef92-e0e6-4a33-9b02-52a19351a6ac" },
                    { "3ea342f0-a7f8-4cb5-82eb-acb4e2b2e609", "f677742b-3b4d-454c-9719-7844a2692651" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5a705804-cec4-461f-886c-d7fff06e2a6b", "78ceef92-e0e6-4a33-9b02-52a19351a6ac" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3ea342f0-a7f8-4cb5-82eb-acb4e2b2e609", "f677742b-3b4d-454c-9719-7844a2692651" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3ea342f0-a7f8-4cb5-82eb-acb4e2b2e609");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a705804-cec4-461f-886c-d7fff06e2a6b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "78ceef92-e0e6-4a33-9b02-52a19351a6ac");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f677742b-3b4d-454c-9719-7844a2692651");
        }
    }
}
