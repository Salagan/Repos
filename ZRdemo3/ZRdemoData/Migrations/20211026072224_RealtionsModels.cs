using Microsoft.EntityFrameworkCore.Migrations;

namespace ZRdemoData.Migrations
{
    public partial class RealtionsModels : Migration
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
                name: "FK_Trainings_GroupOfStudents_GroupOfStudentsId",
                table: "Trainings");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_Gyms_GymId",
                table: "Trainings");

            migrationBuilder.DropIndex(
                name: "IX_Trainings_GymId",
                table: "Trainings");

            migrationBuilder.DropIndex(
                name: "IX_Students_GroupId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_GroupOfStudents_GuestCoachId",
                table: "GroupOfStudents");

            migrationBuilder.DropColumn(
                name: "CoachGuestId",
                table: "Trainings");

            migrationBuilder.DropColumn(
                name: "GymId",
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

            migrationBuilder.RenameIndex(
                name: "IX_GroupOfStudents_GymID",
                table: "GroupOfStudents",
                newName: "IX_GroupOfStudents_GymId");

            migrationBuilder.AlterColumn<int>(
                name: "GroupOfStudentsId",
                table: "Trainings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GymId",
                table: "TrainingDays",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "CoachId",
                table: "Students",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
                name: "IX_TrainingDays_GymId",
                table: "TrainingDays",
                column: "GymId");

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
                name: "FK_TrainingDays_Gyms_GymId",
                table: "TrainingDays",
                column: "GymId",
                principalTable: "Gyms",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_GroupOfStudents_GroupOfStudentsId",
                table: "Trainings",
                column: "GroupOfStudentsId",
                principalTable: "GroupOfStudents",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "FK_TrainingDays_Gyms_GymId",
                table: "TrainingDays");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_GroupOfStudents_GroupOfStudentsId",
                table: "Trainings");

            migrationBuilder.DropIndex(
                name: "IX_TrainingDays_GymId",
                table: "TrainingDays");

            migrationBuilder.DropIndex(
                name: "IX_Students_GroupOfStudentsId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "GymId",
                table: "TrainingDays");

            migrationBuilder.DropColumn(
                name: "GroupOfStudentsId",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "GymId",
                table: "GroupOfStudents",
                newName: "GymID");

            migrationBuilder.RenameIndex(
                name: "IX_GroupOfStudents_GymId",
                table: "GroupOfStudents",
                newName: "IX_GroupOfStudents_GymID");

            migrationBuilder.AlterColumn<int>(
                name: "GroupOfStudentsId",
                table: "Trainings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CoachGuestId",
                table: "Trainings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GymId",
                table: "Trainings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "CoachId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
                name: "IX_Trainings_GymId",
                table: "Trainings",
                column: "GymId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_GroupId",
                table: "Students",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupOfStudents_GuestCoachId",
                table: "GroupOfStudents",
                column: "GuestCoachId");

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
                name: "FK_Trainings_GroupOfStudents_GroupOfStudentsId",
                table: "Trainings",
                column: "GroupOfStudentsId",
                principalTable: "GroupOfStudents",
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
