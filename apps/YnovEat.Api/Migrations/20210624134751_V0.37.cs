using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YnovEat.Api.Migrations
{
    public partial class V037 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ReservedForDateTime",
                table: "Orders",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReservedForDateTime",
                table: "Orders");
        }
    }
}
