using Microsoft.EntityFrameworkCore.Migrations;

namespace YnovEat.Api.Migrations
{
    public partial class V217 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantUser_Restaurants_Id",
                table: "RestaurantUser");

            migrationBuilder.AddColumn<string>(
                name: "RestaurantOwnerId",
                table: "Restaurants",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_RestaurantOwnerId",
                table: "Restaurants",
                column: "RestaurantOwnerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_RestaurantUser_RestaurantOwnerId",
                table: "Restaurants",
                column: "RestaurantOwnerId",
                principalTable: "RestaurantUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_RestaurantUser_RestaurantOwnerId",
                table: "Restaurants");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_RestaurantOwnerId",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "RestaurantOwnerId",
                table: "Restaurants");

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantUser_Restaurants_Id",
                table: "RestaurantUser",
                column: "Id",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
