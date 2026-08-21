using BtkAkademi_AI_BlogProject.WebApi.DTO_s.LoginDtos;
using BtkAkademi_AI_BlogProject.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BtkAkademi_AI_BlogProject.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LoginsController : ControllerBase
	{
		private readonly SignInManager<AppUser> _signInManager;

		public LoginsController(SignInManager<AppUser> signInManager)
		{
			_signInManager = signInManager;
		}

		[HttpPost]
		public async Task<IActionResult> UserLogin(UserLoginDto dto)
		{
			var result = await _signInManager.PasswordSignInAsync(dto.Username, dto.Password, false, false);
			if (result.Succeeded)
			{
				return Ok("Giriş Başarılo");
			}
			else
			{
				return Ok("Hatalı Kullanıcı Adı Veya Şifre");
			}
		}
	}
}
