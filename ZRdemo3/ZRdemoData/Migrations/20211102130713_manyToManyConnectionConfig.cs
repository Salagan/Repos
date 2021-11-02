using Microsoft.EntityFrameworkCore.Migrations;

namespace ZRdemoData.Migrations
{
    public partial class ManyToManyConnectionConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoachTrainingDay");

            migrationBuilder.DropTable(
                name: "GroupOfStudentsTrainingDay");

            migrationBuilder.DropTable(
                name: "GymTrainingDay");

            migrationBuilder.CreateTable(
                name: "CoachTrainingDays",
                columns: table => new
                {
                    CoachId = table.Column<int>(type: "int", nullable: false),
                    TrainingDayId = table.Column<int>(type: "int", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoachTrainingDays", x => new { x.CoachId, x.TrainingDayId });
                    table.ForeignKey(
                        name: "FK_CoachTrainingDays_Coaches_CoachId",
                        column: x => x.CoachId,
                        principalTable: "Coaches",
                        principalColumn: "CoachId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoachTrainingDays_TrainingDays_TrainingDayId",
                        column: x => x.TrainingDayId,
                        principalTable: "TrainingDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupOfStudentsTrainingDays",
                columns: table => new
                {
                    GroupOfStudentsId = table.Column<int>(type: "int", nullable: false),
                    TrainingDayId = table.Column<int>(type: "int", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupOfStudentsTrainingDays", x => new { x.GroupOfStudentsId, x.TrainingDayId });
                    table.ForeignKey(
                        name: "FK_GroupOfStudentsTrainingDays_GroupOfStudents_GroupOfStudentsId",
                        column: x => x.GroupOfStudentsId,
                        principalTable: "GroupOfStudents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupOfStudentsTrainingDays_TrainingDays_TrainingDayId",
                        column: x => x.TrainingDayId,
                        principalTable: "TrainingDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GymTrainingDays",
                columns: table => new
                {
                    GymId = table.Column<int>(type: "int", nullable: false),
                    TrainingDayID = table.Column<int>(type: "int", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GymTrainingDays", x => new { x.GymId, x.TrainingDayID });
                    table.ForeignKey(
                        name: "FK_GymTrainingDays_Gyms_GymId",
                        column: x => x.GymId,
                        principalTable: "Gyms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GymTrainingDays_TrainingDays_TrainingDayID",
                        column: x => x.TrainingDayID,
                        principalTable: "TrainingDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoachTrainingDays_TrainingDayId",
                table: "CoachTrainingDays",
                column: "TrainingDayId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupOfStudentsTrainingDays_TrainingDayId",
                table: "GroupOfStudentsTrainingDays",
                column: "TrainingDayId");

            migrationBuilder.CreateIndex(
                name: "IX_GymTrainingDays_TrainingDayID",
                table: "GymTrainingDays",
                column: "TrainingDayID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoachTrainingDays");

            migrationBuilder.DropTable(
                name: "GroupOfStudentsTrainingDays");

            migrationBuilder.DropTable(
                name: "GymTrainingDays");

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

            migrationBuilder.CreateTable(
                name: "GroupOfStudentsTrainingDay",
                columns: table => new
                {
                    GroupOfStudentsId = table.Column<int>(type: "int", nullable: false),
                    TrainingDaysId = table.Column<int>(type: "int", nullable: false),
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
                name: "IX_CoachTrainingDay_TrainingDaysId",
                table: "CoachTrainingDay",
                column: "TrainingDaysId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupOfStudentsTrainingDay_TrainingDaysId",
                table: "GroupOfStudentsTrainingDay",
                column: "TrainingDaysId");

            migrationBuilder.CreateIndex(
                name: "IX_GymTrainingDay_TrainingDaysId",
                table: "GymTrainingDay",
                column: "TrainingDaysId");
        }
    }
}
