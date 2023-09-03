using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthenticationService.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedVAlidDefaultUsersAndRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "78ceef92-e0e6-4a33-9b02-52a19351a6ac",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "ec85d1c6-1996-47fc-b6d7-7167a294f937", true, "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAELoJK26DuPz3mRUL2eWm1MSTXBIjs1vsOOGa021rprMW3k2q78UZvkuZy/a85Vhn6A==", "3630f072-e83a-4002-a794-848b269637ca", "admin@localhost.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f677742b-3b4d-454c-9719-7844a2692651",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "4e112ae6-38c6-402e-a860-10d1783db6c8", true, "DOCTOR@LOCALHOST.COM", "AQAAAAIAAYagAAAAEFeby2GBndV5ak8d9A+N73eK2qNVAcFQqTqdm/69CfUvpnfQe9poECYBXN14Lun3Aw==", "81b1f2f3-c1e0-456e-890c-6df43062bb3c", "doctor@localhost.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "78ceef92-e0e6-4a33-9b02-52a19351a6ac",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "df8412c2-fb2b-4de8-be53-386f7f9566ca", false, null, "AQAAAAIAAYagAAAAEE3eCV0PJQ8etCx5+U1h3DiA6h1YjIYJZFfDo7wQEXeVCv++FDqtEhIEnyumpiyNmw==", "9c5392ac-deb2-4f12-98b2-d1066452fd5e", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f677742b-3b4d-454c-9719-7844a2692651",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "067bda01-cea4-412f-94f6-742ca83572b8", false, null, "AQAAAAIAAYagAAAAEGUhpMNGscTQw2jpQv6lPvPh5WF89r2VO+lO0i7ZJ4IXjgeIZ98IQxyRoQBWD80ODg==", "dfdcba52-e219-4614-b3cd-ff3bac91d16f", null });
        }
    }
}
