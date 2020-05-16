using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Questy.Data.Migrations
{
    public partial class quest12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuestTag",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestID = table.Column<int>(nullable: false),
                    TagID = table.Column<int>(nullable: false),
                    AuditUser = table.Column<string>(nullable: true),
                    LastUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestTag", x => x.ID);
                    table.ForeignKey(
                        name: "FK_QuestTag_Quests_QuestID",
                        column: x => x.QuestID,
                        principalTable: "Quests",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestTag_Tags_TagID",
                        column: x => x.TagID,
                        principalTable: "Tags",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestTag_QuestID",
                table: "QuestTag",
                column: "QuestID");

            migrationBuilder.CreateIndex(
                name: "IX_QuestTag_TagID",
                table: "QuestTag",
                column: "TagID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestTag");
        }
    }
}
