using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YnovEat.Api.Migrations
{
    public partial class restaurant_step_18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpirationDateTime",
                table: "CustomerProduct");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "CustomerProduct");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "CustomerProduct");

            migrationBuilder.AddColumn<bool>(
                name: "IsDone",
                table: "Orders",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDone",
                table: "Orders");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpirationDateTime",
                table: "CustomerProduct",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "CustomerProduct",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "CustomerProduct",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
