using BtkAkademi_AI_BlogProject.WebUI.DTO_s.EmailDtos;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace BtkAkademi_AI_BlogProject.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class EmailController : Controller
	{
		[HttpGet]
		public IActionResult SendEmail()
		{
			return View();
		}

		[HttpPost]
		public IActionResult SendEmail(CreateEmailDto dto)
		{
			MimeMessage mimeMessage = new MimeMessage();

			MailboxAddress mailboxAddressFrom = new MailboxAddress("AI Blog Yönetim Paneli", "alibugrakodalak1@gmail.com");
			mimeMessage.From.Add(mailboxAddressFrom);

			MailboxAddress mailboxAddressTo = new MailboxAddress("User", dto.ReceiverMail);
			mimeMessage.To.Add(mailboxAddressTo);

			var bodyBuilder = new BodyBuilder();
			bodyBuilder.TextBody = dto.MessageDetail;
			mimeMessage.Body = bodyBuilder.ToMessageBody();

			mimeMessage.Subject = dto.Subject;

			SmtpClient client = new SmtpClient();
			client.Connect("smtp.gmail.com", 587, false);
			client.Authenticate("alibugrakodalak1@gmail.com", "mailpassword");
			client.Send(mimeMessage);
			client.Disconnect(true);

			return RedirectToAction("Index", "Email", new { area = "Admin" });
		}

	}
}
