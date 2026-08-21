namespace BtkAkademi_AI_BlogProject.WebApi.Entities
{
	public class Category
	{
		public int CategoryId { get; set; }
		public string CategoryName { get; set; }
		public List<Article> Articles { get; set; }
		public List<TradingVideo> TradingVideos { get; set; }
		public string? CategoryImageUrl{ get; set; }
	}
}
