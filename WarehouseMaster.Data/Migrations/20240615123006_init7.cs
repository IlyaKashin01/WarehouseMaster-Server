using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarehouseMaster.Data.Migrations
{
    /// <inheritdoc />
    public partial class init7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "person",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "person",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "person",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "person",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "person");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "person");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "person");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "person");
        }
    }
}
