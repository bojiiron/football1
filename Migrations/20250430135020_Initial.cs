using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Football.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "coaches",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__coaches__3213E83FBE8D649A", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "leagues",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__leagues__3213E83FC1AF64E4", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "nationality",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    best_player = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__national__3213E83F76AEBCE6", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "teams",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    league_id = table.Column<int>(type: "int", nullable: true),
                    coaches_id = table.Column<int>(type: "int", nullable: true),
                    trophies = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__teams__3213E83F83079E49", x => x.id);
                    table.ForeignKey(
                        name: "FK__teams__coaches_i__2B3F6F97",
                        column: x => x.coaches_id,
                        principalTable: "coaches",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__teams__league_id__2A4B4B5E",
                        column: x => x.league_id,
                        principalTable: "leagues",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "players",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    team_id = table.Column<int>(type: "int", nullable: false),
                    nationality_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__players__3213E83FA51948D5", x => x.id);
                    table.ForeignKey(
                        name: "FK__players__nationa__2F10007B",
                        column: x => x.nationality_id,
                        principalTable: "nationality",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__players__team_id__2E1BDC42",
                        column: x => x.team_id,
                        principalTable: "teams",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "player_teams",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    players_id = table.Column<int>(type: "int", nullable: false),
                    team_id = table.Column<int>(type: "int", nullable: false),
                    salary = table.Column<int>(type: "int", nullable: false),
                    months_active = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__player_t__3213E83F14B7283F", x => x.id);
                    table.ForeignKey(
                        name: "FK__player_te__playe__31EC6D26",
                        column: x => x.players_id,
                        principalTable: "players",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__player_te__team___32E0915F",
                        column: x => x.team_id,
                        principalTable: "teams",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_player_teams_players_id",
                table: "player_teams",
                column: "players_id");

            migrationBuilder.CreateIndex(
                name: "IX_player_teams_team_id",
                table: "player_teams",
                column: "team_id");

            migrationBuilder.CreateIndex(
                name: "IX_players_nationality_id",
                table: "players",
                column: "nationality_id");

            migrationBuilder.CreateIndex(
                name: "IX_players_team_id",
                table: "players",
                column: "team_id");

            migrationBuilder.CreateIndex(
                name: "IX_teams_coaches_id",
                table: "teams",
                column: "coaches_id");

            migrationBuilder.CreateIndex(
                name: "IX_teams_league_id",
                table: "teams",
                column: "league_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "player_teams");

            migrationBuilder.DropTable(
                name: "players");

            migrationBuilder.DropTable(
                name: "nationality");

            migrationBuilder.DropTable(
                name: "teams");

            migrationBuilder.DropTable(
                name: "coaches");

            migrationBuilder.DropTable(
                name: "leagues");
        }
    }
}
