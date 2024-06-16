using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarehouseMaster.Data.Migrations
{
    /// <inheritdoc />
    public partial class init8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Avatar",
                table: "person",
                newName: "avatar");

            migrationBuilder.RenameColumn(
                name: "MiddleName",
                table: "person",
                newName: "middle_name");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "person",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "person",
                newName: "first_name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "avatar",
                table: "person",
                newName: "Avatar");

            migrationBuilder.RenameColumn(
                name: "middle_name",
                table: "person",
                newName: "MiddleName");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "person",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "person",
                newName: "FirstName");
        }
    }
}
