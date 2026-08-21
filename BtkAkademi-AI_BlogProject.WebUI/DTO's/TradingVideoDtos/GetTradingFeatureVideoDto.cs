namespace BtkAkademi_AI_BlogProject.WebUI.DTO_s.TradingVideoDtos
{
	public class GetTradingFeatureVideoDto
	{
		public int TradingVideoId { get; set; }
		public string Title { get; set; }
		public string ThumbnailImageUrl { get; set; }
		public DateTime CreatedDate { get; set; }
		public string EmbedVideoUrl { get; set; }
		public bool IsFeature { get; set; }
		public string? FeatureImage1200x675Url { get; set; }
		public string UserNameSurname { get; set; }
		public string UserImageUrl { get; set; }
	}
}
