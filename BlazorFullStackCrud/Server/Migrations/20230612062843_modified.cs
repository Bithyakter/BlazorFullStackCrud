using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorFullStackCrud.Server.Migrations
{
    /// <inheritdoc />
    public partial class modified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_superHeroes_comics_ComicId",
                table: "superHeroes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_superHeroes",
                table: "superHeroes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_comics",
                table: "comics");

            migrationBuilder.RenameTable(
                name: "superHeroes",
                newName: "SuperHeroes");

            migrationBuilder.RenameTable(
                name: "comics",
                newName: "Comics");

            migrationBuilder.RenameIndex(
                name: "IX_superHeroes_ComicId",
                table: "SuperHeroes",
                newName: "IX_SuperHeroes_ComicId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SuperHeroes",
                table: "SuperHeroes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comics",
                table: "Comics",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SuperHeroes_Comics_ComicId",
                table: "SuperHeroes",
                column: "ComicId",
                principalTable: "Comics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SuperHeroes_Comics_ComicId",
                table: "SuperHeroes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SuperHeroes",
                table: "SuperHeroes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comics",
                table: "Comics");

            migrationBuilder.RenameTable(
                name: "SuperHeroes",
                newName: "superHeroes");

            migrationBuilder.RenameTable(
                name: "Comics",
                newName: "comics");

            migrationBuilder.RenameIndex(
                name: "IX_SuperHeroes_ComicId",
                table: "superHeroes",
                newName: "IX_superHeroes_ComicId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_superHeroes",
                table: "superHeroes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_comics",
                table: "comics",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_superHeroes_comics_ComicId",
                table: "superHeroes",
                column: "ComicId",
                principalTable: "comics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
