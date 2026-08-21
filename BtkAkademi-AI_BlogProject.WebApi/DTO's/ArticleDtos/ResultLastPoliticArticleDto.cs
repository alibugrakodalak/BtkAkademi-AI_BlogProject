namespace BtkAkademi_AI_BlogProject.WebApi.DTO_s.ArticleDtos
{
	public class ResultLastPoliticArticleDto
	{
		public int ArticleId { get; set; }
		public string Title { get; set; }
		public DateTime CreatedDate { get; set; }
		public string FeaturedCoverImage600x600Url { get; set; }
		public int CategoryId { get; set; }
		public string CategoryName { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string ImageUrl { get; set; }
	}
}
