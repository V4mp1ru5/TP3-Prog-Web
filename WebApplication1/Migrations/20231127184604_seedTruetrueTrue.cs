using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class seedTruetrueTrue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c4c48a07-fcdd-4956-831f-67b5a3599021", "AQAAAAIAAYagAAAAEOSfpjq8107KuDInCenMETphKfA1v41sugOMgalq08ZCDgP4NeROFTf45Q2x6pkXDA==", "02f6fa63-48f7-4176-905b-71e22a76497c" });

            migrationBuilder.InsertData(
                table: "VoyageVoyageUser",
                columns: new[] { "VoyageUsersId", "VoyagesId" },
                values: new object[,]
                {
                    { "11111111-1111-1111-1111-111111111111", 1 },
                    { "11111111-1111-1111-1111-111111111111", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VoyageVoyageUser",
                keyColumns: new[] { "VoyageUsersId", "VoyagesId" },
                keyValues: new object[] { "11111111-1111-1111-1111-111111111111", 1 });

            migrationBuilder.DeleteData(
                table: "VoyageVoyageUser",
                keyColumns: new[] { "VoyageUsersId", "VoyagesId" },
                keyValues: new object[] { "11111111-1111-1111-1111-111111111111", 2 });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d6b456e7-7eaf-4104-aa55-3aee8a44c47a", "AQAAAAIAAYagAAAAEKkyZw1L54VuVpv7J3dpdYPjC8TI6DfaclPNBZ1VGV3PcD2x7b+mCdRljPJnRXgSNA==", "8b532367-d67b-4416-8955-c18fd0a91f64" });
        }
    }
}
