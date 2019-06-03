using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IndieVisible.Infra.Data.Migrations
{
    public partial class comments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TargetType",
                table: "Likes");

            migrationBuilder.RenameColumn(
                name: "LikedId",
                table: "Likes",
                newName: "ContentId");

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    ParentCommentId = table.Column<Guid>(nullable: false),
                    UserContentId = table.Column<Guid>(nullable: false),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_UserContents_UserContentId",
                        column: x => x.UserContentId,
                        principalTable: "UserContents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserContentId",
                table: "Comments",
                column: "UserContentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.RenameColumn(
                name: "ContentId",
                table: "Likes",
                newName: "LikedId");

            migrationBuilder.AddColumn<int>(
                name: "TargetType",
                table: "Likes",
                nullable: false,
                defaultValue: 0);
        }
    }
}
