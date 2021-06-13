using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Questy.Data.Migrations
{
    public partial class quest7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Archetypes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    AuditUser = table.Column<string>(nullable: true),
                    LastUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Archetypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    AuditUser = table.Column<string>(nullable: true),
                    LastUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Weights",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrimaryPercentage = table.Column<int>(nullable: false),
                    SecondaryPercentage = table.Column<int>(nullable: false),
                    TertiaryPercentage = table.Column<int>(nullable: false),
                    AuditUser = table.Column<string>(nullable: true),
                    LastUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weights", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserBuilds",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrimaryArchetypeID = table.Column<int>(nullable: true),
                    SecondaryArchetypeID = table.Column<int>(nullable: true),
                    TertiaryArchetypeID = table.Column<int>(nullable: true),
                    WeightID = table.Column<int>(nullable: true),
                    AuditUser = table.Column<string>(nullable: true),
                    LastUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBuilds", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserBuilds_Archetypes_PrimaryArchetypeID",
                        column: x => x.PrimaryArchetypeID,
                        principalTable: "Archetypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserBuilds_Archetypes_SecondaryArchetypeID",
                        column: x => x.SecondaryArchetypeID,
                        principalTable: "Archetypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserBuilds_Archetypes_TertiaryArchetypeID",
                        column: x => x.TertiaryArchetypeID,
                        principalTable: "Archetypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserBuilds_Weights_WeightID",
                        column: x => x.WeightID,
                        principalTable: "Weights",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_UserBuilds_WeightID",
                table: "UserBuilds",
                column: "WeightID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "UserBuilds");

            migrationBuilder.DropTable(
                name: "Archetypes");

            migrationBuilder.DropTable(
                name: "Weights");
        }
    }
}
