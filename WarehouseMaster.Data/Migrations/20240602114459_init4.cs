using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarehouseMaster.Data.Migrations
{
    /// <inheritdoc />
    public partial class init4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Warehouse_staffer_StafferId",
                table: "Warehouse");

            migrationBuilder.DropForeignKey(
                name: "FK_product_Warehouse_WarehouseId",
                table: "product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Warehouse",
                table: "Warehouse");

            migrationBuilder.RenameTable(
                name: "Warehouse",
                newName: "Warehouses");

            migrationBuilder.RenameColumn(
                name: "CountEmployers",
                table: "Warehouses",
                newName: "CountEmployees");

            migrationBuilder.RenameIndex(
                name: "IX_Warehouse_StafferId",
                table: "Warehouses",
                newName: "IX_Warehouses_StafferId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Warehouses",
                table: "Warehouses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouses_staffer_StafferId",
                table: "Warehouses",
                column: "StafferId",
                principalTable: "staffer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_product_Warehouses_WarehouseId",
                table: "product",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Warehouses_staffer_StafferId",
                table: "Warehouses");

            migrationBuilder.DropForeignKey(
                name: "FK_product_Warehouses_WarehouseId",
                table: "product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Warehouses",
                table: "Warehouses");

            migrationBuilder.RenameTable(
                name: "Warehouses",
                newName: "Warehouse");

            migrationBuilder.RenameColumn(
                name: "CountEmployees",
                table: "Warehouse",
                newName: "CountEmployers");

            migrationBuilder.RenameIndex(
                name: "IX_Warehouses_StafferId",
                table: "Warehouse",
                newName: "IX_Warehouse_StafferId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Warehouse",
                table: "Warehouse",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouse_staffer_StafferId",
                table: "Warehouse",
                column: "StafferId",
                principalTable: "staffer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_product_Warehouse_WarehouseId",
                table: "product",
                column: "WarehouseId",
                principalTable: "Warehouse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
