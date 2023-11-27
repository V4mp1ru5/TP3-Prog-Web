using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class seedTruetrue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "11111111-1111-1111-1111-111111111111", 0, "d6b456e7-7eaf-4104-aa55-3aee8a44c47a", "jim@test.com", false, false, null, "JIM@TEST.COM", "JIM@TEST.COM", "AQAAAAIAAYagAAAAEKkyZw1L54VuVpv7J3dpdYPjC8TI6DfaclPNBZ1VGV3PcD2x7b+mCdRljPJnRXgSNA==", null, false, "8b532367-d67b-4416-8955-c18fd0a91f64", false, "jim@test.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111");
        }
    }
}
