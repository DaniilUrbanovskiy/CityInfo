using Microsoft.EntityFrameworkCore.Migrations;

namespace CityInfo.DataAccess.Migrations
{
    public partial class Init_Change_Props_Name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Countries_CountryId",
                table: "Cities");

            migrationBuilder.RenameColumn(
                name: "flag",
                table: "Countries",
                newName: "Flag");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "Countries",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "Cities",
                newName: "countryId");

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "Cities",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                newName: "IX_Cities_countryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Countries_countryId",
                table: "Cities",
                column: "countryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Countries_countryId",
                table: "Cities");

            migrationBuilder.RenameColumn(
                name: "Flag",
                table: "Countries",
                newName: "flag");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Countries",
                newName: "CountryId");

            migrationBuilder.RenameColumn(
                name: "countryId",
                table: "Cities",
                newName: "CountryId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Cities",
                newName: "CityId");

            migrationBuilder.RenameIndex(
                name: "IX_Cities_countryId",
                table: "Cities",
                newName: "IX_Cities_CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Countries_CountryId",
                table: "Cities",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
