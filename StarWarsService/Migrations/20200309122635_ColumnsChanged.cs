using Microsoft.EntityFrameworkCore.Migrations;

namespace StarWarsService.Migrations
{
    public partial class ColumnsChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EpisodeId",
                table: "Episode",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CharacterId",
                table: "Character",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Episode",
                newName: "EpisodeId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Character",
                newName: "CharacterId");
        }
    }
}
