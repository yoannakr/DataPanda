﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace DataPanda.Persistence.Migrations
{
    public partial class AddNNumberOfFilesColumnToTheFileSubmissionsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfFiles",
                table: "FileSubmissions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfFiles",
                table: "FileSubmissions");
        }
    }
}
