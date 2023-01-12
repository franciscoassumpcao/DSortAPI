using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DSortAPI.Migrations
{
    /// <inheritdoc />
    public partial class addingScanToDatacontext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scan_Documents_DocumentId",
                table: "Scan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Scan",
                table: "Scan");

            migrationBuilder.RenameTable(
                name: "Scan",
                newName: "Scans");

            migrationBuilder.RenameIndex(
                name: "IX_Scan_DocumentId",
                table: "Scans",
                newName: "IX_Scans_DocumentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Scans",
                table: "Scans",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Scans_Documents_DocumentId",
                table: "Scans",
                column: "DocumentId",
                principalTable: "Documents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scans_Documents_DocumentId",
                table: "Scans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Scans",
                table: "Scans");

            migrationBuilder.RenameTable(
                name: "Scans",
                newName: "Scan");

            migrationBuilder.RenameIndex(
                name: "IX_Scans_DocumentId",
                table: "Scan",
                newName: "IX_Scan_DocumentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Scan",
                table: "Scan",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Scan_Documents_DocumentId",
                table: "Scan",
                column: "DocumentId",
                principalTable: "Documents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
