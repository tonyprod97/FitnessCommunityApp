using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessCommunity.Migrations
{
    public partial class AddedWeightLogsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeightLogs",
                columns: table => new
                {
                    WeightLogId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicationUserId = table.Column<int>(nullable: false),
                    ApplicationUserId1 = table.Column<string>(nullable: true),
                    LogDate = table.Column<DateTime>(nullable: false),
                    WeightValue = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeightLogs", x => x.WeightLogId);
                    table.ForeignKey(
                        name: "FK_WeightLogs_AspNetUsers_ApplicationUserId1",
                        column: x => x.ApplicationUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WeightLogs_ApplicationUserId1",
                table: "WeightLogs",
                column: "ApplicationUserId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeightLogs");
        }
    }
}
