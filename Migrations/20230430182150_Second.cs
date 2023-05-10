using Microsoft.EntityFrameworkCore.Migrations;

namespace LabWork.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddPrimaryKey(
                name: "PK_publisher_has_game",
                table: "publisher_has_game",
                columns: new[] { "gameId", "publisherId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Game_has_genre",
                table: "Game_has_genre",
                columns: new[] { "gameId", "genreId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_developer_has_game",
                table: "developer_has_game",
                columns: new[] { "gameId", "developerId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_publisher_has_game",
                table: "publisher_has_game");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Game_has_genre",
                table: "Game_has_genre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_developer_has_game",
                table: "developer_has_game");
        }
    }
}
