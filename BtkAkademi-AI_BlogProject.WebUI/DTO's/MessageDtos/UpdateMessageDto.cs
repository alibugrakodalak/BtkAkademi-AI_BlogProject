namespace BtkAkademi_AI_BlogProject.WebUI.DTO_s.MessageDtos
{
	public class UpdateMessageDto
	{
		public int MessageId { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Email { get; set; }
		public string Subject { get; set; }
		public string MessageDetail { get; set; }
		public string AIStatus { get; set; }
		public int IsRead { get; set; }
		public DateTime SendDate { get; set; }
	}
}
