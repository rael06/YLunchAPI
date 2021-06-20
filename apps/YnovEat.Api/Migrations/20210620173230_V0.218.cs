using Microsoft.EntityFrameworkCore.Migrations;

namespace YnovEat.Api.Migrations
{
    public partial class V0218 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_RestaurantUsers_OwnerId",
                table: "Restaurants");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_OwnerId",
                table: "Restaurants");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "Restaurants",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "OwnerUserId",
                table: "Restaurants",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_OwnerUserId",
                table: "Restaurants",
                column: "OwnerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_RestaurantUsers_OwnerUserId",
                table: "Restaurants",
                column: "OwnerUserId",
                principalTable: "RestaurantUsers",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_RestaurantUsers_OwnerUserId",
                table: "Restaurants");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_OwnerUserId",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "OwnerUserId",
                table: "Restaurants");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "Restaurants",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_OwnerId",
                table: "Restaurants",
                column: "OwnerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_RestaurantUsers_OwnerId",
                table: "Restaurants",
                column: "OwnerId",
                principalTable: "RestaurantUsers",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
