using BtkAkademi_AI_BlogProject.WebApi.Context;
using BtkAkademi_AI_BlogProject.WebApi.DTO_s.TradingVideoDtos;
using BtkAkademi_AI_BlogProject.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BtkAkademi_AI_BlogProject.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TradingVideosController : ControllerBase
	{
		private readonly BlogIAContext _context;
		public TradingVideosController(BlogIAContext context)
		{
			_context = context;
		}

		[HttpGet]
		public IActionResult TradingVideoList()
		{
			var values = _context.TradingVideos.ToList();
			return Ok(values);
		}

		[HttpGet("GetFeatureTradingVideo")]
		public IActionResult GetFeatureTradingVideo()
		{
			var values = _context.TradingVideos.Where(x => x.IsFeature == true).Include(y => y.AppUser).Select(a => new GetTradingVideoFeatureTrueDto
			{
				CreatedDate			= a.CreatedDate,
				EmbedVideoUrl		= a.EmbedVideoUrl,
				FeatureImage1200x675Url = a.FeatureImage1200x675Url,
				Title				= a.Title,
				IsFeature			= a.IsFeature,
				ThumbnailImageUrl	= a.ThumbnailImageUrl,
				TradingVideoId		= a.TradingVideoId,
				UserNameSurname		= a.AppUser.Name + " " + a.AppUser.Surname,
				UserImageUrl		= a.AppUser.ImageUrl
			}).FirstOrDefault();
			return Ok(values);
		}

		[HttpPost]
		public IActionResult CreateTradingVideo(TradingVideo trading)
		{
			_context.TradingVideos.Add(trading);
			_context.SaveChanges();
			return Ok("Video Ekleme İşlemi Başarılı..!");
		}

		[HttpPut]
		public IActionResult UpdateTradingVideo(TradingVideo trading)
		{
			_context.TradingVideos.Update(trading);
			_context.SaveChanges();
			return Ok("Güncelleme Başarılı..!");
		}

		[HttpGet("GetTradingVideo")]
		public IActionResult GetTradingVideo(int id)
		{
			var value = _context.TradingVideos.Find(id);
			return Ok(value);
		}

		[HttpDelete]
		public IActionResult RemoveTradingVideo(int id)
		{
			var value = _context.TradingVideos.Find(id);
			_context.TradingVideos.Remove(value);
			_context.SaveChanges();
			return Ok("Silme İşlemi Başarılı..!");
		}
	}
}

