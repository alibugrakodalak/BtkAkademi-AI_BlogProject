using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BtkAkademi_AI_BlogProject.WebApi.Migrations
{
    public partial class mig11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsLastArticle",
                table: "Articles",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLastArticle",
                table: "Articles");
        }
    }
}
