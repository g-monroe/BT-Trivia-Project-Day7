using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperheroBattle.Client.Api.Migrations
{
    public partial class AddAbilityLevelMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AbilityModifier",
                table: "Superheroes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StrengthLevel",
                table: "Abilities",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AbilityModifier",
                table: "Superheroes");

            migrationBuilder.DropColumn(
                name: "StrengthLevel",
                table: "Abilities");
        }
    }
}
