namespace BtkAkademi_AI_BlogProject.WebApi.DTO_s.ContactDtos
{
	public class UpdateContactDto
	{
		public int ContactId { get; set; }
		public string PhoneNumberFirst { get; set; }
		public string PhoneNumberSecond { get; set; }
		public string FirstEmail { get; set; }
		public string SecondEmail { get; set; }
		public string Address { get; set; }
		public string MapLocation { get; set; }
		public string Description1 { get; set; }
		public string Description2 { get; set; }
	}
}
