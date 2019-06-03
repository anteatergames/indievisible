using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IndieVisible.Infra.Data.Migrations
{
    public partial class notificationbasic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "BrainstormSessions",
                keyColumn: "Id",
                keyValue: new Guid("1fee0e42-7cfb-4438-96f9-4dbee6019de9"),
                column: "CreateDate",
                value: new DateTime(2019, 4, 21, 20, 17, 47, 590, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.UpdateData(
                table: "BrainstormSessions",
                keyColumn: "Id",
                keyValue: new Guid("1fee0e42-7cfb-4438-96f9-4dbee6019de9"),
                column: "CreateDate",
                value: new DateTime(2019, 4, 21, 3, 24, 30, 580, DateTimeKind.Local));
        }
    }
}
