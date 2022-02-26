using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizTime.Data.Migrations
{
    public partial class AddedPasswordColumnToQuizTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passwords_Quizzes_QuizId",
                table: "Passwords");

            migrationBuilder.DropIndex(
                name: "IX_Passwords_QuizId",
                table: "Passwords");

            migrationBuilder.AddColumn<int>(
                name: "PasswordId",
                table: "Quizzes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_PasswordId",
                table: "Quizzes",
                column: "PasswordId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Quizzes_Passwords_PasswordId",
                table: "Quizzes",
                column: "PasswordId",
                principalTable: "Passwords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quizzes_Passwords_PasswordId",
                table: "Quizzes");

            migrationBuilder.DropIndex(
                name: "IX_Quizzes_PasswordId",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "PasswordId",
                table: "Quizzes");

            migrationBuilder.CreateIndex(
                name: "IX_Passwords_QuizId",
                table: "Passwords",
                column: "QuizId");

            migrationBuilder.AddForeignKey(
                name: "FK_Passwords_Quizzes_QuizId",
                table: "Passwords",
                column: "QuizId",
                principalTable: "Quizzes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
