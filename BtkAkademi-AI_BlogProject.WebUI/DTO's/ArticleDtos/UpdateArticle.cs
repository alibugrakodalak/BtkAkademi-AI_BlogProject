namespace BtkAkademi_AI_BlogProject.WebUI.DTO_s.ArticleDtos
{
	public class UpdateArticle
	{
		public int ArticleId { get; set; }
		public string Title { get; set; }
		public string CoverImage600x400Url { get; set; }
		public string MainImage1200x600Url { get; set; }
		public string Content { get; set; }
		public DateTime CreatedDate { get; set; }
		public int? CategoryId { get; set; }
		public string CategoryName { get; set; }
		public bool IsFeatureSlider { get; set; }
		public string FeatureSliderImage800x800Url { get; set; }
		public string FeatureImage1200x675Url { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string ImageUrl { get; set; }
	}
}
