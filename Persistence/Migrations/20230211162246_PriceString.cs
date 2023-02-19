using Microsoft.EntityFrameworkCore.Migrations;

namespace Board.Data.Migrations
{
    public partial class PriceString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Price",
                table: "Publications",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Publications",
                type: "float",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
