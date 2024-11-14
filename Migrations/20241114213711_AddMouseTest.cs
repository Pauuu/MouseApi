using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MouseApi.Migrations
{
    /// <inheritdoc />
    public partial class AddMouseTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "MouseTestId",
                table: "MouseItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "MouseAloneFile",
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
                    table.PrimaryKey("PK_MouseAloneFile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MouseTest",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    test = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MouseTest", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MouseItems_MouseTestId",
                table: "MouseItems",
                column: "MouseTestId");

            migrationBuilder.AddForeignKey(
                name: "FK_MouseItems_MouseTest_MouseTestId",
                table: "MouseItems",
                column: "MouseTestId",
                principalTable: "MouseTest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MouseItems_MouseTest_MouseTestId",
                table: "MouseItems");

            migrationBuilder.DropTable(
                name: "MouseAloneFile");

            migrationBuilder.DropTable(
                name: "MouseTest");

            migrationBuilder.DropIndex(
                name: "IX_MouseItems_MouseTestId",
                table: "MouseItems");

            migrationBuilder.DropColumn(
                name: "MouseTestId",
                table: "MouseItems");
        }
    }
}
