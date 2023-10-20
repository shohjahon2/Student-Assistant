using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Student_Assistant.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Key = table.Column<Guid>(type: "TEXT", nullable: false),
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    QuestionContext = table.Column<string>(type: "TEXT", nullable: true),
                    Answered = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Key = table.Column<Guid>(type: "TEXT", nullable: false),
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    QuestionContext = table.Column<string>(type: "TEXT", nullable: true),
                    Answer1 = table.Column<string>(type: "TEXT", nullable: true),
                    Answer2 = table.Column<string>(type: "TEXT", nullable: true),
                    Answer3 = table.Column<string>(type: "TEXT", nullable: true),
                    Answer4 = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Key);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}
