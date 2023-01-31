using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DSortAPI.Migrations
{
    /// <inheritdoc />
    public partial class scanfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ScanPath",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScanPath",
                table: "Documents");
        }
    }
}
