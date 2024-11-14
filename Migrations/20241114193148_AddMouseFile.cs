using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MouseApi.Migrations
{
    /// <inheritdoc />
    public partial class AddMouseFile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "File",
                table: "MouseItems");

            migrationBuilder.AddColumn<long>(
                name: "MouseFileId",
                table: "MouseItems",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MouseFile",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FileName = table.Column<string>(type: "TEXT", nullable: false),
                    MimeType = table.Column<string>(type: "TEXT", nullable: false),
                    Content = table.Column<byte[]>(type: "BLOB", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MouseFile", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MouseItems_MouseFileId",
                table: "MouseItems",
                column: "MouseFileId");

            migrationBuilder.AddForeignKey(
                name: "FK_MouseItems_MouseFile_MouseFileId",
                table: "MouseItems",
                column: "MouseFileId",
                principalTable: "MouseFile",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MouseItems_MouseFile_MouseFileId",
                table: "MouseItems");

            migrationBuilder.DropTable(
                name: "MouseFile");

            migrationBuilder.DropIndex(
                name: "IX_MouseItems_MouseFileId",
                table: "MouseItems");

            migrationBuilder.DropColumn(
                name: "MouseFileId",
                table: "MouseItems");

            migrationBuilder.AddColumn<byte[]>(
                name: "File",
                table: "MouseItems",
                type: "BLOB",
                nullable: true);
        }
    }
}
