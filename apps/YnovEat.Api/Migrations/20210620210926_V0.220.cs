using Microsoft.EntityFrameworkCore.Migrations;

namespace YnovEat.Api.Migrations
{
    public partial class V0220 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Comment",
                table: "Orders",
                newName: "RestaurantComment");

            migrationBuilder.AddColumn<string>(
                name: "CustomerComment",
                table: "Orders",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "RestaurantId",
                table: "CustomerProducts",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerComment",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "CustomerProducts");

            migrationBuilder.RenameColumn(
                name: "RestaurantComment",
                table: "Orders",
                newName: "Comment");
        }
    }
}
