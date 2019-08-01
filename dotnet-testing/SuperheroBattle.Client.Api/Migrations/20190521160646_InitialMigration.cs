using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperheroBattle.Client.Api.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abilities",
                columns: table => new
                {
                    AbilityID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abilities", x => x.AbilityID);
                });

            migrationBuilder.CreateTable(
                name: "SuperheroesNew",
                columns: table => new
                {
                    SuperheroID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SuperheroName = table.Column<string>(nullable: false),
                    SecretIdentity = table.Column<string>(nullable: true),
                    AgeAtOrigin = table.Column<int>(nullable: true),
                    YearOfAppearance = table.Column<int>(nullable: false),
                    IsAlien = table.Column<bool>(nullable: false),
                    PlanetOfOrigin = table.Column<int>(nullable: true),
                    OriginStory = table.Column<string>(nullable: true),
                    Universe = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Superheroes", x => x.SuperheroID);
                });

            migrationBuilder.CreateTable(
                name: "SuperheroAbilities",
                columns: table => new
                {
                    SuperheroID = table.Column<int>(nullable: false),
                    AbilityID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperheroAbilities", x => new { x.SuperheroID, x.AbilityID });
                    table.ForeignKey(
                        name: "FK_SuperheroAbilities_Abilities_AbilityID",
                        column: x => x.AbilityID,
                        principalTable: "Abilities",
                        principalColumn: "AbilityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SuperheroAbilities_Superheroes_SuperheroID",
                        column: x => x.SuperheroID,
                        principalTable: "Superheroes",
                        principalColumn: "SuperheroID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SuperheroAbilities_AbilityID",
                table: "SuperheroAbilities",
                column: "AbilityID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SuperheroAbilities");

            migrationBuilder.DropTable(
                name: "Abilities");

            migrationBuilder.DropTable(
                name: "Superheroes");
        }
    }
}
