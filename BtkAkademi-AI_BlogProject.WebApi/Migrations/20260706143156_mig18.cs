using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BtkAkademi_AI_BlogProject.WebApi.Migrations
{
    public partial class mig18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {           

            migrationBuilder.CreateTable(
                name: "SliderCarousels",
                columns: table => new
                {
                    SliderCarouselId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SliderCarousels", x => x.SliderCarouselId);
                });
        }
    }
}
