using Microsoft.EntityFrameworkCore.Migrations;

namespace YnovEat.Api.Migrations
{
    public partial class V0206 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OpeningHours");

            migrationBuilder.DropTable(
                name: "DayOpeningHours");

            migrationBuilder.CreateTable(
                name: "WeeksOpeningTimes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false),
                    RestaurantId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeksOpeningTimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeeksOpeningTimes_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OpeningTimes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StartTimeInMinutes = table.Column<int>(type: "int", nullable: false),
                    EndTimeInMinutes = table.Column<int>(type: "int", nullable: false),
                    StartOrderTimeInMinutes = table.Column<int>(type: "int", nullable: true),
                    EndOrderTimeInMinutes = table.Column<int>(type: "int", nullable: true),
                    DayOpeningTimesId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpeningTimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpeningTimes_WeeksOpeningTimes_DayOpeningTimesId",
                        column: x => x.DayOpeningTimesId,
                        principalTable: "WeeksOpeningTimes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_OpeningTimes_DayOpeningTimesId",
                table: "OpeningTimes",
                column: "DayOpeningTimesId");

            migrationBuilder.CreateIndex(
                name: "IX_WeeksOpeningTimes_RestaurantId",
                table: "WeeksOpeningTimes",
                column: "RestaurantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OpeningTimes");

            migrationBuilder.DropTable(
                name: "WeeksOpeningTimes");

            migrationBuilder.CreateTable(
                name: "DayOpeningHours",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false),
                    RestaurantId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayOpeningHours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DayOpeningHours_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OpeningHours",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DayOpeningHoursId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EndHourInMinutes = table.Column<int>(type: "int", nullable: false),
                    OrderTimeLimitInMinutes = table.Column<int>(type: "int", nullable: true),
                    StartHourInMinutes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpeningHours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpeningHours_DayOpeningHours_DayOpeningHoursId",
                        column: x => x.DayOpeningHoursId,
                        principalTable: "DayOpeningHours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_DayOpeningHours_RestaurantId",
                table: "DayOpeningHours",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_OpeningHours_DayOpeningHoursId",
                table: "OpeningHours",
                column: "DayOpeningHoursId");
        }
    }
}
