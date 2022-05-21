using Microsoft.EntityFrameworkCore.Migrations;

namespace CityInfo.DataAccess.Migrations
{
    public partial class Init_Remove_Info_From_Country : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Info",
                table: "Countries");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Info",
                table: "Countries",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
