using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IndieVisible.Infra.Data.Migrations
{
    public partial class votingcontext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ContextId",
                table: "VotingItems",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "VotingContexts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    Title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Type = table.Column<int>(nullable: false),
                    TargetContextId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VotingContexts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "VotingContexts",
                columns: new[] { "Id", "CreateDate", "Description", "TargetContextId", "Title", "Type", "UserId" },
                values: new object[] { new Guid("1fee0e42-7cfb-4438-96f9-4dbee6019de9"), new DateTime(2019, 3, 28, 23, 21, 3, 949, DateTimeKind.Local), "Ideas for improvement on the community.", null, "IndieVisible Ideas", 0, new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.CreateIndex(
                name: "IX_VotingItems_ContextId",
                table: "VotingItems",
                column: "ContextId");

            migrationBuilder.CreateIndex(
                name: "IX_VotingItemComments_VotingItemId",
                table: "VotingItemComments",
                column: "VotingItemId");

            migrationBuilder.CreateIndex(
                name: "IX_UserVotes_VotingItemId",
                table: "UserVotes",
                column: "VotingItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserVotes_VotingItems_VotingItemId",
                table: "UserVotes",
                column: "VotingItemId",
                principalTable: "VotingItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VotingItemComments_VotingItems_VotingItemId",
                table: "VotingItemComments",
                column: "VotingItemId",
                principalTable: "VotingItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VotingItems_VotingContexts_ContextId",
                table: "VotingItems",
                column: "ContextId",
                principalTable: "VotingContexts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserVotes_VotingItems_VotingItemId",
                table: "UserVotes");

            migrationBuilder.DropForeignKey(
                name: "FK_VotingItemComments_VotingItems_VotingItemId",
                table: "VotingItemComments");

            migrationBuilder.DropForeignKey(
                name: "FK_VotingItems_VotingContexts_ContextId",
                table: "VotingItems");

            migrationBuilder.DropTable(
                name: "VotingContexts");

            migrationBuilder.DropIndex(
                name: "IX_VotingItems_ContextId",
                table: "VotingItems");

            migrationBuilder.DropIndex(
                name: "IX_VotingItemComments_VotingItemId",
                table: "VotingItemComments");

            migrationBuilder.DropIndex(
                name: "IX_UserVotes_VotingItemId",
                table: "UserVotes");

            migrationBuilder.DropColumn(
                name: "ContextId",
                table: "VotingItems");
        }
    }
}
