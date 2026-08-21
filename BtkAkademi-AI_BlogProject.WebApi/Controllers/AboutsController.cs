using AutoMapper;
using BtkAkademi_AI_BlogProject.WebApi.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BtkAkademi_AI_BlogProject.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AboutsController : ControllerBase
	{
		private readonly BlogIAContext _context;
		public AboutsController(BlogIAContext context)
		{
			_context = context;
		}
		[HttpGet]
		public IActionResult AboutInfo()
		{
			var values = _context.Abouts.FirstOrDefault();
			return Ok(values);
		}
	}
}
