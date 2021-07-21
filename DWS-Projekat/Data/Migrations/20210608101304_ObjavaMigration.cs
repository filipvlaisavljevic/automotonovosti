using Microsoft.EntityFrameworkCore.Migrations;

namespace DWS_Projekat.Data.Migrations
{
    public partial class ObjavaMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Slika",
                table: "Objave",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slika",
                table: "Objave");
        }
    }
}
