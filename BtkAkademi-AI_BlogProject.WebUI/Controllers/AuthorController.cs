using BtkAkademi_AI_BlogProject.WebUI.DTO_s.UserDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BtkAkademi_AI_BlogProject.WebUI.Controllers
{
	public class AuthorController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public AuthorController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> AuthorList()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7003/api/Users");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultUserDto>>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}
