using Microsoft.EntityFrameworkCore.Migrations;

namespace DataPanda.Persistence.Migrations
{
    public partial class RemoveEnrolmentsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentEnrolments_Enrolments_EnrolmentId",
                table: "StudentEnrolments");

            migrationBuilder.DropTable(
                name: "Enrolments");

            migrationBuilder.RenameColumn(
                name: "EnrolmentId",
                table: "StudentEnrolments",
                newName: "LearningPlatformId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentEnrolments_EnrolmentId",
                table: "StudentEnrolments",
                newName: "IX_StudentEnrolments_LearningPlatformId");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "StudentEnrolments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StudentEnrolments_CourseId",
                table: "StudentEnrolments",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentEnrolments_Courses_CourseId",
                table: "StudentEnrolments",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentEnrolments_LearningPlatforms_LearningPlatformId",
                table: "StudentEnrolments",
                column: "LearningPlatformId",
                principalTable: "LearningPlatforms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentEnrolments_Courses_CourseId",
                table: "StudentEnrolments");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentEnrolments_LearningPlatforms_LearningPlatformId",
                table: "StudentEnrolments");

            migrationBuilder.DropIndex(
                name: "IX_StudentEnrolments_CourseId",
                table: "StudentEnrolments");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "StudentEnrolments");

            migrationBuilder.RenameColumn(
                name: "LearningPlatformId",
                table: "StudentEnrolments",
                newName: "EnrolmentId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentEnrolments_LearningPlatformId",
                table: "StudentEnrolments",
                newName: "IX_StudentEnrolments_EnrolmentId");

            migrationBuilder.CreateTable(
                name: "Enrolments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    LearningPlatformId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrolments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enrolments_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrolments_LearningPlatforms_LearningPlatformId",
                        column: x => x.LearningPlatformId,
                        principalTable: "LearningPlatforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enrolments_CourseId",
                table: "Enrolments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrolments_LearningPlatformId",
                table: "Enrolments",
                column: "LearningPlatformId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentEnrolments_Enrolments_EnrolmentId",
                table: "StudentEnrolments",
                column: "EnrolmentId",
                principalTable: "Enrolments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
