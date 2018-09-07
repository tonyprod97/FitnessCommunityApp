using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessCommunity.Migrations
{
    public partial class AddPublicInfoToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PublicInfo",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublicInfo",
                table: "AspNetUsers");
        }
    }
}
