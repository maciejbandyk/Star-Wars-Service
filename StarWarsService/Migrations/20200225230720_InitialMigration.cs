using Microsoft.EntityFrameworkCore.Migrations;

namespace StarWarsService.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    CharacterId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Planet = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.CharacterId);
                });

            migrationBuilder.CreateTable(
                name: "Episode",
                columns: table => new
                {
                    EpisodeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Episode", x => x.EpisodeId);
                });

            migrationBuilder.CreateTable(
                name: "CharacterFriend",
                columns: table => new
                {
                    CharacterId = table.Column<int>(nullable: false),
                    FriendId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterFriend", x => new { x.CharacterId, x.FriendId });
                    table.ForeignKey(
                        name: "FK_CharacterFriend_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterFriend_Character_FriendId",
                        column: x => x.FriendId,
                        principalTable: "Character",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CharacterEpisode",
                columns: table => new
                {
                    CharacterId = table.Column<int>(nullable: false),
                    EpisodeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterEpisode", x => new { x.CharacterId, x.EpisodeId });
                    table.ForeignKey(
                        name: "FK_CharacterEpisode_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterEpisode_Episode_EpisodeId",
                        column: x => x.EpisodeId,
                        principalTable: "Episode",
                        principalColumn: "EpisodeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Character",
                columns: new[] { "CharacterId", "Name", "Planet" },
                values: new object[,]
                {
                    { 1, "Luke Skywalker", null },
                    { 2, "Darth Vader", null },
                    { 3, "Han Solo", null },
                    { 4, "Leia Organa", "Alderaan" },
                    { 5, "Willhuff Tarkin", null },
                    { 6, "C-3PO", null },
                    { 7, "R2-D2", null }
                });

            migrationBuilder.InsertData(
                table: "Episode",
                columns: new[] { "EpisodeId", "Name" },
                values: new object[,]
                {
                    { 1, "NEWHOPE" },
                    { 2, "EMPIRE" },
                    { 3, "JEDI" }
                });

            migrationBuilder.InsertData(
                table: "CharacterEpisode",
                columns: new[] { "CharacterId", "EpisodeId" },
                values: new object[,]
                {
                    { 7, 3 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 5, 1 },
                    { 6, 1 },
                    { 7, 1 },
                    { 1, 2 },
                    { 1, 1 },
                    { 2, 2 },
                    { 4, 2 },
                    { 6, 2 },
                    { 7, 2 },
                    { 1, 3 },
                    { 2, 3 },
                    { 3, 3 },
                    { 4, 3 },
                    { 3, 2 },
                    { 6, 3 }
                });

            migrationBuilder.InsertData(
                table: "CharacterFriend",
                columns: new[] { "CharacterId", "FriendId" },
                values: new object[,]
                {
                    { 7, 4 },
                    { 7, 1 },
                    { 3, 1 },
                    { 1, 4 },
                    { 3, 4 },
                    { 4, 1 },
                    { 4, 3 },
                    { 2, 5 },
                    { 5, 2 },
                    { 7, 3 },
                    { 1, 6 },
                    { 6, 1 },
                    { 6, 3 },
                    { 6, 4 },
                    { 1, 7 },
                    { 3, 7 },
                    { 4, 7 },
                    { 6, 7 },
                    { 4, 6 },
                    { 1, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterEpisode_EpisodeId",
                table: "CharacterEpisode",
                column: "EpisodeId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterFriend_FriendId",
                table: "CharacterFriend",
                column: "FriendId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterEpisode");

            migrationBuilder.DropTable(
                name: "CharacterFriend");

            migrationBuilder.DropTable(
                name: "Episode");

            migrationBuilder.DropTable(
                name: "Character");
        }
    }
}
