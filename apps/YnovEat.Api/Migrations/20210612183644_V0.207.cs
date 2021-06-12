using Microsoft.EntityFrameworkCore.Migrations;

namespace YnovEat.Api.Migrations
{
    public partial class V0207 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OpeningTimes_WeeksOpeningTimes_DayOpeningTimesId",
                table: "OpeningTimes");

            migrationBuilder.DropForeignKey(
                name: "FK_WeeksOpeningTimes_Restaurants_RestaurantId",
                table: "WeeksOpeningTimes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WeeksOpeningTimes",
                table: "WeeksOpeningTimes");

            migrationBuilder.RenameTable(
                name: "WeeksOpeningTimes",
                newName: "DaysOpeningTimes");

            migrationBuilder.RenameIndex(
                name: "IX_WeeksOpeningTimes_RestaurantId",
                table: "DaysOpeningTimes",
                newName: "IX_DaysOpeningTimes_RestaurantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DaysOpeningTimes",
                table: "DaysOpeningTimes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DaysOpeningTimes_Restaurants_RestaurantId",
                table: "DaysOpeningTimes",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OpeningTimes_DaysOpeningTimes_DayOpeningTimesId",
                table: "OpeningTimes",
                column: "DayOpeningTimesId",
                principalTable: "DaysOpeningTimes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DaysOpeningTimes_Restaurants_RestaurantId",
                table: "DaysOpeningTimes");

            migrationBuilder.DropForeignKey(
                name: "FK_OpeningTimes_DaysOpeningTimes_DayOpeningTimesId",
                table: "OpeningTimes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DaysOpeningTimes",
                table: "DaysOpeningTimes");

            migrationBuilder.RenameTable(
                name: "DaysOpeningTimes",
                newName: "WeeksOpeningTimes");

            migrationBuilder.RenameIndex(
                name: "IX_DaysOpeningTimes_RestaurantId",
                table: "WeeksOpeningTimes",
                newName: "IX_WeeksOpeningTimes_RestaurantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WeeksOpeningTimes",
                table: "WeeksOpeningTimes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OpeningTimes_WeeksOpeningTimes_DayOpeningTimesId",
                table: "OpeningTimes",
                column: "DayOpeningTimesId",
                principalTable: "WeeksOpeningTimes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WeeksOpeningTimes_Restaurants_RestaurantId",
                table: "WeeksOpeningTimes",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
