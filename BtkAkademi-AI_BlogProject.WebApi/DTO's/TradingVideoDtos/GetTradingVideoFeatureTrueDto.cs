using BtkAkademi_AI_BlogProject.WebApi.Entities;

namespace BtkAkademi_AI_BlogProject.WebApi.DTO_s.TradingVideoDtos
{
	public class GetTradingVideoFeatureTrueDto
	{
		public int TradingVideoId { get; set; }
		public string Title { get; set; }
		public string ThumbnailImageUrl { get; set; }
		public DateTime CreatedDate { get; set; }
		public string EmbedVideoUrl { get; set; }
		public bool IsFeature { get; set; }
		public string FeatureImage1200x675Url { get; set; }
		public int CategoryId { get; set; }
		public string AppUserId { get; set; }
		public string UserNameSurname { get; set; }
		public string UserImageUrl { get; set; }
	}
}
