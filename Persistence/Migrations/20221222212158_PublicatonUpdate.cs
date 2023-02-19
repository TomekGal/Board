using Microsoft.EntityFrameworkCore.Migrations;

namespace Board.Data.Migrations
{
    public partial class PublicatonUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FileModelId",
                table: "Publications",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileModelId",
                table: "Publications");
        }
    }
}
