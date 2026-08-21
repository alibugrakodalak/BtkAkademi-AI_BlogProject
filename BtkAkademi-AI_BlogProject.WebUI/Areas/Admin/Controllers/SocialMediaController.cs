using BtkAkademi_AI_BlogProject.WebUI.DTO_s.SocialMediaDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace BtkAkademi_AI_BlogProject.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class SocialMediaController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public SocialMediaController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> SocialMediaList()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7003/api/SocialMedia");

			var values = new List<ResultSocialMediaDto>();

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				values = JsonConvert.DeserializeObject<List<ResultSocialMediaDto>>(jsonData)
						 ?? new List<ResultSocialMediaDto>();
			}

			return View(values); 
		}

		[HttpGet]
		public async Task<IActionResult> CreateSocialMedia()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaDto dto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(dto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7003/api/SocialMedia", stringContent);
			return RedirectToAction("SocialMediaList", "SocialMedia", new { area = "Admin" });
		}

		[HttpGet]
		public async Task<IActionResult> UpdateSocialMedia(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7003/api/SocialMedia/GetSocialMedia?id=" + id);
			if(responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<GetSocialMediaByIdDto>(jsonData);
				return View(values);
			}
			return RedirectToAction("SocialMediaList", "SocialMedia", new { area = "Admin" });
		}

		[HttpPost]
		public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaDto dto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(dto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			await client.PutAsync("https://localhost:7003/api/SocialMedia/", stringContent);
			return RedirectToAction("SocialMediaList", "SocialMedia", new { area = "Admin" });
		}
	}
}
