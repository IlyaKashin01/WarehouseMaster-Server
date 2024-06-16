using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarehouseMaster.Data.Migrations
{
    /// <inheritdoc />
    public partial class init14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "warehouse_id",
                table: "shipment",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "warehouse_id",
                table: "entrance",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_shipment_warehouse_id",
                table: "shipment",
                column: "warehouse_id");

            migrationBuilder.CreateIndex(
                name: "IX_entrance_warehouse_id",
                table: "entrance",
                column: "warehouse_id");

            migrationBuilder.AddForeignKey(
                name: "FK_entrance_warehouse_warehouse_id",
                table: "entrance",
                column: "warehouse_id",
                principalTable: "warehouse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_shipment_warehouse_warehouse_id",
                table: "shipment",
                column: "warehouse_id",
                principalTable: "warehouse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_entrance_warehouse_warehouse_id",
                table: "entrance");

            migrationBuilder.DropForeignKey(
                name: "FK_shipment_warehouse_warehouse_id",
                table: "shipment");

            migrationBuilder.DropIndex(
                name: "IX_shipment_warehouse_id",
                table: "shipment");

            migrationBuilder.DropIndex(
                name: "IX_entrance_warehouse_id",
                table: "entrance");

            migrationBuilder.DropColumn(
                name: "warehouse_id",
                table: "shipment");

            migrationBuilder.DropColumn(
                name: "warehouse_id",
                table: "entrance");
        }
    }
}
