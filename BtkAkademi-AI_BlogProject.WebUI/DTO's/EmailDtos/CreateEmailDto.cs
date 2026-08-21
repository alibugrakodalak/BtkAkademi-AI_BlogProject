namespace BtkAkademi_AI_BlogProject.WebUI.DTO_s.EmailDtos
{
	public class CreateEmailDto
	{
		public string NameSurname { get; set; }
		public string ReceiverMail { get; set; }
		public string Subject { get; set; }
		public string MessageDetail { get; set; }
	}
}
