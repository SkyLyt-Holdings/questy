using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Questy.Data.Migrations
{
    public partial class permissions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "UserTypes");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "Users");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "UserTypes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    isActive = table.Column<bool>(nullable: false),
                    AuditUser = table.Column<string>(nullable: true),
                    LastUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserTypePermissions",
                columns: table => new
                {
                    UserTypeID = table.Column<int>(nullable: false),
                    PermissionID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypePermissions", x => new { x.UserTypeID, x.PermissionID });
                    table.ForeignKey(
                        name: "FK_UserTypePermissions_Permissions_PermissionID",
                        column: x => x.PermissionID,
                        principalTable: "Permissions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTypePermissions_UserTypes_UserTypeID",
                        column: x => x.UserTypeID,
                        principalTable: "UserTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserTypePermissions_PermissionID",
                table: "UserTypePermissions",
                column: "PermissionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserTypePermissions");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "UserTypes");

            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "Users");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "UserTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
