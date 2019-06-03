using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IndieVisible.Infra.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    GameJoltUrl = table.Column<string>(nullable: true),
                    ItchIoUrl = table.Column<string>(nullable: true),
                    IndieDbUrl = table.Column<string>(nullable: true),
                    GameDevNetUrl = table.Column<string>(nullable: true),
                    UnityConnectUrl = table.Column<string>(nullable: true),
                    Title = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
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
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    GameJoltUrl = table.Column<string>(nullable: true),
                    ItchIoUrl = table.Column<string>(nullable: true),
                    IndieDbUrl = table.Column<string>(nullable: true),
                    GameDevNetUrl = table.Column<string>(nullable: true),
                    UnityConnectUrl = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Motto = table.Column<string>(nullable: true),
                    CoverImageUrl = table.Column<string>(nullable: true),
                    Bio = table.Column<string>(nullable: true),
                    StudioName = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Profiles");
        }
    }
}
