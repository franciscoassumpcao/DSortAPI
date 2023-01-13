using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DSortAPI.Migrations
{
    /// <inheritdoc />
    public partial class attachmentScan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "filePath",
                table: "Scans");

            migrationBuilder.AddColumn<byte[]>(
                name: "Attachment",
                table: "Scans",
                type: "varbinary(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Attachment",
                table: "Scans");

            migrationBuilder.AddColumn<string>(
                name: "filePath",
                table: "Scans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
