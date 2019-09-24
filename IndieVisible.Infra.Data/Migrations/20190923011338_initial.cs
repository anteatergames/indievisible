using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace IndieVisible.Infra.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Connections",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    TargetUserId = table.Column<Guid>(nullable: false),
                    ApprovalDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Connections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FeaturedContents",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    Active = table.Column<bool>(nullable: false),
                    UserContentId = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Introduction = table.Column<string>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeaturedContents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Follows",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    FollowUserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Follows", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameFollows",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    GameId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameFollows", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameLikes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    GameId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameLikes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    GameJoltUrl = table.Column<string>(nullable: true),
                    ItchIoUrl = table.Column<string>(nullable: true),
                    IndieDbUrl = table.Column<string>(nullable: true),
                    GameDevNetUrl = table.Column<string>(nullable: true),
                    UnityConnectUrl = table.Column<string>(nullable: true),
                    DeveloperName = table.Column<string>(nullable: true),
                    Title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Url = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Genre = table.Column<int>(nullable: false),
                    CoverImageUrl = table.Column<string>(nullable: true),
                    ThumbnailUrl = table.Column<string>(nullable: true),
                    Engine = table.Column<int>(nullable: false),
                    Language = table.Column<int>(nullable: false),
                    WebsiteUrl = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    ReleaseDate = table.Column<DateTime>(nullable: true),
                    Platforms = table.Column<string>(nullable: true),
                    FacebookUrl = table.Column<string>(nullable: true),
                    TwitterUrl = table.Column<string>(nullable: true),
                    InstagramUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GamificationActions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    Action = table.Column<int>(nullable: false),
                    ScoreValue = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamificationActions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GamificationLevels",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    Number = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    XpToAchieve = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamificationLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gamifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    CurrentLevelNumber = table.Column<int>(nullable: false),
                    XpTotal = table.Column<int>(nullable: false),
                    XpCurrentLevel = table.Column<int>(nullable: false),
                    XpToNextLevel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gamifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    Type = table.Column<int>(nullable: false),
                    IsRead = table.Column<bool>(nullable: false),
                    Text = table.Column<string>(type: "nvarchar(256)", maxLength: 128, nullable: false),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    GameJoltUrl = table.Column<string>(nullable: true),
                    ItchIoUrl = table.Column<string>(nullable: true),
                    IndieDbUrl = table.Column<string>(nullable: true),
                    GameDevNetUrl = table.Column<string>(nullable: true),
                    UnityConnectUrl = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Motto = table.Column<string>(nullable: true),
                    Bio = table.Column<string>(nullable: true),
                    StudioName = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserBadges",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    Badge = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBadges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserPreferences",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UiLanguage = table.Column<int>(nullable: false),
                    ContentLanguages = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPreferences", x => x.Id);
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
                name: "UserContents",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    AuthorName = table.Column<string>(nullable: true),
                    AuthorPicture = table.Column<string>(nullable: true),
                    FeaturedImage = table.Column<string>(nullable: true),
                    Title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Introduction = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: false),
                    Language = table.Column<int>(nullable: false, defaultValue: 1),
                    GameId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserContents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserContents_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    ParentCommentId = table.Column<Guid>(nullable: false),
                    UserContentId = table.Column<Guid>(nullable: false),
                    AuthorName = table.Column<string>(nullable: true),
                    AuthorPicture = table.Column<string>(nullable: true),
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

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    ContentId = table.Column<Guid>(nullable: false),
                    UserContentId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Likes_UserContents_UserContentId",
                        column: x => x.UserContentId,
                        principalTable: "UserContents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Polls",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    UserContentId = table.Column<Guid>(nullable: true),
                    MultipleChoice = table.Column<bool>(nullable: false, defaultValue: false),
                    UsersCanAddOptions = table.Column<bool>(nullable: false, defaultValue: false),
                    CloseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Title = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Polls_UserContents_UserContentId",
                        column: x => x.UserContentId,
                        principalTable: "UserContents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PollOptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    PollId = table.Column<Guid>(nullable: false),
                    Index = table.Column<int>(nullable: false, defaultValue: 0),
                    Text = table.Column<string>(nullable: true),
                    Image = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PollOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PollOptions_Polls_PollId",
                        column: x => x.PollId,
                        principalTable: "Polls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PollVotes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    PollId = table.Column<Guid>(nullable: false),
                    PollOptionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PollVotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PollVotes_PollOptions_PollOptionId",
                        column: x => x.PollOptionId,
                        principalTable: "PollOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BrainstormSessions",
                columns: new[] { "Id", "CreateDate", "Description", "TargetContextId", "Title", "Type", "UserId" },
                values: new object[] { new Guid("1fee0e42-7cfb-4438-96f9-4dbee6019de9"), new DateTime(2019, 5, 23, 0, 21, 44, 473, DateTimeKind.Local), "Ideas for improvement on the community. This is where you can suggest new features to the community and vote for ideas from other users. This is the main mechanism to improve the community and make a place where everyone feels OK with it. Enjoy it!", null, "IndieVisible Ideas", 0, new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "GamificationActions",
                columns: new[] { "Id", "Action", "CreateDate", "ScoreValue", "UserId" },
                values: new object[,]
                {
                    { new Guid("f9d77561-1b39-4422-91bc-cbc9b05d8393"), 1, new DateTime(2019, 5, 23, 0, 21, 44, 473, DateTimeKind.Local), 5, new Guid("0c7e18b2-3682-444d-a62b-30e311e76891") },
                    { new Guid("72ab0038-de85-4ca0-9c38-aa9075441ee4"), 2, new DateTime(2019, 5, 23, 0, 21, 44, 473, DateTimeKind.Local), 10, new Guid("0c7e18b2-3682-444d-a62b-30e311e76891") },
                    { new Guid("10a4aa6c-5b83-44fb-b817-de60c81bc375"), 3, new DateTime(2019, 5, 23, 0, 21, 44, 473, DateTimeKind.Local), 10, new Guid("0c7e18b2-3682-444d-a62b-30e311e76891") },
                    { new Guid("c002bd0d-06ff-44de-b4aa-9d3b540cfe28"), 4, new DateTime(2019, 5, 23, 0, 21, 44, 473, DateTimeKind.Local), 10, new Guid("0c7e18b2-3682-444d-a62b-30e311e76891") },
                    { new Guid("cccbd822-5cb7-405c-8539-6ba7e2ded11f"), 5, new DateTime(2019, 5, 23, 0, 21, 44, 473, DateTimeKind.Local), 30, new Guid("0c7e18b2-3682-444d-a62b-30e311e76891") },
                    { new Guid("8b1aec66-ed4e-4d8b-85f2-fa46eda341ee"), 6, new DateTime(2019, 5, 23, 0, 21, 44, 473, DateTimeKind.Local), 30, new Guid("0c7e18b2-3682-444d-a62b-30e311e76891") },
                    { new Guid("a7139047-a7c6-4d56-a102-a9f103a75438"), 7, new DateTime(2019, 5, 23, 0, 21, 44, 473, DateTimeKind.Local), 30, new Guid("0c7e18b2-3682-444d-a62b-30e311e76891") },
                    { new Guid("0d607bf9-040a-48bc-8925-b423981c7daf"), 8, new DateTime(2019, 5, 23, 0, 21, 44, 473, DateTimeKind.Local), 30, new Guid("0c7e18b2-3682-444d-a62b-30e311e76891") }
                });

            migrationBuilder.InsertData(
                table: "GamificationLevels",
                columns: new[] { "Id", "CreateDate", "Name", "Number", "UserId", "XpToAchieve" },
                values: new object[,]
                {
                    { new Guid("929b63bf-9464-49db-8904-6b500d52082b"), new DateTime(2019, 5, 23, 0, 21, 44, 473, DateTimeKind.Local), "Engine Ninja", 8, new Guid("0c7e18b2-3682-444d-a62b-30e311e76891"), 60000 },
                    { new Guid("ef8220ff-f7ea-451a-a229-3435669b3854"), new DateTime(2019, 5, 23, 0, 21, 44, 473, DateTimeKind.Local), "Asset Assembler", 7, new Guid("0c7e18b2-3682-444d-a62b-30e311e76891"), 30000 },
                    { new Guid("f539bd4c-04f8-4f1a-b815-55b46d85b49b"), new DateTime(2019, 5, 23, 0, 21, 44, 473, DateTimeKind.Local), "Tutorial Guy", 6, new Guid("0c7e18b2-3682-444d-a62b-30e311e76891"), 10000 },
                    { new Guid("d7df851b-2a76-4640-9dc5-2de4cdcac722"), new DateTime(2019, 5, 23, 0, 21, 44, 473, DateTimeKind.Local), "Flappy Maker", 5, new Guid("0c7e18b2-3682-444d-a62b-30e311e76891"), 5000 },
                    { new Guid("a043343c-cdf7-4c0e-a51a-cddd020d5884"), new DateTime(2019, 5, 23, 0, 21, 44, 473, DateTimeKind.Local), "NPC", 1, new Guid("0c7e18b2-3682-444d-a62b-30e311e76891"), 500 },
                    { new Guid("dbbd17a9-2114-4cf5-a723-251dc6521cad"), new DateTime(2019, 5, 23, 0, 21, 44, 473, DateTimeKind.Local), "I can make a GTA", 3, new Guid("0c7e18b2-3682-444d-a62b-30e311e76891"), 2000 },
                    { new Guid("923bfb12-ea49-442d-8f28-bf9726644264"), new DateTime(2019, 5, 23, 0, 21, 44, 473, DateTimeKind.Local), "Idea Guy", 2, new Guid("0c7e18b2-3682-444d-a62b-30e311e76891"), 1000 },
                    { new Guid("1aaaf717-4cbd-4ee3-90d3-0452e51d1a19"), new DateTime(2019, 5, 23, 0, 21, 44, 473, DateTimeKind.Local), "Jam Jammer", 9, new Guid("0c7e18b2-3682-444d-a62b-30e311e76891"), 100000 },
                    { new Guid("cb72c778-337f-48be-b255-86f26d086084"), new DateTime(2019, 5, 23, 0, 21, 44, 473, DateTimeKind.Local), "Profit Sharer", 4, new Guid("0c7e18b2-3682-444d-a62b-30e311e76891"), 3000 },
                    { new Guid("77c72240-b6d9-49e0-885d-de202c4f9dfd"), new DateTime(2019, 5, 23, 0, 21, 44, 473, DateTimeKind.Local), "My Studio Games", 10, new Guid("0c7e18b2-3682-444d-a62b-30e311e76891"), 200000 }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserContentId",
                table: "Comments",
                column: "UserContentId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_UserContentId",
                table: "Likes",
                column: "UserContentId");

            migrationBuilder.CreateIndex(
                name: "IX_PollOptions_PollId",
                table: "PollOptions",
                column: "PollId");

            migrationBuilder.CreateIndex(
                name: "IX_Polls_UserContentId",
                table: "Polls",
                column: "UserContentId");

            migrationBuilder.CreateIndex(
                name: "IX_PollVotes_PollOptionId",
                table: "PollVotes",
                column: "PollOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserContents_GameId",
                table: "UserContents",
                column: "GameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BrainstormComments");

            migrationBuilder.DropTable(
                name: "BrainstormVotes");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Connections");

            migrationBuilder.DropTable(
                name: "FeaturedContents");

            migrationBuilder.DropTable(
                name: "Follows");

            migrationBuilder.DropTable(
                name: "GameFollows");

            migrationBuilder.DropTable(
                name: "GameLikes");

            migrationBuilder.DropTable(
                name: "GamificationActions");

            migrationBuilder.DropTable(
                name: "GamificationLevels");

            migrationBuilder.DropTable(
                name: "Gamifications");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "PollVotes");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "UserBadges");

            migrationBuilder.DropTable(
                name: "UserPreferences");

            migrationBuilder.DropTable(
                name: "BrainstormIdeas");

            migrationBuilder.DropTable(
                name: "PollOptions");

            migrationBuilder.DropTable(
                name: "BrainstormSessions");

            migrationBuilder.DropTable(
                name: "Polls");

            migrationBuilder.DropTable(
                name: "UserContents");

            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
