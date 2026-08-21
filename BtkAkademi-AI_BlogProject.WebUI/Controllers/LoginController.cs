using BtkAkademi_AI_BlogProject.WebUI.DTO_s.LoginDtos;
using BtkAkademi_AI_BlogProject.WebUI.DTO_s.RegisterDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace BtkAkademi_AI_BlogProject.WebUI.Controllers
{
	public class LoginController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public LoginController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		[HttpGet]
		public IActionResult UserLogin()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> UserLogin(UserLoginDto dto)
		{
			return View();
		}
	}
}
