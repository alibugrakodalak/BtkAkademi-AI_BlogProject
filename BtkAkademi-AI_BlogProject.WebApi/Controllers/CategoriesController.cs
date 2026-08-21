using AutoMapper;
using BtkAkademi_AI_BlogProject.WebApi.Context;
using BtkAkademi_AI_BlogProject.WebApi.DTO_s.CategoryDtos;
using BtkAkademi_AI_BlogProject.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BtkAkademi_AI_BlogProject.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		private readonly BlogIAContext _context;
		private readonly IMapper _mapper;
		public CategoriesController(BlogIAContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult CategoryList()
		{
			var values = _context.Categories.ToList();
			return Ok(values);
		}

		[HttpPost]
		public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
		{
			var value = _mapper.Map<Category>(createCategoryDto);
			_context.Categories.Add(value);
			_context.SaveChanges();
			return Ok("Kategori Ekleme İşlemi Başarılı..!");
		}

		[HttpPut]
		public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
		{
			var value = _mapper.Map<Category>(updateCategoryDto);
			_context.Categories.Update(value);
			_context.SaveChanges();
			return Ok("Güncelleme Başarılı..!");
		}

		[HttpGet("GetCategory")]
		public IActionResult GetCategory(int id)
		{
			var value = _context.Categories.Find(id);
			return Ok(value);
		}

		[HttpDelete]
		public IActionResult RemoveCategory(int id)
		{
			var value = _context.Categories.Find(id);
			_context.Categories.Remove(value);
			_context.SaveChanges();
			return Ok("Silme İşlemi Başarılı..!");
		}
	}
}
