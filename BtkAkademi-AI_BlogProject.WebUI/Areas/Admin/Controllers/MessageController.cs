using BtkAkademi_AI_BlogProject.WebUI.DTO_s.MessageDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BtkAkademi_AI_BlogProject.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class MessageController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public MessageController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> MessageList()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7003/api/Messages");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultMessageDto>>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}
