using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IndieVisible.Infra.Data.Migrations
{
    public partial class brainstorm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserVotes");

            migrationBuilder.DropTable(
                name: "VotingItemComments");

            migrationBuilder.DropTable(
                name: "VotingItems");

            migrationBuilder.DropTable(
                name: "VotingContexts");

            migrationBuilder.CreateTable(
                name: "BrainstormSessions",
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
                    table.PrimaryKey("PK_BrainstormSessions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BrainstormIdeas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    Title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    SessionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrainstormIdeas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BrainstormIdeas_BrainstormSessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "BrainstormSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BrainstormComments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    ParentCommentId = table.Column<Guid>(nullable: true),
                    IdeaId = table.Column<Guid>(nullable: false),
                    AuthorName = table.Column<string>(nullable: true),
                    AuthorPicture = table.Column<string>(nullable: true),
                    Text = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrainstormComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BrainstormComments_BrainstormIdeas_IdeaId",
                        column: x => x.IdeaId,
                        principalTable: "BrainstormIdeas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BrainstormVotes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    IdeaId = table.Column<Guid>(nullable: false),
                    VoteValue = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrainstormVotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BrainstormVotes_BrainstormIdeas_IdeaId",
                        column: x => x.IdeaId,
                        principalTable: "BrainstormIdeas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BrainstormSessions",
                columns: new[] { "Id", "CreateDate", "Description", "TargetContextId", "Title", "Type", "UserId" },
                values: new object[] { new Guid("1fee0e42-7cfb-4438-96f9-4dbee6019de9"), new DateTime(2019, 4, 7, 22, 9, 44, 87, DateTimeKind.Local), "Ideas for improvement on the community.", null, "IndieVisible Ideas", 0, new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.CreateIndex(
                name: "IX_BrainstormComments_IdeaId",
                table: "BrainstormComments",
                column: "IdeaId");

            migrationBuilder.CreateIndex(
                name: "IX_BrainstormIdeas_SessionId",
                table: "BrainstormIdeas",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_BrainstormVotes_IdeaId",
                table: "BrainstormVotes",
                column: "IdeaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BrainstormComments");

            migrationBuilder.DropTable(
                name: "BrainstormVotes");

            migrationBuilder.DropTable(
                name: "BrainstormIdeas");

            migrationBuilder.DropTable(
                name: "BrainstormSessions");

            migrationBuilder.CreateTable(
                name: "VotingContexts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    TargetContextId = table.Column<Guid>(nullable: true),
                    Title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Type = table.Column<int>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VotingContexts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VotingItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ContextId = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VotingItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VotingItems_VotingContexts_ContextId",
                        column: x => x.ContextId,
                        principalTable: "VotingContexts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserVotes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    UserId = table.Column<Guid>(nullable: false),
                    VoteValue = table.Column<int>(nullable: false),
                    VotingItemId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserVotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserVotes_VotingItems_VotingItemId",
                        column: x => x.VotingItemId,
                        principalTable: "VotingItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VotingItemComments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AuthorName = table.Column<string>(nullable: true),
                    AuthorPicture = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    ParentCommentId = table.Column<Guid>(nullable: false),
                    Text = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    VotingItemId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VotingItemComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VotingItemComments_VotingItems_VotingItemId",
                        column: x => x.VotingItemId,
                        principalTable: "VotingItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "VotingContexts",
                columns: new[] { "Id", "CreateDate", "Description", "TargetContextId", "Title", "Type", "UserId" },
                values: new object[] { new Guid("1fee0e42-7cfb-4438-96f9-4dbee6019de9"), new DateTime(2019, 3, 28, 23, 21, 3, 949, DateTimeKind.Local), "Ideas for improvement on the community.", null, "IndieVisible Ideas", 0, new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.CreateIndex(
                name: "IX_UserVotes_VotingItemId",
                table: "UserVotes",
                column: "VotingItemId");

            migrationBuilder.CreateIndex(
                name: "IX_VotingItemComments_VotingItemId",
                table: "VotingItemComments",
                column: "VotingItemId");

            migrationBuilder.CreateIndex(
                name: "IX_VotingItems_ContextId",
                table: "VotingItems",
                column: "ContextId");
        }
    }
}
