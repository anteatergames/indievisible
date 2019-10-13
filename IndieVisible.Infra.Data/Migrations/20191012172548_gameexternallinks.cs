using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IndieVisible.Infra.Data.Migrations
{
    public partial class gameexternallinks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GameDevNetUrl",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "GameJoltUrl",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "IndieDbUrl",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "ItchIoUrl",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "UnityConnectUrl",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "FacebookUrl",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "GameDevNetUrl",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "GameJoltUrl",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "IndieDbUrl",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "InstagramUrl",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "ItchIoUrl",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "TwitterUrl",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "UnityConnectUrl",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Games");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "UserProfileExternalLink",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "UserProfileExternalLink",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "ThumbnailUrl",
                table: "Games",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeveloperName",
                table: "Games",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CoverImageUrl",
                table: "Games",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "GameExternalLink",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    GameId = table.Column<Guid>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Provider = table.Column<int>(nullable: false),
                    Value = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameExternalLink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameExternalLink_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameExternalLink_GameId",
                table: "GameExternalLink",
                column: "GameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameExternalLink");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "UserProfileExternalLink",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "UserProfileExternalLink",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AddColumn<string>(
                name: "GameDevNetUrl",
                table: "Profiles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GameJoltUrl",
                table: "Profiles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IndieDbUrl",
                table: "Profiles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItchIoUrl",
                table: "Profiles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UnityConnectUrl",
                table: "Profiles",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ThumbnailUrl",
                table: "Games",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeveloperName",
                table: "Games",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<string>(
                name: "CoverImageUrl",
                table: "Games",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FacebookUrl",
                table: "Games",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GameDevNetUrl",
                table: "Games",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GameJoltUrl",
                table: "Games",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IndieDbUrl",
                table: "Games",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstagramUrl",
                table: "Games",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItchIoUrl",
                table: "Games",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TwitterUrl",
                table: "Games",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UnityConnectUrl",
                table: "Games",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Games",
                nullable: true);
        }
    }
}
