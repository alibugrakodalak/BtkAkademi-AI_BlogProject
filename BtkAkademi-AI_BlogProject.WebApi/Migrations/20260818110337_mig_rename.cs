using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BtkAkademi_AI_BlogProject.WebApi.Migrations
{
    public partial class mig_rename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FeatureImageUrl",
                table: "TradingVideos",
                newName: "FeatureImage1200x675Url");

            migrationBuilder.RenameColumn(
                name: "SubFeatureImageUrl",
                table: "Articles",
                newName: "SubFeatureImage500x500Url");

            migrationBuilder.RenameColumn(
                name: "MainImageUrl",
                table: "Articles",
                newName: "MainImage1200x600Url");

            migrationBuilder.RenameColumn(
                name: "LastArticleImageUrl",
                table: "Articles",
                newName: "LastArticleImage1200x800Url");

            migrationBuilder.RenameColumn(
                name: "FeaturedCoverImageUrl",
                table: "Articles",
                newName: "FeaturedCoverImage600x600Url");

            migrationBuilder.RenameColumn(
                name: "FeatureSliderImageUrl",
                table: "Articles",
                newName: "FeatureSliderImage800x800Url");

            migrationBuilder.RenameColumn(
                name: "FeatureSliderCategoryImageUrl",
                table: "Articles",
                newName: "FeatureSliderCategoryImage300x370Url");

            migrationBuilder.RenameColumn(
                name: "FeatureImageUrl",
                table: "Articles",
                newName: "FeatureImage1200x675Url");

            migrationBuilder.RenameColumn(
                name: "CoverImageUrl",
                table: "Articles",
                newName: "CoverImage600x400Url");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FeatureImage1200x675Url",
                table: "TradingVideos",
                newName: "FeatureImageUrl");

            migrationBuilder.RenameColumn(
                name: "SubFeatureImage500x500Url",
                table: "Articles",
                newName: "SubFeatureImageUrl");

            migrationBuilder.RenameColumn(
                name: "MainImage1200x600Url",
                table: "Articles",
                newName: "MainImageUrl");

            migrationBuilder.RenameColumn(
                name: "LastArticleImage1200x800Url",
                table: "Articles",
                newName: "LastArticleImageUrl");

            migrationBuilder.RenameColumn(
                name: "FeaturedCoverImage600x600Url",
                table: "Articles",
                newName: "FeaturedCoverImageUrl");

            migrationBuilder.RenameColumn(
                name: "FeatureSliderImage800x800Url",
                table: "Articles",
                newName: "FeatureSliderImageUrl");

            migrationBuilder.RenameColumn(
                name: "FeatureSliderCategoryImage300x370Url",
                table: "Articles",
                newName: "FeatureSliderCategoryImageUrl");

            migrationBuilder.RenameColumn(
                name: "FeatureImage1200x675Url",
                table: "Articles",
                newName: "FeatureImageUrl");

            migrationBuilder.RenameColumn(
                name: "CoverImage600x400Url",
                table: "Articles",
                newName: "CoverImageUrl");
        }
    }
}
