using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarehouseMaster.Data.Migrations
{
    /// <inheritdoc />
    public partial class init5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Warehouses_staffer_StafferId",
                table: "Warehouses");

            migrationBuilder.DropIndex(
                name: "IX_Warehouses_StafferId",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "StafferId",
                table: "Warehouses");

            migrationBuilder.AddColumn<int>(
                name: "warehouse_id",
                table: "staffer",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_staffer_warehouse_id",
                table: "staffer",
                column: "warehouse_id");

            migrationBuilder.AddForeignKey(
                name: "FK_staffer_Warehouses_warehouse_id",
                table: "staffer",
                column: "warehouse_id",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_staffer_Warehouses_warehouse_id",
                table: "staffer");

            migrationBuilder.DropIndex(
                name: "IX_staffer_warehouse_id",
                table: "staffer");

            migrationBuilder.DropColumn(
                name: "warehouse_id",
                table: "staffer");

            migrationBuilder.AddColumn<int>(
                name: "StafferId",
                table: "Warehouses",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_StafferId",
                table: "Warehouses",
                column: "StafferId");

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouses_staffer_StafferId",
                table: "Warehouses",
                column: "StafferId",
                principalTable: "staffer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
