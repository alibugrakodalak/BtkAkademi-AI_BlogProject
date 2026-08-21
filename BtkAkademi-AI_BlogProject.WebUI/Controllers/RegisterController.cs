using BtkAkademi_AI_BlogProject.WebUI.DTO_s.RegisterDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace BtkAkademi_AI_BlogProject.WebUI.Controllers
{
	public class RegisterController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public RegisterController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		[HttpGet]
		public IActionResult UserRegister()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> UserRegister(UserRegisterDto userRegisterDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(userRegisterDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var result = await client.PostAsync("", stringContent);
			if (result.IsSuccessStatusCode)
			{
				return RedirectToAction("UserLogin", "Login");				
			}
			else
			{
				return View();
			}
			
		}
	}
}
