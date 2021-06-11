using Microsoft.EntityFrameworkCore.Migrations;

namespace YnovEat.Api.Migrations
{
    public partial class V0201 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantUsers_Restaurants_RestaurantId1",
                table: "RestaurantUsers");

            migrationBuilder.DropIndex(
                name: "IX_RestaurantUsers_RestaurantId1",
                table: "RestaurantUsers");

            migrationBuilder.DropColumn(
                name: "RestaurantId1",
                table: "RestaurantUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RestaurantId1",
                table: "RestaurantUsers",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantUsers_RestaurantId1",
                table: "RestaurantUsers",
                column: "RestaurantId1");

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantUsers_Restaurants_RestaurantId1",
                table: "RestaurantUsers",
                column: "RestaurantId1",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
