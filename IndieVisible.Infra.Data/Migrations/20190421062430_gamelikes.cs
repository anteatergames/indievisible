using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IndieVisible.Infra.Data.Migrations
{
    public partial class gamelikes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "BrainstormSessions",
                keyColumn: "Id",
                keyValue: new Guid("1fee0e42-7cfb-4438-96f9-4dbee6019de9"),
                columns: new[] { "CreateDate", "Description" },
                values: new object[] { new DateTime(2019, 4, 21, 3, 24, 30, 580, DateTimeKind.Local), "Ideas for improvement on the community. This is where you can suggest new features to the community and vote for ideas from other users. This is the main mechanism to improve the community and make a place where everyone feels OK with it. Enjoy it!" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameLikes");

            migrationBuilder.UpdateData(
                table: "BrainstormSessions",
                keyColumn: "Id",
                keyValue: new Guid("1fee0e42-7cfb-4438-96f9-4dbee6019de9"),
                columns: new[] { "CreateDate", "Description" },
                values: new object[] { new DateTime(2019, 4, 7, 22, 9, 44, 87, DateTimeKind.Local), "Ideas for improvement on the community." });
        }
    }
}
