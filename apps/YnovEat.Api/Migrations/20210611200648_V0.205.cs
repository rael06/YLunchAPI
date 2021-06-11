using Microsoft.EntityFrameworkCore.Migrations;

namespace YnovEat.Api.Migrations
{
    public partial class V0205 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderTimeLimit",
                table: "OpeningHours");

            migrationBuilder.AddColumn<int>(
                name: "OrderTimeLimitInMinutes",
                table: "OpeningHours",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderTimeLimitInMinutes",
                table: "OpeningHours");

            migrationBuilder.AddColumn<int>(
                name: "OrderTimeLimit",
                table: "OpeningHours",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
