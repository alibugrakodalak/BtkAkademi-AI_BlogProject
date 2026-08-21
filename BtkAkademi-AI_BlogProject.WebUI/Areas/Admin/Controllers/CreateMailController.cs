using BtkAkademi_AI_BlogProject.WebUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace BtkAkademi_AI_BlogProject.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CreateMailController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public CreateMailController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		[HttpGet]
		public IActionResult CreateMailWithAI()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateMailWithAI(EmailModel model)
		{
			var prompt = $@"
							The following message is an email sent by a user.
							
							- Detect the language automatically.
							- Do NOT translate the message.
							- Write a professional and polite email reply.
							- The reply must be written in the SAME language as the original message.
							
							Email Subject:
							{model.MessageSubject}
							
							Email Content:
							{model.MessageDetail}
							";

			var client = _httpClientFactory.CreateClient();
			client.DefaultRequestHeaders.Add("Authorization", "Bearer YOUR_KEY");

			var requestBody = new
			{
				model = "gpt-4o-mini",
				messages = new[]
				{
					new { role = "user", content = prompt }
				}
			};

			var content = new StringContent(
				JsonSerializer.Serialize(requestBody),
				Encoding.UTF8,
				"application/json"
			);

			var response = await client.PostAsync("https://api.openai.com/v1/chat/completions", content);
			var responseString = await response.Content.ReadAsStringAsync();

			using var jsonDoc = JsonDocument.Parse(responseString);
			var aiResponse = jsonDoc
				.RootElement
				.GetProperty("choices")[0]
				.GetProperty("message")
				.GetProperty("content")
				.GetString();

			ViewBag.AIResponse = aiResponse;

			return View();
		}
	}
}