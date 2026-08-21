namespace BtkAkademi_AI_BlogProject.WebUI.DTO_s.ArticleDtos
{
	public class ResultLast5ArticleByCategoryDto
	{
		public int ArticleId { get; set; }
		public string CategoryName { get; set; }
		public string Title { get; set; }
		public string FeatureSliderCategoryImage300x370Url { get; set; }
		public DateTime CreatedDate { get; set; }
	}
}
