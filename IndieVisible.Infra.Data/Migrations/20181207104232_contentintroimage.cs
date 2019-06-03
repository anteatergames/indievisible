using Microsoft.EntityFrameworkCore.Migrations;

namespace IndieVisible.Infra.Data.Migrations
{
    public partial class contentintroimage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FeaturedImage",
                table: "UserContents",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Introduction",
                table: "UserContents",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FeaturedImage",
                table: "UserContents");

            migrationBuilder.DropColumn(
                name: "Introduction",
                table: "UserContents");
        }
    }
}
