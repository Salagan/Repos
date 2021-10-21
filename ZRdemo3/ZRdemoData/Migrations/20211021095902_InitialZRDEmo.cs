using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZRdemoData.Migrations
{
    public partial class InitialZRDEmo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coaches",
                columns: table => new
                {
                    CoachId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    IsWorking = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coaches", x => x.CoachId);
                });

            migrationBuilder.CreateTable(
                name: "GuestCoaches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Belt = table.Column<int>(type: "int", nullable: false),
                    SchoolName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestCoaches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainingDays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false),
                    IsHolliday = table.Column<bool>(type: "bit", nullable: false),
                    CoachId = table.Column<int>(type: "int", nullable: true),
                    GuestCoachId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingDays_Coaches_CoachId",
                        column: x => x.CoachId,
                        principalTable: "Coaches",
                        principalColumn: "CoachId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrainingDays_GuestCoaches_GuestCoachId",
                        column: x => x.GuestCoachId,
                        principalTable: "GuestCoaches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Gyms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    TrainingDayId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gyms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gyms_TrainingDays_TrainingDayId",
                        column: x => x.TrainingDayId,
                        principalTable: "TrainingDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GroupOfStudents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuestCoachId = table.Column<int>(type: "int", nullable: true),
                    GymID = table.Column<int>(type: "int", nullable: false),
                    GroupType = table.Column<int>(type: "int", nullable: false),
                    GroupAge = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoachId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupOfStudents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupOfStudents_Coaches_CoachId",
                        column: x => x.CoachId,
                        principalTable: "Coaches",
                        principalColumn: "CoachId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GroupOfStudents_GuestCoaches_GuestCoachId",
                        column: x => x.GuestCoachId,
                        principalTable: "GuestCoaches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GroupOfStudents_Gyms_GymID",
                        column: x => x.GymID,
                        principalTable: "Gyms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupOfStudentsTrainingDay",
                columns: table => new
                {
                    GroupOfStudentsId = table.Column<int>(type: "int", nullable: false),
                    TrainingDaysId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupOfStudentsTrainingDay", x => new { x.GroupOfStudentsId, x.TrainingDaysId });
                    table.ForeignKey(
                        name: "FK_GroupOfStudentsTrainingDay_GroupOfStudents_GroupOfStudentsId",
                        column: x => x.GroupOfStudentsId,
                        principalTable: "GroupOfStudents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupOfStudentsTrainingDay_TrainingDays_TrainingDaysId",
                        column: x => x.TrainingDaysId,
                        principalTable: "TrainingDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoachId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Injury = table.Column<bool>(type: "bit", nullable: false),
                    Belt = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Students_Coaches_CoachId",
                        column: x => x.CoachId,
                        principalTable: "Coaches",
                        principalColumn: "CoachId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_GroupOfStudents_GroupId",
                        column: x => x.GroupId,
                        principalTable: "GroupOfStudents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Trainings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoachId = table.Column<int>(type: "int", nullable: false),
                    GymId = table.Column<int>(type: "int", nullable: false),
                    TrainingDayId = table.Column<int>(type: "int", nullable: false),
                    CoachGuestId = table.Column<int>(type: "int", nullable: true),
                    TimeStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Uniform = table.Column<int>(type: "int", nullable: false),
                    TypeOfTraining = table.Column<int>(type: "int", nullable: false),
                    GroupOfStudentsId = table.Column<int>(type: "int", nullable: true),
                    GuestCoachId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trainings_Coaches_CoachId",
                        column: x => x.CoachId,
                        principalTable: "Coaches",
                        principalColumn: "CoachId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trainings_GroupOfStudents_GroupOfStudentsId",
                        column: x => x.GroupOfStudentsId,
                        principalTable: "GroupOfStudents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trainings_GuestCoaches_GuestCoachId",
                        column: x => x.GuestCoachId,
                        principalTable: "GuestCoaches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trainings_Gyms_GymId",
                        column: x => x.GymId,
                        principalTable: "Gyms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trainings_TrainingDays_TrainingDayId",
                        column: x => x.TrainingDayId,
                        principalTable: "TrainingDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GuestTraining",
                columns: table => new
                {
                    GuestsId = table.Column<int>(type: "int", nullable: false),
                    TrainingsId = table.Column<int>(type: "int", nullable: false)
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
                name: "IX_GroupOfStudents_CoachId",
                table: "GroupOfStudents",
                column: "CoachId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupOfStudents_GuestCoachId",
                table: "GroupOfStudents",
                column: "GuestCoachId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupOfStudents_GymID",
                table: "GroupOfStudents",
                column: "GymID");

            migrationBuilder.CreateIndex(
                name: "IX_GroupOfStudentsTrainingDay_TrainingDaysId",
                table: "GroupOfStudentsTrainingDay",
                column: "TrainingDaysId");

            migrationBuilder.CreateIndex(
                name: "IX_GuestTraining_TrainingsId",
                table: "GuestTraining",
                column: "TrainingsId");

            migrationBuilder.CreateIndex(
                name: "IX_Gyms_TrainingDayId",
                table: "Gyms",
                column: "TrainingDayId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_CoachId",
                table: "Students",
                column: "CoachId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_GroupId",
                table: "Students",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingDays_CoachId",
                table: "TrainingDays",
                column: "CoachId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingDays_GuestCoachId",
                table: "TrainingDays",
                column: "GuestCoachId");

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
                name: "IX_Trainings_TrainingDayId",
                table: "Trainings",
                column: "TrainingDayId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupOfStudentsTrainingDay");

            migrationBuilder.DropTable(
                name: "GuestTraining");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Guests");

            migrationBuilder.DropTable(
                name: "Trainings");

            migrationBuilder.DropTable(
                name: "GroupOfStudents");

            migrationBuilder.DropTable(
                name: "Gyms");

            migrationBuilder.DropTable(
                name: "TrainingDays");

            migrationBuilder.DropTable(
                name: "Coaches");

            migrationBuilder.DropTable(
                name: "GuestCoaches");
        }
    }
}
