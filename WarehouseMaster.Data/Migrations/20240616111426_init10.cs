using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarehouseMaster.Data.Migrations
{
    /// <inheritdoc />
    public partial class init10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "reset_pass_code",
                table: "person",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "reset_pass_code",
                table: "person",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
