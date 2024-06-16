using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WarehouseMaster.Data.Migrations
{
    /// <inheritdoc />
    public partial class init13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "entrance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    product_id = table.Column<int>(type: "integer", nullable: false),
                    entrance_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    staffer_id = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<bool>(type: "boolean", nullable: false),
                    accept_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entrance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_entrance_product_product_id",
                        column: x => x.product_id,
                        principalTable: "product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_entrance_staffer_staffer_id",
                        column: x => x.staffer_id,
                        principalTable: "staffer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "shipment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    product_id = table.Column<int>(type: "integer", nullable: false),
                    shipment_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    staffer_id = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<bool>(type: "boolean", nullable: false),
                    accept_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shipment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_shipment_product_product_id",
                        column: x => x.product_id,
                        principalTable: "product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_shipment_staffer_staffer_id",
                        column: x => x.staffer_id,
                        principalTable: "staffer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_entrance_product_id",
                table: "entrance",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_entrance_staffer_id",
                table: "entrance",
                column: "staffer_id");

            migrationBuilder.CreateIndex(
                name: "IX_shipment_product_id",
                table: "shipment",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_shipment_staffer_id",
                table: "shipment",
                column: "staffer_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "entrance");

            migrationBuilder.DropTable(
                name: "shipment");
        }
    }
}
