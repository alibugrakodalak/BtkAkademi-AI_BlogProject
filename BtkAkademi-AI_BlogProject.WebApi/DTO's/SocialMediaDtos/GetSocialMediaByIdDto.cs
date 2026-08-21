namespace BtkAkademi_AI_BlogProject.WebApi.DTO_s.SocialMediaDtos
{
	public class GetSocialMediaByIdDto
	{
		public int SocialMediaId { get; set; }
		public string ImageUrl400x300 { get; set; }
		public string IconUrl { get; set; }
		public string SocialMediaLink { get; set; }
	}
}
