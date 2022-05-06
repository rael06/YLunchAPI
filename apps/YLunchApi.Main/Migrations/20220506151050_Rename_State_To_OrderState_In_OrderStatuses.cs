using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YLunchApi.Main.Migrations
{
    public partial class Rename_State_To_OrderState_In_OrderStatuses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "State",
                table: "OrderStatuses",
                newName: "OrderState");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrderState",
                table: "OrderStatuses",
                newName: "State");
        }
    }
}
