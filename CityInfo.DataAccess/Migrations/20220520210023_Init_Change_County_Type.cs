using Microsoft.EntityFrameworkCore.Migrations;

namespace CityInfo.DataAccess.Migrations
{
    public partial class Init_Change_County_Type : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Countries_countryId",
                table: "Cities");

            migrationBuilder.RenameColumn(
                name: "countryId",
                table: "Cities",
                newName: "CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Cities_countryId",
                table: "Cities",
                newName: "IX_Cities_CountryId");

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "Cities",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Countries_CountryId",
                table: "Cities",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Countries_CountryId",
                table: "Cities");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "Cities",
                newName: "countryId");

            migrationBuilder.RenameIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                newName: "IX_Cities_countryId");

            migrationBuilder.AlterColumn<int>(
                name: "countryId",
                table: "Cities",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Countries_countryId",
                table: "Cities",
                column: "countryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
