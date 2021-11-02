using Microsoft.EntityFrameworkCore.Migrations;

namespace ZRdemoData.Migrations
{
    public partial class ChangingTrainingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingDays_GuestCoaches_GuestCoachId",
                table: "TrainingDays");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_Coaches_CoachId",
                table: "Trainings");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_GroupOfStudents_GroupOfStudentsId",
                table: "Trainings");

            migrationBuilder.DropTable(
                name: "GuestTraining");

            migrationBuilder.DropIndex(
                name: "IX_Trainings_CoachId",
                table: "Trainings");

            migrationBuilder.DropIndex(
                name: "IX_Trainings_GroupOfStudentsId",
                table: "Trainings");

            migrationBuilder.DropIndex(
                name: "IX_TrainingDays_GuestCoachId",
                table: "TrainingDays");

            migrationBuilder.DropColumn(
                name: "CoachId",
                table: "Trainings");

            migrationBuilder.DropColumn(
                name: "GroupOfStudentsId",
                table: "Trainings");

            migrationBuilder.DropColumn(
                name: "GuestCoachId",
                table: "TrainingDays");

            migrationBuilder.CreateTable(
                name: "GuestTrainings",
                columns: table => new
                {
                    GuestId = table.Column<int>(type: "int", nullable: false),
                    TrainingId = table.Column<int>(type: "int", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestTrainings", x => new { x.GuestId, x.TrainingId });
                    table.ForeignKey(
                        name: "FK_GuestTrainings_Guests_GuestId",
                        column: x => x.GuestId,
                        principalTable: "Guests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GuestTrainings_Trainings_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Trainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GuestTrainings_TrainingId",
                table: "GuestTrainings",
                column: "TrainingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GuestTrainings");

            migrationBuilder.AddColumn<int>(
                name: "CoachId",
                table: "Trainings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GroupOfStudentsId",
                table: "Trainings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GuestCoachId",
                table: "TrainingDays",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GuestTraining",
                columns: table => new
                {
                    GuestsId = table.Column<int>(type: "int", nullable: false),
                    TrainingsId = table.Column<int>(type: "int", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestTraining", x => new { x.GuestsId, x.TrainingsId });
                    table.ForeignKey(
                        name: "FK_GuestTraining_Guests_GuestsId",
                        column: x => x.GuestsId,
                        principalTable: "Guests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GuestTraining_Trainings_TrainingsId",
                        column: x => x.TrainingsId,
                        principalTable: "Trainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_CoachId",
                table: "Trainings",
                column: "CoachId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_GroupOfStudentsId",
                table: "Trainings",
                column: "GroupOfStudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingDays_GuestCoachId",
                table: "TrainingDays",
                column: "GuestCoachId");

            migrationBuilder.CreateIndex(
                name: "IX_GuestTraining_TrainingsId",
                table: "GuestTraining",
                column: "TrainingsId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingDays_GuestCoaches_GuestCoachId",
                table: "TrainingDays",
                column: "GuestCoachId",
                principalTable: "GuestCoaches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_Coaches_CoachId",
                table: "Trainings",
                column: "CoachId",
                principalTable: "Coaches",
                principalColumn: "CoachId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_GroupOfStudents_GroupOfStudentsId",
                table: "Trainings",
                column: "GroupOfStudentsId",
                principalTable: "GroupOfStudents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
