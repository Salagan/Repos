using Microsoft.EntityFrameworkCore.Migrations;

namespace ZRdemoData.Migrations
{
    public partial class EagerLoading : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupOfStudents_Coaches_CoachId",
                table: "GroupOfStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupOfStudents_Gyms_GymId",
                table: "GroupOfStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Coaches_CoachId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_GroupOfStudents_GroupOfStudentsId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingDays_Coaches_CoachId",
                table: "TrainingDays");

            migrationBuilder.DropIndex(
                name: "IX_TrainingDays_CoachId",
                table: "TrainingDays");

            migrationBuilder.DropIndex(
                name: "IX_Students_CoachId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_GroupOfStudents_CoachId",
                table: "GroupOfStudents");

            migrationBuilder.DropIndex(
                name: "IX_GroupOfStudents_GymId",
                table: "GroupOfStudents");

            migrationBuilder.DropColumn(
                name: "CoachId",
                table: "TrainingDays");

            migrationBuilder.DropColumn(
                name: "CoachId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CoachId",
                table: "GroupOfStudents");

            migrationBuilder.RenameColumn(
                name: "GymId",
                table: "GroupOfStudents",
                newName: "StudentId");

            migrationBuilder.AlterColumn<int>(
                name: "GroupOfStudentsId",
                table: "Students",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "CoachTrainingDay",
                columns: table => new
                {
                    CoachesCoachId = table.Column<int>(type: "int", nullable: false),
                    TrainingDaysId = table.Column<int>(type: "int", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoachTrainingDay", x => new { x.CoachesCoachId, x.TrainingDaysId });
                    table.ForeignKey(
                        name: "FK_CoachTrainingDay_Coaches_CoachesCoachId",
                        column: x => x.CoachesCoachId,
                        principalTable: "Coaches",
                        principalColumn: "CoachId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoachTrainingDay_TrainingDays_TrainingDaysId",
                        column: x => x.TrainingDaysId,
                        principalTable: "TrainingDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoachTrainingDay_TrainingDaysId",
                table: "CoachTrainingDay",
                column: "TrainingDaysId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_GroupOfStudents_GroupOfStudentsId",
                table: "Students",
                column: "GroupOfStudentsId",
                principalTable: "GroupOfStudents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_GroupOfStudents_GroupOfStudentsId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "CoachTrainingDay");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "GroupOfStudents",
                newName: "GymId");

            migrationBuilder.AddColumn<int>(
                name: "CoachId",
                table: "TrainingDays",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GroupOfStudentsId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CoachId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CoachId",
                table: "GroupOfStudents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TrainingDays_CoachId",
                table: "TrainingDays",
                column: "CoachId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_CoachId",
                table: "Students",
                column: "CoachId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupOfStudents_CoachId",
                table: "GroupOfStudents",
                column: "CoachId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupOfStudents_GymId",
                table: "GroupOfStudents",
                column: "GymId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupOfStudents_Coaches_CoachId",
                table: "GroupOfStudents",
                column: "CoachId",
                principalTable: "Coaches",
                principalColumn: "CoachId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupOfStudents_Gyms_GymId",
                table: "GroupOfStudents",
                column: "GymId",
                principalTable: "Gyms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Coaches_CoachId",
                table: "Students",
                column: "CoachId",
                principalTable: "Coaches",
                principalColumn: "CoachId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_GroupOfStudents_GroupOfStudentsId",
                table: "Students",
                column: "GroupOfStudentsId",
                principalTable: "GroupOfStudents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingDays_Coaches_CoachId",
                table: "TrainingDays",
                column: "CoachId",
                principalTable: "Coaches",
                principalColumn: "CoachId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
