using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MediscreenWebUI.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedDefaultUsersAndRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8d20b755-5c8f-40e4-9d41-39e899c15f6d", null, "Doctor", "DOCTOR" },
                    { "ba59f0f7-5f9a-4c17-a14f-06a48c61b172", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Specialty", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "21dd7821-00bc-47b6-bf1d-ed0be1f0cd77", 0, "4f32ab0d-4726-40ef-bb7c-5b893abfa806", "doctor@localhost.com", true, "System", "Doctor", false, null, "DOCTOR@LOCALHOST.COM", "DOCTOR@LOCALHOST.COM", "AQAAAAIAAYagAAAAEFEwjwb9sK5xERgDzZulrUQoQxGmjyXN8/1+VBEuZmR9UR/fQLYGbQTTFsqGxVDxwA==", null, false, "866e1b15-3b7b-4d57-9644-f7758a5c2b0c", "Diabetologist", false, "doctor@localhost.com" },
                    { "e8955c70-c7f3-4206-8f83-c21422e83988", 0, "72a9aa76-6680-40b6-bd15-5075439c9f0c", "admin@localhost.com", true, "System", "Administrator", false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEPRZ30yhhKozRONFhFtWtfDeRCHjI5VMSfFL0tQvef2fA6FI3YU+764AJ7vptlnzzw==", null, false, "57c7e95a-6cce-4607-b8df-815181e14762", "none", false, "admin@localhost.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "8d20b755-5c8f-40e4-9d41-39e899c15f6d", "21dd7821-00bc-47b6-bf1d-ed0be1f0cd77" },
                    { "ba59f0f7-5f9a-4c17-a14f-06a48c61b172", "e8955c70-c7f3-4206-8f83-c21422e83988" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8d20b755-5c8f-40e4-9d41-39e899c15f6d", "21dd7821-00bc-47b6-bf1d-ed0be1f0cd77" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ba59f0f7-5f9a-4c17-a14f-06a48c61b172", "e8955c70-c7f3-4206-8f83-c21422e83988" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d20b755-5c8f-40e4-9d41-39e899c15f6d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba59f0f7-5f9a-4c17-a14f-06a48c61b172");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21dd7821-00bc-47b6-bf1d-ed0be1f0cd77");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e8955c70-c7f3-4206-8f83-c21422e83988");

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
    }
}
