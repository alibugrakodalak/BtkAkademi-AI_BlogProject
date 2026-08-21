namespace BtkAkademi_AI_BlogProject.WebApi.Entities
{
	public class TradingVideo
	{
		public int TradingVideoId { get; set; }
		public string Title { get; set; }
		public string ThumbnailImageUrl { get; set; }
		public DateTime CreatedDate { get; set; }
		public string EmbedVideoUrl { get; set; }
		public bool IsFeature { get; set; }
		public string? FeatureImage1200x675Url { get; set; }
		public int? CategoryId { get; set; }
		public Category Category { get; set; }
		public string? AppUserId { get; set; }
		public AppUser AppUser { get; set; }
	}
}
