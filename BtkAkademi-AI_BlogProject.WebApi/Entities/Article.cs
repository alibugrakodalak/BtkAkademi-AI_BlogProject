namespace BtkAkademi_AI_BlogProject.WebApi.Entities
{
	public class Article
	{
		public int ArticleId { get; set; }
		public string Title { get; set; }
		public string CoverImage600x400Url { get; set; }
		public string MainImage1200x600Url { get; set; }
		public string Content { get; set; }
		public DateTime CreatedDate { get; set; }
		public int? CategoryId { get; set; }
		public Category Category { get; set; }
		public string? AppUserId { get; set; }
		public AppUser AppUser { get; set; }
		public bool IsFeatureSlider { get; set; }
		public bool IsTrendingStories { get; set; }
		public bool IsLastArticle { get; set; }
		public string? FeatureSliderImage800x800Url { get; set; }
		public string? FeatureImage1200x675Url { get; set; }
		public string? FeatureSliderCategoryImage300x370Url { get; set; }
		public string? LastArticleImage1200x800Url { get; set; }
		public string? Image300x300Url { get; set; }
		public List<Comment> Comments { get; set; }
		public string? FeaturedCoverImage600x600Url { get; set; }
		public bool FeaturedCoverImageUrlStatus { get; set; }
		public string? SubFeatureImage500x500Url { get; set; }
		public bool SubFeatureStatus { get; set; }
		public string? DefaultSubSliderImage600x730Url { get; set; }
	}
}
