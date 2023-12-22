using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class seed2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MimeType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "54eb003a-6de5-4ddf-8e2d-78b5ffc2ef02", "AQAAAAIAAYagAAAAEI0BFoYtMQBarTRzym4mXdlH/I+uWQOWmNdRUYmzf8XU5HvOhAUaqVcRN90+ARGZcA==", "97883d4f-5221-491d-bf8f-d42384b44356" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "057d1ccf-b496-41ad-a625-604063209698", "AQAAAAIAAYagAAAAECi/I12uD9X2y/PcnNC2YZd7/PDs6NaO+s2RmT7eMTUIj3bKNsjHNZYfxOd01llQeA==", "75251976-aed5-48d0-aeb0-86f5cb37e6ef" });
        }
    }
}
