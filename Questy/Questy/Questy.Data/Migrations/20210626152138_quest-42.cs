using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Questy.Data.Migrations
{
    public partial class quest42 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBuilds_Weights_WeightID",
                table: "UserBuilds");

            migrationBuilder.DropTable(
                name: "Weights");

            migrationBuilder.DropIndex(
                name: "IX_UserBuilds_WeightID",
                table: "UserBuilds");

            migrationBuilder.DropColumn(
                name: "WeightID",
                table: "UserBuilds");

            migrationBuilder.RenameColumn(
                name: "isActive",
                table: "Users",
                newName: "IsActive");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Users",
                newName: "isActive");

            migrationBuilder.AddColumn<int>(
                name: "WeightID",
                table: "UserBuilds",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Weights",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuditUser = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrimaryPercentage = table.Column<int>(type: "int", nullable: false),
                    SecondaryPercentage = table.Column<int>(type: "int", nullable: false),
                    TertiaryPercentage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weights", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserBuilds_WeightID",
                table: "UserBuilds",
                column: "WeightID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBuilds_Weights_WeightID",
                table: "UserBuilds",
                column: "WeightID",
                principalTable: "Weights",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
