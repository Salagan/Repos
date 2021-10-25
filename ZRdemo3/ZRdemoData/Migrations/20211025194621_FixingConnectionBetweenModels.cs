using Microsoft.EntityFrameworkCore.Migrations;

namespace ZRdemoData.Migrations
{
    public partial class FixingConnectionBetweenModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupOfStudents_Coaches_CoachId",
                table: "GroupOfStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupOfStudents_GuestCoaches_GuestCoachId",
                table: "GroupOfStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupOfStudents_Gyms_GymID",
                table: "GroupOfStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Coaches_CoachId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_GroupOfStudents_GroupId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_Coaches_CoachId",
                table: "Trainings");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_GroupOfStudents_GroupOfStudentsId",
                table: "Trainings");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_GuestCoaches_GuestCoachId",
                table: "Trainings");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_Gyms_GymId",
                table: "Trainings");

            migrationBuilder.DropIndex(
                name: "IX_Trainings_CoachId",
                table: "Trainings");

            migrationBuilder.DropIndex(
                name: "IX_Trainings_GroupOfStudentsId",
                table: "Trainings");

            migrationBuilder.DropIndex(
                name: "IX_Trainings_GuestCoachId",
                table: "Trainings");

            migrationBuilder.DropIndex(
                name: "IX_Trainings_GymId",
                table: "Trainings");

            migrationBuilder.DropIndex(
                name: "IX_Students_CoachId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_GroupId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_GroupOfStudents_GuestCoachId",
                table: "GroupOfStudents");

            migrationBuilder.DropIndex(
                name: "IX_GroupOfStudents_GymID",
                table: "GroupOfStudents");

            migrationBuilder.DropColumn(
                name: "GroupOfStudentsId",
                table: "Trainings");

            migrationBuilder.DropColumn(
                name: "GuestCoachId",
                table: "Trainings");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "GuestCoachId",
                table: "GroupOfStudents");

            migrationBuilder.RenameColumn(
                name: "GymID",
                table: "GroupOfStudents",
                newName: "GymId");

            migrationBuilder.AddColumn<int>(
                name: "GroupOfStudentsId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "CoachId",
                table: "GroupOfStudents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_GroupOfStudentsId",
                table: "Students",
                column: "GroupOfStudentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupOfStudents_Coaches_CoachId",
                table: "GroupOfStudents",
                column: "CoachId",
                principalTable: "Coaches",
                principalColumn: "CoachId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_GroupOfStudents_GroupOfStudentsId",
                table: "Students",
                column: "GroupOfStudentsId",
                principalTable: "GroupOfStudents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupOfStudents_Coaches_CoachId",
                table: "GroupOfStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_GroupOfStudents_GroupOfStudentsId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_GroupOfStudentsId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "GroupOfStudentsId",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "GymId",
                table: "GroupOfStudents",
                newName: "GymID");

            migrationBuilder.AddColumn<int>(
                name: "GroupOfStudentsId",
                table: "Trainings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GuestCoachId",
                table: "Trainings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CoachId",
                table: "GroupOfStudents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "GuestCoachId",
                table: "GroupOfStudents",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_CoachId",
                table: "Trainings",
                column: "CoachId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_GroupOfStudentsId",
                table: "Trainings",
                column: "GroupOfStudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_GuestCoachId",
                table: "Trainings",
                column: "GuestCoachId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_GymId",
                table: "Trainings",
                column: "GymId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_CoachId",
                table: "Students",
                column: "CoachId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_GroupId",
                table: "Students",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupOfStudents_GuestCoachId",
                table: "GroupOfStudents",
                column: "GuestCoachId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupOfStudents_GymID",
                table: "GroupOfStudents",
                column: "GymID");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupOfStudents_Coaches_CoachId",
                table: "GroupOfStudents",
                column: "CoachId",
                principalTable: "Coaches",
                principalColumn: "CoachId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupOfStudents_GuestCoaches_GuestCoachId",
                table: "GroupOfStudents",
                column: "GuestCoachId",
                principalTable: "GuestCoaches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupOfStudents_Gyms_GymID",
                table: "GroupOfStudents",
                column: "GymID",
                principalTable: "Gyms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Coaches_CoachId",
                table: "Students",
                column: "CoachId",
                principalTable: "Coaches",
                principalColumn: "CoachId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_GroupOfStudents_GroupId",
                table: "Students",
                column: "GroupId",
                principalTable: "GroupOfStudents",
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
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_GuestCoaches_GuestCoachId",
                table: "Trainings",
                column: "GuestCoachId",
                principalTable: "GuestCoaches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_Gyms_GymId",
                table: "Trainings",
                column: "GymId",
                principalTable: "Gyms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
