using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp1.Migrations.Identity
{
    /// <inheritdoc />
    public partial class SeedUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b0d52402-f271-49b5-b65e-7bb5b4b64bcc");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1f95877b-abc3-4d10-bbb1-c4bac2c3867b", null, "System Administrator", "SYSTEM ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CompanyName", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "ImageUrl", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "84fc7554-e6b6-42d2-8825-e0f3b6a5174a", 0, null, "7660ded0-9eb3-4cdd-8559-f74a3dc2cbad", null, false, "System", null, "Administrator", false, null, null, null, "AQAAAAIAAYagAAAAEOlvmyTBdxBeGlvJLrbWP+0DXbV3fWtLDDSRQJJ5O4IWFNx0KG0FWtwEPgiwY463YQ==", null, false, "fa7aee85-94f1-485e-bc13-78b412de9205", false, "administrator" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "b0d52402-f271-49b5-b65e-7bb5b4b64bcc", null, "System Administrator", "SYSTEM ADMINISTRATOR" });
        }
    }
}
