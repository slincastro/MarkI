using Microsoft.EntityFrameworkCore.Migrations;

namespace MarkI.Repository.Migrations
{
    public partial class PersonUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DocumentId",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Persons",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Persons");
        }
    }
}
