using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BtkAkademi_AI_BlogProject.WebApi.Migrations
{
    public partial class mig15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "TradingVideos",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "TradingVideos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TradingVideos_AppUserId",
                table: "TradingVideos",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TradingVideos_CategoryId",
                table: "TradingVideos",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_TradingVideos_AspNetUsers_AppUserId",
                table: "TradingVideos",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TradingVideos_Categories_CategoryId",
                table: "TradingVideos",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TradingVideos_AspNetUsers_AppUserId",
                table: "TradingVideos");

            migrationBuilder.DropForeignKey(
                name: "FK_TradingVideos_Categories_CategoryId",
                table: "TradingVideos");

            migrationBuilder.DropIndex(
                name: "IX_TradingVideos_AppUserId",
                table: "TradingVideos");

            migrationBuilder.DropIndex(
                name: "IX_TradingVideos_CategoryId",
                table: "TradingVideos");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "TradingVideos");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "TradingVideos");
        }
    }
}
