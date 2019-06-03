using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IndieVisible.Infra.Data.Migrations
{
    public partial class gamification01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "BrainstormSessions",
                keyColumn: "Id",
                keyValue: new Guid("1fee0e42-7cfb-4438-96f9-4dbee6019de9"),
                column: "CreateDate",
                value: new DateTime(2019, 5, 8, 22, 10, 43, 403, DateTimeKind.Local));

            migrationBuilder.InsertData(
                table: "GamificationActions",
                columns: new[] { "Id", "Action", "CreateDate", "ScoreValue", "UserId" },
                values: new object[,]
                {
                    { new Guid("f9d77561-1b39-4422-91bc-cbc9b05d8393"), 1, new DateTime(2019, 5, 8, 22, 10, 43, 406, DateTimeKind.Local), 5, new Guid("0c7e18b2-3682-444d-a62b-30e311e76891") },
                    { new Guid("72ab0038-de85-4ca0-9c38-aa9075441ee4"), 2, new DateTime(2019, 5, 8, 22, 10, 43, 406, DateTimeKind.Local), 10, new Guid("0c7e18b2-3682-444d-a62b-30e311e76891") },
                    { new Guid("10a4aa6c-5b83-44fb-b817-de60c81bc375"), 3, new DateTime(2019, 5, 8, 22, 10, 43, 406, DateTimeKind.Local), 10, new Guid("0c7e18b2-3682-444d-a62b-30e311e76891") },
                    { new Guid("c002bd0d-06ff-44de-b4aa-9d3b540cfe28"), 4, new DateTime(2019, 5, 8, 22, 10, 43, 406, DateTimeKind.Local), 10, new Guid("0c7e18b2-3682-444d-a62b-30e311e76891") },
                    { new Guid("cccbd822-5cb7-405c-8539-6ba7e2ded11f"), 5, new DateTime(2019, 5, 8, 22, 10, 43, 406, DateTimeKind.Local), 30, new Guid("0c7e18b2-3682-444d-a62b-30e311e76891") },
                    { new Guid("8b1aec66-ed4e-4d8b-85f2-fa46eda341ee"), 6, new DateTime(2019, 5, 8, 22, 10, 43, 406, DateTimeKind.Local), 30, new Guid("0c7e18b2-3682-444d-a62b-30e311e76891") },
                    { new Guid("a7139047-a7c6-4d56-a102-a9f103a75438"), 7, new DateTime(2019, 5, 8, 22, 10, 43, 406, DateTimeKind.Local), 30, new Guid("0c7e18b2-3682-444d-a62b-30e311e76891") },
                    { new Guid("0d607bf9-040a-48bc-8925-b423981c7daf"), 8, new DateTime(2019, 5, 8, 22, 10, 43, 406, DateTimeKind.Local), 30, new Guid("0c7e18b2-3682-444d-a62b-30e311e76891") }
                });

            migrationBuilder.InsertData(
                table: "GamificationLevels",
                columns: new[] { "Id", "CreateDate", "Name", "Number", "UserId", "XpToAchieve" },
                values: new object[,]
                {
                    { new Guid("a043343c-cdf7-4c0e-a51a-cddd020d5884"), new DateTime(2019, 5, 8, 22, 10, 43, 407, DateTimeKind.Local), "NPC", 1, new Guid("0c7e18b2-3682-444d-a62b-30e311e76891"), 500 },
                    { new Guid("923bfb12-ea49-442d-8f28-bf9726644264"), new DateTime(2019, 5, 8, 22, 10, 43, 408, DateTimeKind.Local), "Idea Guy", 2, new Guid("0c7e18b2-3682-444d-a62b-30e311e76891"), 1000 },
                    { new Guid("dbbd17a9-2114-4cf5-a723-251dc6521cad"), new DateTime(2019, 5, 8, 22, 10, 43, 408, DateTimeKind.Local), "I can make a GTA", 3, new Guid("0c7e18b2-3682-444d-a62b-30e311e76891"), 2000 },
                    { new Guid("cb72c778-337f-48be-b255-86f26d086084"), new DateTime(2019, 5, 8, 22, 10, 43, 408, DateTimeKind.Local), "Profit Sharer", 4, new Guid("0c7e18b2-3682-444d-a62b-30e311e76891"), 3000 },
                    { new Guid("d7df851b-2a76-4640-9dc5-2de4cdcac722"), new DateTime(2019, 5, 8, 22, 10, 43, 408, DateTimeKind.Local), "Flappy Maker", 5, new Guid("0c7e18b2-3682-444d-a62b-30e311e76891"), 5000 },
                    { new Guid("f539bd4c-04f8-4f1a-b815-55b46d85b49b"), new DateTime(2019, 5, 8, 22, 10, 43, 408, DateTimeKind.Local), "Tutorial Guy", 6, new Guid("0c7e18b2-3682-444d-a62b-30e311e76891"), 10000 },
                    { new Guid("ef8220ff-f7ea-451a-a229-3435669b3854"), new DateTime(2019, 5, 8, 22, 10, 43, 408, DateTimeKind.Local), "Asset Assembler", 7, new Guid("0c7e18b2-3682-444d-a62b-30e311e76891"), 30000 },
                    { new Guid("929b63bf-9464-49db-8904-6b500d52082b"), new DateTime(2019, 5, 8, 22, 10, 43, 408, DateTimeKind.Local), "Engine Ninja", 8, new Guid("0c7e18b2-3682-444d-a62b-30e311e76891"), 60000 },
                    { new Guid("1aaaf717-4cbd-4ee3-90d3-0452e51d1a19"), new DateTime(2019, 5, 8, 22, 10, 43, 408, DateTimeKind.Local), "Jam Jammer", 9, new Guid("0c7e18b2-3682-444d-a62b-30e311e76891"), 100000 },
                    { new Guid("77c72240-b6d9-49e0-885d-de202c4f9dfd"), new DateTime(2019, 5, 8, 22, 10, 43, 408, DateTimeKind.Local), "My Studio Games", 10, new Guid("0c7e18b2-3682-444d-a62b-30e311e76891"), 200000 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GamificationActions");

            migrationBuilder.DropTable(
                name: "GamificationLevels");

            migrationBuilder.DropTable(
                name: "Gamifications");

            migrationBuilder.UpdateData(
                table: "BrainstormSessions",
                keyColumn: "Id",
                keyValue: new Guid("1fee0e42-7cfb-4438-96f9-4dbee6019de9"),
                column: "CreateDate",
                value: new DateTime(2019, 4, 21, 20, 17, 47, 590, DateTimeKind.Local));
        }
    }
}
