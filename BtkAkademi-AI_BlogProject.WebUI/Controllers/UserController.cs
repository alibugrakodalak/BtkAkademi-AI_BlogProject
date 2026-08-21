using BtkAkademi_AI_BlogProject.WebUI.DTO_s.UserDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace BtkAkademi_AI_BlogProject.WebUI.Controllers
{
	public class UserController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public UserController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> UserList()
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
