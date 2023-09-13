using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MediscreenWebUI.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDefaultRolesAndUSersAndUserRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Specialty",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "46e5faf4-44cd-4809-bb6a-eef9f23ec6a0", null, "Scheduler", "SCHEDULER" },
                    { "8f036251-fdf3-4f03-b890-90b06e55b014", null, "Doctor", "DOCTOR" },
                    { "be93fbd7-6349-4274-bb88-7a970752e53c", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0cc28956-1a8c-48cd-8ca0-17f63fa43488", 0, "25379286-94a2-4bce-afe7-82f15b249158", "admin@localhost.com", true, "System", "Administrator", false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEIPRSx4tsxILb1ltQ1z5gGbRmjWC7Dbsk4VnB0unLwUD/ObEB8LOn4xplhfmerf/gQ==", null, false, "a7eaa985-3082-40f0-a1d9-8377cadf918f", false, "admin@localhost.com" },
                    { "23b3144a-e506-469a-a5f7-4df5def8a698", 0, "4d51ca97-afef-4963-ab8a-3815a3c22ded", "doctor@localhost.com", true, "System", "Doctor", false, null, "DOCTOR@LOCALHOST.COM", "DOCTOR@LOCALHOST.COM", "AQAAAAIAAYagAAAAEApICouCDJ+6CD9zKLQrI8pSTUfDkgt+wO82g1lgGz62wE5nDJCz0gPP4eiSq/dKsA==", null, false, "7a6269da-4918-4753-bbb6-89aead9b2382", false, "doctor@localhost.com" },
                    { "693eaea0-4a6c-4ff2-8f65-18be5aac2546", 0, "1d73ff7f-ffb2-4501-a76b-cbc99ef9d3dc", "scheduler@localhost.com", true, "System", "Scheduler", false, null, "SCHEDULER@LOCALHOST.COM", "SCHEDULER@LOCALHOST.COM", "AQAAAAIAAYagAAAAEF6mdS9n9GIanxJQp3AxZ8qeS0sCBNC1O0CKx5lXC0ZJ1RDGBzMAz7NykSCXxrBX0Q==", null, false, "8f9a7ec7-eb43-4f89-8952-52a934467ad6", false, "scheduler@localhost.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "be93fbd7-6349-4274-bb88-7a970752e53c", "0cc28956-1a8c-48cd-8ca0-17f63fa43488" },
                    { "8f036251-fdf3-4f03-b890-90b06e55b014", "23b3144a-e506-469a-a5f7-4df5def8a698" },
                    { "46e5faf4-44cd-4809-bb6a-eef9f23ec6a0", "693eaea0-4a6c-4ff2-8f65-18be5aac2546" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "be93fbd7-6349-4274-bb88-7a970752e53c", "0cc28956-1a8c-48cd-8ca0-17f63fa43488" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8f036251-fdf3-4f03-b890-90b06e55b014", "23b3144a-e506-469a-a5f7-4df5def8a698" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "46e5faf4-44cd-4809-bb6a-eef9f23ec6a0", "693eaea0-4a6c-4ff2-8f65-18be5aac2546" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46e5faf4-44cd-4809-bb6a-eef9f23ec6a0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f036251-fdf3-4f03-b890-90b06e55b014");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be93fbd7-6349-4274-bb88-7a970752e53c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0cc28956-1a8c-48cd-8ca0-17f63fa43488");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "23b3144a-e506-469a-a5f7-4df5def8a698");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "693eaea0-4a6c-4ff2-8f65-18be5aac2546");

            migrationBuilder.AddColumn<string>(
                name: "Specialty",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
    }
}
