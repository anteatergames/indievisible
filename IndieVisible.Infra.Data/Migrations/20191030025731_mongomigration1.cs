using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IndieVisible.Infra.Data.Migrations
{
    public partial class mongomigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserProfileId",
                table: "Follows",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "FeaturedContents",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.CreateIndex(
                name: "IX_GameLikes_GameId",
                table: "GameLikes",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameFollows_GameId",
                table: "GameFollows",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Follows_UserProfileId",
                table: "Follows",
                column: "UserProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Follows_Profiles_UserProfileId",
                table: "Follows",
                column: "UserProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GameFollows_Games_GameId",
                table: "GameFollows",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameLikes_Games_GameId",
                table: "GameLikes",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Follows_Profiles_UserProfileId",
                table: "Follows");

            migrationBuilder.DropForeignKey(
                name: "FK_GameFollows_Games_GameId",
                table: "GameFollows");

            migrationBuilder.DropForeignKey(
                name: "FK_GameLikes_Games_GameId",
                table: "GameLikes");

            migrationBuilder.DropIndex(
                name: "IX_GameLikes_GameId",
                table: "GameLikes");

            migrationBuilder.DropIndex(
                name: "IX_GameFollows_GameId",
                table: "GameFollows");

            migrationBuilder.DropIndex(
                name: "IX_Follows_UserProfileId",
                table: "Follows");

            migrationBuilder.DropColumn(
                name: "UserProfileId",
                table: "Follows");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "FeaturedContents",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
