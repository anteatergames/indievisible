using Microsoft.EntityFrameworkCore.Migrations;

namespace IndieVisible.Infra.Data.Migrations
{
    public partial class customengine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomEngineName",
                table: "Games",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomEngineName",
                table: "Games");
        }
    }
}
