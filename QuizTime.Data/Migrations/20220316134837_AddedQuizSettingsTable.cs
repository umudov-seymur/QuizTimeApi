using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizTime.Data.Migrations
{
    public partial class AddedQuizSettingsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuizSettings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuizId = table.Column<Guid>(nullable: false),
                    IsShuffleQuestions = table.Column<bool>(nullable: false, defaultValue: false),
                    IsShuffleAnswers = table.Column<bool>(nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizSettings_Quizzes_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuizSettings_QuizId",
                table: "QuizSettings",
                column: "QuizId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuizSettings");
        }
    }
}
