using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BtkAkademi_AI_BlogProject.WebApi.Migrations
{
    public partial class mig24 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AboutTitle",
                table: "Abouts",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "AboutContent",
                table: "Abouts",
                newName: "ImageUrl");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeCount",
                table: "Abouts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StartWorkingYear",
                table: "Abouts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "EmployeeCount",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "StartWorkingYear",
                table: "Abouts");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Abouts",
                newName: "AboutTitle");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Abouts",
                newName: "AboutContent");
        }
    }
}
