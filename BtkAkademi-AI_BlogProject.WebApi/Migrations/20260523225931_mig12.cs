using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BtkAkademi_AI_BlogProject.WebApi.Migrations
{
    public partial class mig12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LastArticleImageUrl",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastArticleImageUrl",
                table: "Articles");
        }
    }
}
