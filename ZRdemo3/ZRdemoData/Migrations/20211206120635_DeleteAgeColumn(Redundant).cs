using Microsoft.EntityFrameworkCore.Migrations;

namespace ZRdemoData.Migrations
{
    public partial class DeleteAgeColumnRedundant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Coaches");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Coaches",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
