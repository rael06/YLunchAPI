using Microsoft.EntityFrameworkCore.Migrations;

namespace YnovEat.Api.Migrations
{
    public partial class V02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerProduct_Carts_CartId",
                table: "CustomerProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerProduct_Orders_OrderId1",
                table: "CustomerProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_RestaurantUser_RestaurantOwnerId",
                table: "Restaurants");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantUser_AspNetUsers_Id",
                table: "RestaurantUser");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantUser_Restaurants_RestaurantId",
                table: "RestaurantUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RestaurantUser",
                table: "RestaurantUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerProduct",
                table: "CustomerProduct");

            migrationBuilder.RenameTable(
                name: "RestaurantUser",
                newName: "RestaurantUsers");

            migrationBuilder.RenameTable(
                name: "CustomerProduct",
                newName: "CustomerProducts");

            migrationBuilder.RenameIndex(
                name: "IX_RestaurantUser_RestaurantId",
                table: "RestaurantUsers",
                newName: "IX_RestaurantUsers_RestaurantId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerProduct_OrderId1",
                table: "CustomerProducts",
                newName: "IX_CustomerProducts_OrderId1");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerProduct_CartId",
                table: "CustomerProducts",
                newName: "IX_CustomerProducts_CartId");

            migrationBuilder.AddColumn<string>(
                name: "RestaurantId1",
                table: "RestaurantUsers",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RestaurantUsers",
                table: "RestaurantUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerProducts",
                table: "CustomerProducts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantUsers_RestaurantId1",
                table: "RestaurantUsers",
                column: "RestaurantId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerProducts_Carts_CartId",
                table: "CustomerProducts",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerProducts_Orders_OrderId1",
                table: "CustomerProducts",
                column: "OrderId1",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_RestaurantUsers_RestaurantOwnerId",
                table: "Restaurants",
                column: "RestaurantOwnerId",
                principalTable: "RestaurantUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantUsers_AspNetUsers_Id",
                table: "RestaurantUsers",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantUsers_Restaurants_RestaurantId",
                table: "RestaurantUsers",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantUsers_Restaurants_RestaurantId1",
                table: "RestaurantUsers",
                column: "RestaurantId1",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerProducts_Carts_CartId",
                table: "CustomerProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerProducts_Orders_OrderId1",
                table: "CustomerProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_RestaurantUsers_RestaurantOwnerId",
                table: "Restaurants");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantUsers_AspNetUsers_Id",
                table: "RestaurantUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantUsers_Restaurants_RestaurantId",
                table: "RestaurantUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantUsers_Restaurants_RestaurantId1",
                table: "RestaurantUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RestaurantUsers",
                table: "RestaurantUsers");

            migrationBuilder.DropIndex(
                name: "IX_RestaurantUsers_RestaurantId1",
                table: "RestaurantUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerProducts",
                table: "CustomerProducts");

            migrationBuilder.DropColumn(
                name: "RestaurantId1",
                table: "RestaurantUsers");

            migrationBuilder.RenameTable(
                name: "RestaurantUsers",
                newName: "RestaurantUser");

            migrationBuilder.RenameTable(
                name: "CustomerProducts",
                newName: "CustomerProduct");

            migrationBuilder.RenameIndex(
                name: "IX_RestaurantUsers_RestaurantId",
                table: "RestaurantUser",
                newName: "IX_RestaurantUser_RestaurantId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerProducts_OrderId1",
                table: "CustomerProduct",
                newName: "IX_CustomerProduct_OrderId1");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerProducts_CartId",
                table: "CustomerProduct",
                newName: "IX_CustomerProduct_CartId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RestaurantUser",
                table: "RestaurantUser",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerProduct",
                table: "CustomerProduct",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerProduct_Carts_CartId",
                table: "CustomerProduct",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerProduct_Orders_OrderId1",
                table: "CustomerProduct",
                column: "OrderId1",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_RestaurantUser_RestaurantOwnerId",
                table: "Restaurants",
                column: "RestaurantOwnerId",
                principalTable: "RestaurantUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantUser_AspNetUsers_Id",
                table: "RestaurantUser",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantUser_Restaurants_RestaurantId",
                table: "RestaurantUser",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
