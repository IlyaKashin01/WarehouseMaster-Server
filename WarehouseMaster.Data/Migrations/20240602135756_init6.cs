using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarehouseMaster.Data.Migrations
{
    /// <inheritdoc />
    public partial class init6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_Warehouses_WarehouseId",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "FK_staffer_Warehouses_warehouse_id",
                table: "staffer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Warehouses",
                table: "Warehouses");

            migrationBuilder.RenameTable(
                name: "Warehouses",
                newName: "warehouse");

            migrationBuilder.RenameColumn(
                name: "Square",
                table: "warehouse",
                newName: "square");

            migrationBuilder.RenameColumn(
                name: "Purpose",
                table: "warehouse",
                newName: "purpose");

            migrationBuilder.RenameColumn(
                name: "Occupancy",
                table: "warehouse",
                newName: "occupancy");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "warehouse",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Capacity",
                table: "warehouse",
                newName: "capacity");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "warehouse",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "warehouse",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "DeleteDate",
                table: "warehouse",
                newName: "delete_date");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "warehouse",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "CountTechnic",
                table: "warehouse",
                newName: "count_technic");

            migrationBuilder.RenameColumn(
                name: "CountEmployees",
                table: "warehouse",
                newName: "count_employees");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "warehouse",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddPrimaryKey(
                name: "PK_warehouse",
                table: "warehouse",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_product_warehouse_WarehouseId",
                table: "product",
                column: "WarehouseId",
                principalTable: "warehouse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_staffer_warehouse_warehouse_id",
                table: "staffer",
                column: "warehouse_id",
                principalTable: "warehouse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_warehouse_WarehouseId",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "FK_staffer_warehouse_warehouse_id",
                table: "staffer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_warehouse",
                table: "warehouse");

            migrationBuilder.RenameTable(
                name: "warehouse",
                newName: "Warehouses");

            migrationBuilder.RenameColumn(
                name: "square",
                table: "Warehouses",
                newName: "Square");

            migrationBuilder.RenameColumn(
                name: "purpose",
                table: "Warehouses",
                newName: "Purpose");

            migrationBuilder.RenameColumn(
                name: "occupancy",
                table: "Warehouses",
                newName: "Occupancy");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Warehouses",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "capacity",
                table: "Warehouses",
                newName: "Capacity");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "Warehouses",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                table: "Warehouses",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "delete_date",
                table: "Warehouses",
                newName: "DeleteDate");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "Warehouses",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "count_technic",
                table: "Warehouses",
                newName: "CountTechnic");

            migrationBuilder.RenameColumn(
                name: "count_employees",
                table: "Warehouses",
                newName: "CountEmployees");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Warehouses",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Warehouses",
                table: "Warehouses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_product_Warehouses_WarehouseId",
                table: "product",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_staffer_Warehouses_warehouse_id",
                table: "staffer",
                column: "warehouse_id",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
