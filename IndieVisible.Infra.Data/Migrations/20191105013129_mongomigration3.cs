using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IndieVisible.Infra.Data.Migrations
{
    public partial class mongomigration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PollVotes_PollOptions_PollOptionId",
                table: "PollVotes");

            migrationBuilder.DropIndex(
                name: "IX_PollVotes_PollOptionId",
                table: "PollVotes");

            migrationBuilder.AddColumn<Guid>(
                name: "UserProfileId",
                table: "Connections",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PollVotes_PollId",
                table: "PollVotes",
                column: "PollId");

            migrationBuilder.CreateIndex(
                name: "IX_Connections_UserProfileId",
                table: "Connections",
                column: "UserProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Connections_Profiles_UserProfileId",
                table: "Connections",
                column: "UserProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PollVotes_Polls_PollId",
                table: "PollVotes",
                column: "PollId",
                principalTable: "Polls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Connections_Profiles_UserProfileId",
                table: "Connections");

            migrationBuilder.DropForeignKey(
                name: "FK_PollVotes_Polls_PollId",
                table: "PollVotes");

            migrationBuilder.DropIndex(
                name: "IX_PollVotes_PollId",
                table: "PollVotes");

            migrationBuilder.DropIndex(
                name: "IX_Connections_UserProfileId",
                table: "Connections");

            migrationBuilder.DropColumn(
                name: "UserProfileId",
                table: "Connections");

            migrationBuilder.CreateIndex(
                name: "IX_PollVotes_PollOptionId",
                table: "PollVotes",
                column: "PollOptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_PollVotes_PollOptions_PollOptionId",
                table: "PollVotes",
                column: "PollOptionId",
                principalTable: "PollOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
