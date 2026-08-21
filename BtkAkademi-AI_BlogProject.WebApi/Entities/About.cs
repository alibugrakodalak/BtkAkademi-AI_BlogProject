namespace BtkAkademi_AI_BlogProject.WebApi.Entities
{
	public class About
	{
		public int AboutId { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public string ImageUrl { get; set; }
		public int StartWorkingYear { get; set; }
		public int EmployeeCount { get; set; }
	}
}
