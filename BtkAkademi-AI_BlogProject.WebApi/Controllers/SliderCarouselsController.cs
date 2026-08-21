using AutoMapper;
using BtkAkademi_AI_BlogProject.WebApi.Context;
using BtkAkademi_AI_BlogProject.WebApi.DTO_s.SliderCarouselDtos;
using BtkAkademi_AI_BlogProject.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BtkAkademi_AI_BlogProject.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SliderCarouselsController : ControllerBase
	{
		private readonly BlogIAContext _context;
		private readonly IMapper _mapper;
		public SliderCarouselsController(BlogIAContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult SliderCarouselList()
		{
			var values = _context.SliderCarousels.ToList();
			return Ok(values);
		}

		[HttpPost]
		public IActionResult CreateSliderCarousel(CreateSliderCarouselDto createSliderCarouselDto)
		{
			var value = _mapper.Map<SliderCarousel>(createSliderCarouselDto);
			_context.SliderCarousels.Add(value);
			_context.SaveChanges();
			return Ok("Ekleme İşlemi Başarılı..!");
		}

		[HttpPut]
		public IActionResult UpdateSliderCarousel(UpdateSliderCarouselDto updateSliderCarouselDto)
		{
			var value = _mapper.Map<SliderCarousel>(updateSliderCarouselDto);
			_context.SliderCarousels.Update(value);
			_context.SaveChanges();
			return Ok("Güncelleme Başarılı..!");
		}

		[HttpGet("GetSliderCarousel")]
		public IActionResult GetSliderCarousel(int id)
		{
			var value = _context.SliderCarousels.Find(id);
			return Ok(value);
		}

		[HttpDelete]
		public IActionResult RemoveSliderCarousel(int id)
		{
			var value = _context.SliderCarousels.Find(id);
			_context.SliderCarousels.Remove(value);
			_context.SaveChanges();
			return Ok("Silme İşlemi Başarılı..!");
		}
	}
}
