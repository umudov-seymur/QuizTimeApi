using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizTime.Data.Migrations
{
    public partial class SetQuizIdColumnNullableFromPasswordTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "QuizId",
                table: "Passwords",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "QuizId",
                table: "Passwords",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);
        }
    }
}
