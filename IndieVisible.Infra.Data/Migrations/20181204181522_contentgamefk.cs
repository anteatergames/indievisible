using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IndieVisible.Infra.Data.Migrations
{
    public partial class contentgamefk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Language",
                table: "UserContents",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<Guid>(
                name: "GameId",
                table: "UserContents",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserContents_GameId",
                table: "UserContents",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserContents_Games_GameId",
                table: "UserContents",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserContents_Games_GameId",
                table: "UserContents");

            migrationBuilder.DropIndex(
                name: "IX_UserContents_GameId",
                table: "UserContents");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "UserContents");

            migrationBuilder.AlterColumn<int>(
                name: "Language",
                table: "UserContents",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValue: 1);
        }
    }
}
