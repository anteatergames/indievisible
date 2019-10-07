using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IndieVisible.Infra.Data.Migrations
{
    public partial class newgamificationactions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "GamificationActions",
                keyColumn: "Id",
                keyValue: new Guid("a7139047-a7c6-4d56-a102-a9f103a75438"),
                column: "ScoreValue",
                value: 50);

            migrationBuilder.UpdateData(
                table: "GamificationActions",
                keyColumn: "Id",
                keyValue: new Guid("c002bd0d-06ff-44de-b4aa-9d3b540cfe28"),
                column: "ScoreValue",
                value: 20);

            migrationBuilder.UpdateData(
                table: "GamificationActions",
                keyColumn: "Id",
                keyValue: new Guid("cccbd822-5cb7-405c-8539-6ba7e2ded11f"),
                column: "ScoreValue",
                value: 50);

            migrationBuilder.InsertData(
                table: "GamificationActions",
                columns: new[] { "Id", "Action", "CreateDate", "ScoreValue", "UserId" },
                values: new object[,]
                {
                    { new Guid("320332ac-52d2-43e9-a4ec-2378271ef50a"), 9, new DateTime(2019, 10, 6, 21, 16, 0, 0, DateTimeKind.Local), 20, new Guid("0c7e18b2-3682-444d-a62b-30e311e76891") },
                    { new Guid("7295e019-5595-4cc4-8253-f63886dbc7d9"), 10, new DateTime(2019, 10, 6, 21, 16, 0, 0, DateTimeKind.Local), 5, new Guid("0c7e18b2-3682-444d-a62b-30e311e76891") },
                    { new Guid("f7bf51b6-79cf-4588-856f-93c432501d0b"), 11, new DateTime(2019, 10, 6, 21, 16, 0, 0, DateTimeKind.Local), 30, new Guid("0c7e18b2-3682-444d-a62b-30e311e76891") },
                    { new Guid("1746f01e-e673-447e-b0e6-cebfcb7cb621"), 12, new DateTime(2019, 10, 6, 21, 16, 0, 0, DateTimeKind.Local), 20, new Guid("0c7e18b2-3682-444d-a62b-30e311e76891") },
                    { new Guid("827c139b-2399-4602-b56c-b3dd611697b6"), 13, new DateTime(2019, 10, 6, 21, 16, 0, 0, DateTimeKind.Local), 20, new Guid("0c7e18b2-3682-444d-a62b-30e311e76891") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GamificationActions",
                keyColumn: "Id",
                keyValue: new Guid("1746f01e-e673-447e-b0e6-cebfcb7cb621"));

            migrationBuilder.DeleteData(
                table: "GamificationActions",
                keyColumn: "Id",
                keyValue: new Guid("320332ac-52d2-43e9-a4ec-2378271ef50a"));

            migrationBuilder.DeleteData(
                table: "GamificationActions",
                keyColumn: "Id",
                keyValue: new Guid("7295e019-5595-4cc4-8253-f63886dbc7d9"));

            migrationBuilder.DeleteData(
                table: "GamificationActions",
                keyColumn: "Id",
                keyValue: new Guid("827c139b-2399-4602-b56c-b3dd611697b6"));

            migrationBuilder.DeleteData(
                table: "GamificationActions",
                keyColumn: "Id",
                keyValue: new Guid("f7bf51b6-79cf-4588-856f-93c432501d0b"));

            migrationBuilder.UpdateData(
                table: "GamificationActions",
                keyColumn: "Id",
                keyValue: new Guid("a7139047-a7c6-4d56-a102-a9f103a75438"),
                column: "ScoreValue",
                value: 30);

            migrationBuilder.UpdateData(
                table: "GamificationActions",
                keyColumn: "Id",
                keyValue: new Guid("c002bd0d-06ff-44de-b4aa-9d3b540cfe28"),
                column: "ScoreValue",
                value: 10);

            migrationBuilder.UpdateData(
                table: "GamificationActions",
                keyColumn: "Id",
                keyValue: new Guid("cccbd822-5cb7-405c-8539-6ba7e2ded11f"),
                column: "ScoreValue",
                value: 30);
        }
    }
}
