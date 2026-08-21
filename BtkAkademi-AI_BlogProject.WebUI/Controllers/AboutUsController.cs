using BtkAkademi_AI_BlogProject.WebUI.DTO_s.AboutDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BtkAkademi_AI_BlogProject.WebUI.Controllers
{
	public class AboutUsController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public AboutUsController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7003/api/Abouts");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<ResultAboutDto>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}
