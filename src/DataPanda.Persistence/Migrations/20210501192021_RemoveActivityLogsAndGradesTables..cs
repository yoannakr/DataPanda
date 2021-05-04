using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataPanda.Persistence.Migrations
{
    public partial class RemoveActivityLogsAndGradesTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentEnrolments_Grades_GradeId",
                table: "StudentEnrolments");

            migrationBuilder.DropTable(
                name: "ActivityLogs");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropIndex(
                name: "IX_StudentEnrolments_GradeId",
                table: "StudentEnrolments");

            migrationBuilder.DropColumn(
                name: "GradeId",
                table: "StudentEnrolments");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Enrolments");

            migrationBuilder.AddColumn<double>(
                name: "Grade",
                table: "StudentEnrolments",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Grade",
                table: "StudentEnrolments");

            migrationBuilder.AddColumn<int>(
                name: "GradeId",
                table: "StudentEnrolments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Enrolments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ActivityLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Component = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Context = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentEnrolments_GradeId",
                table: "StudentEnrolments",
                column: "GradeId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentEnrolments_Grades_GradeId",
                table: "StudentEnrolments",
                column: "GradeId",
                principalTable: "Grades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
