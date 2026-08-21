namespace BtkAkademi_AI_BlogProject.WebUI.DTO_s.TradingVideoDtos
{
	public class ResultTradingVideoDto
	{
		public int TradingVideoId { get; set; }
		public string Title { get; set; }
		public string ThumbnailImageUrl { get; set; }
		public DateTime CreatedDate { get; set; }
		public string EmbedVideoUrl { get; set; }
		public bool IsFeature { get; set; }
		public string? FeatureImage1200x675Url { get; set; }
	}
}
