using Microsoft.EntityFrameworkCore.Migrations;

namespace YnovEat.Api.Migrations
{
    public partial class V0204 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderLimitTimeInMinutes",
                table: "Restaurants");

            migrationBuilder.AddColumn<int>(
                name: "OrderTimeLimit",
                table: "OpeningHours",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderTimeLimit",
                table: "OpeningHours");

            migrationBuilder.AddColumn<int>(
                name: "OrderLimitTimeInMinutes",
                table: "Restaurants",
                type: "int",
                nullable: true);
        }
    }
}
