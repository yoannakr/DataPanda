using Microsoft.EntityFrameworkCore.Migrations;

namespace DataPanda.Persistence.Migrations
{
    public partial class RenameStudentEnrolmentToEnrolment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileSubmissions_StudentEnrolmentAssignments_StudentEnrolmentAssignmentId",
                table: "FileSubmissions");

            migrationBuilder.DropTable(
                name: "StudentEnrolmentAssignments");

            migrationBuilder.DropTable(
                name: "StudentEnrolmentWikis");

            migrationBuilder.DropTable(
                name: "StudentEnrolments");

            migrationBuilder.RenameColumn(
                name: "StudentEnrolmentAssignmentId",
                table: "FileSubmissions",
                newName: "EnrolmentAssignmentId");

            migrationBuilder.RenameIndex(
                name: "IX_FileSubmissions_StudentEnrolmentAssignmentId",
                table: "FileSubmissions",
                newName: "IX_FileSubmissions_EnrolmentAssignmentId");

            migrationBuilder.CreateTable(
                name: "Enrolments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    LearningPlatformId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<double>(type: "float", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_Enrolments_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnrolmentAssignments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignmentId = table.Column<int>(type: "int", nullable: false),
                    EnrolmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrolmentAssignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnrolmentAssignments_Assignments_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnrolmentAssignments_Enrolments_EnrolmentId",
                        column: x => x.EnrolmentId,
                        principalTable: "Enrolments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnrolmentWikis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfEdits = table.Column<int>(type: "int", nullable: false),
                    WikiId = table.Column<int>(type: "int", nullable: false),
                    EnrolmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrolmentWikis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnrolmentWikis_Enrolments_EnrolmentId",
                        column: x => x.EnrolmentId,
                        principalTable: "Enrolments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnrolmentWikis_Wikis_WikiId",
                        column: x => x.WikiId,
                        principalTable: "Wikis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EnrolmentAssignments_AssignmentId",
                table: "EnrolmentAssignments",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EnrolmentAssignments_EnrolmentId",
                table: "EnrolmentAssignments",
                column: "EnrolmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrolments_CourseId",
                table: "Enrolments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrolments_LearningPlatformId",
                table: "Enrolments",
                column: "LearningPlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrolments_StudentId",
                table: "Enrolments",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_EnrolmentWikis_EnrolmentId",
                table: "EnrolmentWikis",
                column: "EnrolmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EnrolmentWikis_WikiId",
                table: "EnrolmentWikis",
                column: "WikiId");

            migrationBuilder.AddForeignKey(
                name: "FK_FileSubmissions_EnrolmentAssignments_EnrolmentAssignmentId",
                table: "FileSubmissions",
                column: "EnrolmentAssignmentId",
                principalTable: "EnrolmentAssignments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileSubmissions_EnrolmentAssignments_EnrolmentAssignmentId",
                table: "FileSubmissions");

            migrationBuilder.DropTable(
                name: "EnrolmentAssignments");

            migrationBuilder.DropTable(
                name: "EnrolmentWikis");

            migrationBuilder.DropTable(
                name: "Enrolments");

            migrationBuilder.RenameColumn(
                name: "EnrolmentAssignmentId",
                table: "FileSubmissions",
                newName: "StudentEnrolmentAssignmentId");

            migrationBuilder.RenameIndex(
                name: "IX_FileSubmissions_EnrolmentAssignmentId",
                table: "FileSubmissions",
                newName: "IX_FileSubmissions_StudentEnrolmentAssignmentId");

            migrationBuilder.CreateTable(
                name: "StudentEnrolments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<double>(type: "float", nullable: false),
                    LearningPlatformId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentEnrolments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentEnrolments_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentEnrolments_LearningPlatforms_LearningPlatformId",
                        column: x => x.LearningPlatformId,
                        principalTable: "LearningPlatforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentEnrolments_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentEnrolmentAssignments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignmentId = table.Column<int>(type: "int", nullable: false),
                    StudentEnrolmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentEnrolmentAssignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentEnrolmentAssignments_Assignments_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentEnrolmentAssignments_StudentEnrolments_StudentEnrolmentId",
                        column: x => x.StudentEnrolmentId,
                        principalTable: "StudentEnrolments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentEnrolmentWikis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfEdits = table.Column<int>(type: "int", nullable: false),
                    StudentEnrolmentId = table.Column<int>(type: "int", nullable: false),
                    WikiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentEnrolmentWikis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentEnrolmentWikis_StudentEnrolments_StudentEnrolmentId",
                        column: x => x.StudentEnrolmentId,
                        principalTable: "StudentEnrolments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentEnrolmentWikis_Wikis_WikiId",
                        column: x => x.WikiId,
                        principalTable: "Wikis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentEnrolmentAssignments_AssignmentId",
                table: "StudentEnrolmentAssignments",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentEnrolmentAssignments_StudentEnrolmentId",
                table: "StudentEnrolmentAssignments",
                column: "StudentEnrolmentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentEnrolments_CourseId",
                table: "StudentEnrolments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentEnrolments_LearningPlatformId",
                table: "StudentEnrolments",
                column: "LearningPlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentEnrolments_StudentId",
                table: "StudentEnrolments",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentEnrolmentWikis_StudentEnrolmentId",
                table: "StudentEnrolmentWikis",
                column: "StudentEnrolmentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentEnrolmentWikis_WikiId",
                table: "StudentEnrolmentWikis",
                column: "WikiId");

            migrationBuilder.AddForeignKey(
                name: "FK_FileSubmissions_StudentEnrolmentAssignments_StudentEnrolmentAssignmentId",
                table: "FileSubmissions",
                column: "StudentEnrolmentAssignmentId",
                principalTable: "StudentEnrolmentAssignments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
