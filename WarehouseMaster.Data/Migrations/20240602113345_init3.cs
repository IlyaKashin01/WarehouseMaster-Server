using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WarehouseMaster.Data.Migrations
{
    /// <inheritdoc />
    public partial class init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "access_level",
                table: "staffer");

            migrationBuilder.DropColumn(
                name: "account_id",
                table: "staffer");

            migrationBuilder.RenameColumn(
                name: "work_experience",
                table: "staffer",
                newName: "person_id");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "staffer",
                newName: "added_date");

            migrationBuilder.AddColumn<DateTime>(
                name: "birthday",
                table: "staffer",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "first_name",
                table: "staffer",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "last_name",
                table: "staffer",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "middle_name",
                table: "staffer",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "WarehouseId",
                table: "product",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Warehouse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Purpose = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Square = table.Column<int>(type: "integer", nullable: false),
                    CountEmployers = table.Column<int>(type: "integer", nullable: false),
                    CountTechnic = table.Column<int>(type: "integer", nullable: false),
                    Capacity = table.Column<int>(type: "integer", nullable: false),
                    Occupancy = table.Column<int>(type: "integer", nullable: false),
                    StafferId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Warehouse_staffer_StafferId",
                        column: x => x.StafferId,
                        principalTable: "staffer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    login = table.Column<string>(type: "text", nullable: false),
                    password_hash = table.Column<string>(type: "text", nullable: false),
                    role = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    registration_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "group_chat_room",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    creator_id = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_group_chat_room", x => x.Id);
                    table.ForeignKey(
                        name: "FK_group_chat_room_person_creator_id",
                        column: x => x.creator_id,
                        principalTable: "person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "personal_message",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    recipient_id = table.Column<int>(type: "integer", nullable: false),
                    sender_id = table.Column<int>(type: "integer", nullable: false),
                    content = table.Column<string>(type: "text", nullable: false),
                    sent_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_check = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personal_message", x => x.Id);
                    table.ForeignKey(
                        name: "FK_personal_message_person_recipient_id",
                        column: x => x.recipient_id,
                        principalTable: "person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "group_member",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    group_id = table.Column<int>(type: "integer", nullable: false),
                    member_id = table.Column<int>(type: "integer", nullable: false),
                    added_by_person = table.Column<int>(type: "integer", nullable: false),
                    added_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    is_leaved = table.Column<bool>(type: "boolean", nullable: false),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_group_member", x => x.Id);
                    table.ForeignKey(
                        name: "FK_group_member_group_chat_room_group_id",
                        column: x => x.group_id,
                        principalTable: "group_chat_room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_group_member_person_member_id",
                        column: x => x.member_id,
                        principalTable: "person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "group_message",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    group_id = table.Column<int>(type: "integer", nullable: false),
                    sender_id = table.Column<int>(type: "integer", nullable: false),
                    content = table.Column<string>(type: "text", nullable: false),
                    sent_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_check = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_group_message", x => x.Id);
                    table.ForeignKey(
                        name: "FK_group_message_group_chat_room_group_id",
                        column: x => x.group_id,
                        principalTable: "group_chat_room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_staffer_person_id",
                table: "staffer",
                column: "person_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_WarehouseId",
                table: "product",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouse_StafferId",
                table: "Warehouse",
                column: "StafferId");

            migrationBuilder.CreateIndex(
                name: "IX_group_chat_room_creator_id",
                table: "group_chat_room",
                column: "creator_id");

            migrationBuilder.CreateIndex(
                name: "IX_group_member_group_id",
                table: "group_member",
                column: "group_id");

            migrationBuilder.CreateIndex(
                name: "IX_group_member_member_id",
                table: "group_member",
                column: "member_id");

            migrationBuilder.CreateIndex(
                name: "IX_group_message_group_id",
                table: "group_message",
                column: "group_id");

            migrationBuilder.CreateIndex(
                name: "IX_personal_message_recipient_id",
                table: "personal_message",
                column: "recipient_id");

            migrationBuilder.AddForeignKey(
                name: "FK_product_Warehouse_WarehouseId",
                table: "product",
                column: "WarehouseId",
                principalTable: "Warehouse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_staffer_person_person_id",
                table: "staffer",
                column: "person_id",
                principalTable: "person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_Warehouse_WarehouseId",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "FK_staffer_person_person_id",
                table: "staffer");

            migrationBuilder.DropTable(
                name: "Warehouse");

            migrationBuilder.DropTable(
                name: "group_member");

            migrationBuilder.DropTable(
                name: "group_message");

            migrationBuilder.DropTable(
                name: "personal_message");

            migrationBuilder.DropTable(
                name: "group_chat_room");

            migrationBuilder.DropTable(
                name: "person");

            migrationBuilder.DropIndex(
                name: "IX_staffer_person_id",
                table: "staffer");

            migrationBuilder.DropIndex(
                name: "IX_product_WarehouseId",
                table: "product");

            migrationBuilder.DropColumn(
                name: "birthday",
                table: "staffer");

            migrationBuilder.DropColumn(
                name: "first_name",
                table: "staffer");

            migrationBuilder.DropColumn(
                name: "last_name",
                table: "staffer");

            migrationBuilder.DropColumn(
                name: "middle_name",
                table: "staffer");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                table: "product");

            migrationBuilder.RenameColumn(
                name: "person_id",
                table: "staffer",
                newName: "work_experience");

            migrationBuilder.RenameColumn(
                name: "added_date",
                table: "staffer",
                newName: "created_date");

            migrationBuilder.AddColumn<int>(
                name: "access_level",
                table: "staffer",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "account_id",
                table: "staffer",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
