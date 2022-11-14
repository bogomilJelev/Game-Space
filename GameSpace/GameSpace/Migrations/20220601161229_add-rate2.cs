using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameSpace.Migrations
{
    public partial class addrate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Rates",
                newName: "Number");

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "Rates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Rates_GameId",
                table: "Rates",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rates_Games_GameId",
                table: "Rates",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rates_Games_GameId",
                table: "Rates");

            migrationBuilder.DropIndex(
                name: "IX_Rates_GameId",
                table: "Rates");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Rates");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Rates",
                newName: "Value");
        }
    }
}
