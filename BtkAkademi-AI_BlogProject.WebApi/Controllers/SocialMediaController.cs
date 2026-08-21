using BtkAkademi_AI_BlogProject.WebApi.Context;
using BtkAkademi_AI_BlogProject.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BtkAkademi_AI_BlogProject.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SocialMediaController : ControllerBase
	{
		private readonly BlogIAContext _context;

		public SocialMediaController(BlogIAContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<IActionResult> SocialMediaList()
		{
			var values = _context.SocialMedias.ToList();
			return Ok(values);
		}

		[HttpPost]
		public async Task<IActionResult> CreateSocialMedia(SocialMedia socialMedia)
		{
			_context.SocialMedias.Add(socialMedia);
			_context.SaveChanges();
			return Ok("Yeni Sosyal Medya Bilgisi Eklendi");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateSocialMedia(SocialMedia socialMedia)
		{
			_context.SocialMedias.Update(socialMedia);
			_context.SaveChanges();
			return Ok("Sosyal Medya Bilgisi Güncellendi");
		}

		[HttpDelete]
		public async Task<IActionResult> RemoveSocialMedia(int id)
		{
			var value = _context.SocialMedias.Find(id);
			_context.SocialMedias.Remove(value);
			_context.SaveChanges();
			return Ok("Silme Başarılı");
		}

		[HttpGet("GetSocialMedia")]
		public async Task<IActionResult> GetSocialMedia(int id)
		{
			var value = _context.SocialMedias.Find(id);
			return Ok(value);
		}
	}
}
