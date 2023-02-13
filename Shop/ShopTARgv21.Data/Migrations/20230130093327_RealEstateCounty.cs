using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopTARgv21.Data.Migrations
{
    public partial class RealEstateCounty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "RealEstate");

            migrationBuilder.AddColumn<string>(
                name: "County",
                table: "RealEstate",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "County",
                table: "RealEstate");

            migrationBuilder.AddColumn<int>(
                name: "Country",
                table: "RealEstate",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
