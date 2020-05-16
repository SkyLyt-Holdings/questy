using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Questy.Data.Migrations
{
    public partial class quest14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBuilds_Archetypes_PrimaryArchetypeID",
                table: "UserBuilds");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBuilds_Archetypes_SecondaryArchetypeID",
                table: "UserBuilds");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBuilds_Archetypes_TertiaryArchetypeID",
                table: "UserBuilds");

            migrationBuilder.DropIndex(
                name: "IX_UserBuilds_PrimaryArchetypeID",
                table: "UserBuilds");

            migrationBuilder.DropIndex(
                name: "IX_UserBuilds_SecondaryArchetypeID",
                table: "UserBuilds");

            migrationBuilder.DropIndex(
                name: "IX_UserBuilds_TertiaryArchetypeID",
                table: "UserBuilds");

            migrationBuilder.DropColumn(
                name: "PrimaryArchetypeID",
                table: "UserBuilds");

            migrationBuilder.DropColumn(
                name: "SecondaryArchetypeID",
                table: "UserBuilds");

            migrationBuilder.DropColumn(
                name: "TertiaryArchetypeID",
                table: "UserBuilds");

            migrationBuilder.AlterColumn<string>(
                name: "AuditUser",
                table: "Weights",
                type: "nvarchar(256)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "UserTypes",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AuditUser",
                table: "UserTypes",
                type: "nvarchar(256)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuditUser",
                table: "UserTypePermission",
                type: "nvarchar(256)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "UserTypePermission",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "nvarchar(256)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(256)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AuditUser",
                table: "Users",
                type: "nvarchar(256)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AuditUser",
                table: "UserBuilds",
                type: "nvarchar(256)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ArchetypeID",
                table: "UserBuilds",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "UserBuilds",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WeightPercentage",
                table: "UserBuilds",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Tags",
                type: "nvarchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AuditUser",
                table: "Tags",
                type: "nvarchar(256)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AuditUser",
                table: "QuestTag",
                type: "nvarchar(256)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Quests",
                type: "nvarchar(500)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AuditUser",
                table: "Quests",
                type: "nvarchar(256)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Quests",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Permissions",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AuditUser",
                table: "Permissions",
                type: "nvarchar(256)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AuditUser",
                table: "ArchetypeTag",
                type: "nvarchar(256)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Archetypes",
                type: "nvarchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AuditUser",
                table: "Archetypes",
                type: "nvarchar(256)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserBuilds_ArchetypeID",
                table: "UserBuilds",
                column: "ArchetypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBuilds_Archetypes_ArchetypeID",
                table: "UserBuilds",
                column: "ArchetypeID",
                principalTable: "Archetypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBuilds_Archetypes_ArchetypeID",
                table: "UserBuilds");

            migrationBuilder.DropIndex(
                name: "IX_UserBuilds_ArchetypeID",
                table: "UserBuilds");

            migrationBuilder.DropColumn(
                name: "AuditUser",
                table: "UserTypePermission");

            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "UserTypePermission");

            migrationBuilder.DropColumn(
                name: "ArchetypeID",
                table: "UserBuilds");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "UserBuilds");

            migrationBuilder.DropColumn(
                name: "WeightPercentage",
                table: "UserBuilds");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Quests");

            migrationBuilder.AlterColumn<string>(
                name: "AuditUser",
                table: "Weights",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "UserTypes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "AuditUser",
                table: "UserTypes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)");

            migrationBuilder.AlterColumn<string>(
                name: "AuditUser",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)");

            migrationBuilder.AlterColumn<string>(
                name: "AuditUser",
                table: "UserBuilds",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)");

            migrationBuilder.AddColumn<int>(
                name: "PrimaryArchetypeID",
                table: "UserBuilds",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SecondaryArchetypeID",
                table: "UserBuilds",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TertiaryArchetypeID",
                table: "UserBuilds",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Tags",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)");

            migrationBuilder.AlterColumn<string>(
                name: "AuditUser",
                table: "Tags",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)");

            migrationBuilder.AlterColumn<string>(
                name: "AuditUser",
                table: "QuestTag",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Quests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)");

            migrationBuilder.AlterColumn<string>(
                name: "AuditUser",
                table: "Quests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Permissions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "AuditUser",
                table: "Permissions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)");

            migrationBuilder.AlterColumn<string>(
                name: "AuditUser",
                table: "ArchetypeTag",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Archetypes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)");

            migrationBuilder.AlterColumn<string>(
                name: "AuditUser",
                table: "Archetypes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)");

            migrationBuilder.CreateIndex(
                name: "IX_UserBuilds_PrimaryArchetypeID",
                table: "UserBuilds",
                column: "PrimaryArchetypeID");

            migrationBuilder.CreateIndex(
                name: "IX_UserBuilds_SecondaryArchetypeID",
                table: "UserBuilds",
                column: "SecondaryArchetypeID");

            migrationBuilder.CreateIndex(
                name: "IX_UserBuilds_TertiaryArchetypeID",
                table: "UserBuilds",
                column: "TertiaryArchetypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBuilds_Archetypes_PrimaryArchetypeID",
                table: "UserBuilds",
                column: "PrimaryArchetypeID",
                principalTable: "Archetypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBuilds_Archetypes_SecondaryArchetypeID",
                table: "UserBuilds",
                column: "SecondaryArchetypeID",
                principalTable: "Archetypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBuilds_Archetypes_TertiaryArchetypeID",
                table: "UserBuilds",
                column: "TertiaryArchetypeID",
                principalTable: "Archetypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
