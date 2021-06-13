using Microsoft.EntityFrameworkCore.Migrations;

namespace YnovEat.Api.Migrations
{
    public partial class V0208 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantUsers_AspNetUsers_Id",
                table: "RestaurantUsers");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "RestaurantUsers",
                newName: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantUsers_AspNetUsers_UserId",
                table: "RestaurantUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantUsers_AspNetUsers_UserId",
                table: "RestaurantUsers");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "RestaurantUsers",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantUsers_AspNetUsers_Id",
                table: "RestaurantUsers",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
