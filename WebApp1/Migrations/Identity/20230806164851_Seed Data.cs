using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp1.Migrations.Identity
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f95877b-abc3-4d10-bbb1-c4bac2c3867b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "84fc7554-e6b6-42d2-8825-e0f3b6a5174a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d01734b4-4c7f-47b7-b83a-d24aa824418f", null, "System Administrator", "SYSTEM ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CompanyName", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "ImageUrl", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0d7da673-8fcd-470e-b502-c1a54fe38cf5", 0, null, "173a2ca5-3bc1-485f-b665-a502f79ffe75", "administrator@domain.com", false, "", null, "", false, null, null, null, "AQAAAAIAAYagAAAAEGP5ljAkEnz4j3l+qgTTmUpISJMJN+BHayWumcGGbTuRTr4CogO+NwusuOetmy5p2Q==", null, false, "803448c8-2063-47e0-81f5-42d2b272a6ad", false, "administrator@domain.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d01734b4-4c7f-47b7-b83a-d24aa824418f", "0d7da673-8fcd-470e-b502-c1a54fe38cf5" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d01734b4-4c7f-47b7-b83a-d24aa824418f", "0d7da673-8fcd-470e-b502-c1a54fe38cf5" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d01734b4-4c7f-47b7-b83a-d24aa824418f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0d7da673-8fcd-470e-b502-c1a54fe38cf5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1f95877b-abc3-4d10-bbb1-c4bac2c3867b", null, "System Administrator", "SYSTEM ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CompanyName", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "ImageUrl", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "84fc7554-e6b6-42d2-8825-e0f3b6a5174a", 0, null, "7660ded0-9eb3-4cdd-8559-f74a3dc2cbad", null, false, "System", null, "Administrator", false, null, null, null, "AQAAAAIAAYagAAAAEOlvmyTBdxBeGlvJLrbWP+0DXbV3fWtLDDSRQJJ5O4IWFNx0KG0FWtwEPgiwY463YQ==", null, false, "fa7aee85-94f1-485e-bc13-78b412de9205", false, "administrator" });
        }
    }
}
