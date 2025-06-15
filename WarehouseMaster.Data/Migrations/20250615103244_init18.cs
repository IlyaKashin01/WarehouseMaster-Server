using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarehouseMaster.Data.Migrations
{
    /// <inheritdoc />
    public partial class init18 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_entrance_product_product_id",
                table: "entrance");

            migrationBuilder.DropIndex(
                name: "IX_entrance_product_id",
                table: "entrance");

            migrationBuilder.DropColumn(
                name: "product_id",
                table: "entrance");

            migrationBuilder.AddColumn<int>(
                name: "entrance_id",
                table: "product",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_product_entrance_id",
                table: "product",
                column: "entrance_id");

            migrationBuilder.AddForeignKey(
                name: "FK_product_entrance_entrance_id",
                table: "product",
                column: "entrance_id",
                principalTable: "entrance",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_entrance_entrance_id",
                table: "product");

            migrationBuilder.DropIndex(
                name: "IX_product_entrance_id",
                table: "product");

            migrationBuilder.DropColumn(
                name: "entrance_id",
                table: "product");

            migrationBuilder.AddColumn<int>(
                name: "product_id",
                table: "entrance",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_entrance_product_id",
                table: "entrance",
                column: "product_id");

            migrationBuilder.AddForeignKey(
                name: "FK_entrance_product_product_id",
                table: "entrance",
                column: "product_id",
                principalTable: "product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
