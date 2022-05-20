using Microsoft.EntityFrameworkCore.Migrations;

namespace CityInfo.DataAccess.Migrations
{
    public partial class Init_Remove_Connection_Column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Connection",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Connection",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
