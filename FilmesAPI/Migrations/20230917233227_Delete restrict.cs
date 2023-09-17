using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmesAPI.Migrations
{
    public partial class Deleterestrict : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cinemas_Adresses_AddressId",
                table: "Cinemas");

            migrationBuilder.AddForeignKey(
                name: "FK_Cinemas_Adresses_AddressId",
                table: "Cinemas",
                column: "AddressId",
                principalTable: "Adresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cinemas_Adresses_AddressId",
                table: "Cinemas");

            migrationBuilder.AddForeignKey(
                name: "FK_Cinemas_Adresses_AddressId",
                table: "Cinemas",
                column: "AddressId",
                principalTable: "Adresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
