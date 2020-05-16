using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Questy.Data.Migrations
{
    public partial class quest13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserTypePermissions");

            migrationBuilder.AddColumn<string>(
                name: "AuditUser",
                table: "ArchetypeTag",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "ArchetypeTag",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "UserTypePermission",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserTypeID = table.Column<int>(nullable: false),
                    PermissionID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypePermission", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserTypePermission_Permissions_PermissionID",
                        column: x => x.PermissionID,
                        principalTable: "Permissions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTypePermission_UserTypes_UserTypeID",
                        column: x => x.UserTypeID,
                        principalTable: "UserTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserTypePermission_PermissionID",
                table: "UserTypePermission",
                column: "PermissionID");

            migrationBuilder.CreateIndex(
                name: "IX_UserTypePermission_UserTypeID",
                table: "UserTypePermission",
                column: "UserTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserTypePermission");

            migrationBuilder.DropColumn(
                name: "AuditUser",
                table: "ArchetypeTag");

            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "ArchetypeTag");

            migrationBuilder.CreateTable(
                name: "UserTypePermissions",
                columns: table => new
                {
                    UserTypeID = table.Column<int>(type: "int", nullable: false),
                    PermissionID = table.Column<int>(type: "int", nullable: false)
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
    }
}
