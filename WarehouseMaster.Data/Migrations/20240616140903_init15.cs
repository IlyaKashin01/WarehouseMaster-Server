using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WarehouseMaster.Data.Migrations
{
    /// <inheritdoc />
    public partial class init15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "provider_id",
                table: "product",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "provider",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    full_name = table.Column<string>(type: "text", nullable: false),
                    company = table.Column<string>(type: "text", nullable: false),
                    phone = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_provider", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_product_provider_id",
                table: "product",
                column: "provider_id");

            migrationBuilder.AddForeignKey(
                name: "FK_product_provider_provider_id",
                table: "product",
                column: "provider_id",
                principalTable: "provider",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_provider_provider_id",
                table: "product");

            migrationBuilder.DropTable(
                name: "provider");

            migrationBuilder.DropIndex(
                name: "IX_product_provider_id",
                table: "product");

            migrationBuilder.DropColumn(
                name: "provider_id",
                table: "product");
        }
    }
}
