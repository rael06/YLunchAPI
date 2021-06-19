using Microsoft.EntityFrameworkCore.Migrations;

namespace YnovEat.Api.Migrations
{
    public partial class V0216 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerProducts_Carts_CartId",
                table: "CustomerProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerProducts_Orders_OrderId1",
                table: "CustomerProducts");

            migrationBuilder.DropIndex(
                name: "IX_CustomerProducts_CartId",
                table: "CustomerProducts");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "CustomerProducts");

            migrationBuilder.RenameColumn(
                name: "OrderId1",
                table: "CustomerProducts",
                newName: "CartUserId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerProducts_OrderId1",
                table: "CustomerProducts",
                newName: "IX_CustomerProducts_CartUserId");

            migrationBuilder.AlterColumn<string>(
                name: "RestaurantProductId",
                table: "CustomerProducts",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "OrderId",
                table: "CustomerProducts",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerProducts_OrderId",
                table: "CustomerProducts",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerProducts_Carts_CartUserId",
                table: "CustomerProducts",
                column: "CartUserId",
                principalTable: "Carts",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerProducts_Orders_OrderId",
                table: "CustomerProducts",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerProducts_Carts_CartUserId",
                table: "CustomerProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerProducts_Orders_OrderId",
                table: "CustomerProducts");

            migrationBuilder.DropIndex(
                name: "IX_CustomerProducts_OrderId",
                table: "CustomerProducts");

            migrationBuilder.RenameColumn(
                name: "CartUserId",
                table: "CustomerProducts",
                newName: "OrderId1");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerProducts_CartUserId",
                table: "CustomerProducts",
                newName: "IX_CustomerProducts_OrderId1");

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantProductId",
                table: "CustomerProducts",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "CustomerProducts",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "CartId",
                table: "CustomerProducts",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerProducts_CartId",
                table: "CustomerProducts",
                column: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerProducts_Carts_CartId",
                table: "CustomerProducts",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerProducts_Orders_OrderId1",
                table: "CustomerProducts",
                column: "OrderId1",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
