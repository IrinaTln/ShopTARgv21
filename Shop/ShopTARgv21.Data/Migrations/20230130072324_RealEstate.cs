using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopTARgv21.Data.Migrations
{
    public partial class RealEstate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RealEstate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<int>(type: "int", nullable: false),
                    BuildingType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<double>(type: "float", nullable: false),
                    RoomNumber = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstate", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RealEstate");
        }
    }
}
