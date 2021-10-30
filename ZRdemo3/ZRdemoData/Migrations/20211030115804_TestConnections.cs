using Microsoft.EntityFrameworkCore.Migrations;

namespace ZRdemoData.Migrations
{
    public partial class TestConnections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gyms_TrainingDays_TrainingDayId",
                table: "Gyms");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingDays_Gyms_GymId",
                table: "TrainingDays");

            migrationBuilder.DropIndex(
                name: "IX_TrainingDays_GymId",
                table: "TrainingDays");

            migrationBuilder.DropIndex(
                name: "IX_Gyms_TrainingDayId",
                table: "Gyms");

            migrationBuilder.DropColumn(
                name: "GymId",
                table: "TrainingDays");

            migrationBuilder.DropColumn(
                name: "TrainingDayId",
                table: "Gyms");

            migrationBuilder.CreateTable(
                name: "GymTrainingDay",
                columns: table => new
                {
                    GymsId = table.Column<int>(type: "int", nullable: false),
                    TrainingDaysId = table.Column<int>(type: "int", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GymTrainingDay", x => new { x.GymsId, x.TrainingDaysId });
                    table.ForeignKey(
                        name: "FK_GymTrainingDay_Gyms_GymsId",
                        column: x => x.GymsId,
                        principalTable: "Gyms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GymTrainingDay_TrainingDays_TrainingDaysId",
                        column: x => x.TrainingDaysId,
                        principalTable: "TrainingDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GymTrainingDay_TrainingDaysId",
                table: "GymTrainingDay",
                column: "TrainingDaysId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GymTrainingDay");

            migrationBuilder.AddColumn<int>(
                name: "GymId",
                table: "TrainingDays",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TrainingDayId",
                table: "Gyms",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrainingDays_GymId",
                table: "TrainingDays",
                column: "GymId");

            migrationBuilder.CreateIndex(
                name: "IX_Gyms_TrainingDayId",
                table: "Gyms",
                column: "TrainingDayId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gyms_TrainingDays_TrainingDayId",
                table: "Gyms",
                column: "TrainingDayId",
                principalTable: "TrainingDays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingDays_Gyms_GymId",
                table: "TrainingDays",
                column: "GymId",
                principalTable: "Gyms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
