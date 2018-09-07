using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessCommunity.Migrations
{
    public partial class AddedMeasureTypeToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MeasureType",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MeasureType",
                table: "AspNetUsers");
        }
    }
}
