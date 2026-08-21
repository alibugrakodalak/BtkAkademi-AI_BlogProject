using AutoMapper;
using BtkAkademi_AI_BlogProject.WebApi.Context;
using BtkAkademi_AI_BlogProject.WebApi.DTO_s.ArticleDtos;
using BtkAkademi_AI_BlogProject.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BtkAkademi_AI_BlogProject.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ArticlesController : ControllerBase
	{
		private readonly BlogIAContext _context;
		private readonly IMapper _mapper;
		public ArticlesController(BlogIAContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> ArticleList()
		{
			var values = _context.Articles.Include(x => x.Category).Include(y => y.AppUser).ToList();
			var dto = _mapper.Map<List<ResultArticleWithCategoryDto>>(values);
			return Ok(dto);
		}

		[HttpPost]
		public async Task<IActionResult> CreateArticle(CreateArticleDto dto)
		{
			dto.CreatedDate = DateTime.Now;
			var values = _mapper.Map<Article>(dto);
			_context.Articles.Add(values);
			_context.SaveChanges();
			return Ok("Makale Başarıyla Oluşturuldu...!");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateArticle(UpdateArticleDto dto)
		{
			var values = _mapper.Map<Article>(dto);
			_context.Articles.Update(values);
			_context.SaveChanges();
			return Ok("Makale Güncellendi...!");
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteArticle(int id)
		{
			var values = _context.Articles.Find(id);
			_context.Articles.Remove(values);
			_context.SaveChanges();
			return Ok("Makale Silindi...!");
		}

		[HttpGet("GetArticle")]
		public async Task<IActionResult> GetArticle(int id)
		{
			var value = _context.Articles.Find(id);
			return Ok(_mapper.Map<GetArticleByIdDto>(value));
		}

		[HttpGet("GetArticlesFeatureSliderByTrue")]
		public IActionResult GetArticlesFeatureSliderByTrue()
		{
			var values = _context.Articles.Where(y => y.IsFeatureSlider == true).Include(x => x.Category).Include(y => y.AppUser).ToList();
			return Ok(_mapper.Map<List<ResultArticleWithCategoryDto>>(values));
		}

		[HttpGet("ChangeIsFeatureSliderFromTrueToFalse")]
		public IActionResult ChangeIsFeatureSliderFromTrueToFalse(int id)
		{
			var value = _context.Articles.Find(id);
			value.IsFeatureSlider = false;
			_context.SaveChanges();
			return Ok("Değişiklikler Kaydedildi!");
		}

		[HttpGet("ChangeIsFeatureSliderFromFalseToTrue")]
		public IActionResult ChangeIsFeatureSliderFromFalseToTrue(int id)
		{
			var value = _context.Articles.Find(id);
			value.IsFeatureSlider = true;
			_context.SaveChanges();
			return Ok("Değişiklikler Kaydedildi!");
		}

		[HttpGet("GetLastTechnologyArticle")]
		public IActionResult GetLastTechnologyArticle()
		{
			var CategoryId = _context.Categories.Where(x => x.CategoryName == "Teknoloji").Select(y => y.CategoryId).FirstOrDefault();

			var article = _context.Articles
				.Where(x => x.CategoryId == CategoryId)
				.Include(x => x.AppUser)
				.OrderByDescending(y => y.ArticleId)
				.FirstOrDefault();

			var values = _mapper.Map<ResultLastTechnologyArticleDto>(article);

			return Ok(values);
		}

		[HttpGet("GetLastPoliticArticle")]
		public IActionResult GetLastPoliticArticle()
		{
			var CategoryId = _context.Categories.Where(x => x.CategoryName == "Politika").Select(y => y.CategoryId).FirstOrDefault();

			var article = _context.Articles
				.Where(y => y.CategoryId == CategoryId)
				.Include(x => x.AppUser)
				.OrderByDescending(y => y.ArticleId)
				.FirstOrDefault();

			var values = _mapper.Map<ResultLastPoliticArticleDto>(article);

			return Ok(values);
		}

		[HttpGet("GetLastTravelArticle")]
		public IActionResult GetLastTravelArticle()
		{
			var CategoryId = _context.Categories.Where(x => x.CategoryName == "Seyahat").Select(y => y.CategoryId).FirstOrDefault();

			var article = _context.Articles
				.Where(y => y.CategoryId == CategoryId)
				.Include(x => x.AppUser)
				.OrderByDescending(y => y.ArticleId)
				.FirstOrDefault();

			var values = _mapper.Map<ResultLastTravelArticleDto>(article);

			return Ok(values);
		}

		[HttpGet("GetLast5ArticleByCategory")]
		public IActionResult GetLast5ArticleByCategory()
		{
			var list = _context.Articles.Include(x => x.Category).OrderByDescending(y => y.CreatedDate)
				.Select(z => new ResultLast5ArticleByCategoryDto
				{
					ArticleId = z.ArticleId,
					CategoryName = z.Category.CategoryName,
					Title = z.Title,
					CreatedDate = z.CreatedDate,
					FeatureSliderCategoryImage300x370Url = z.FeatureSliderCategoryImage300x370Url
				}).ToList();

			var result = list
				.GroupBy(x => x.CategoryName)
				.Select(g => g.First())
				.OrderByDescending(y => y.CreatedDate)
				.Take(5)
				.ToList();

			return Ok(result);
		}

		[HttpGet("GetTrendingStoriesArticles")]
		public IActionResult GetTrendingStoriesArticles()
		{
			var values = _context.Articles.Where(x => x.IsTrendingStories == true).Include(y => y.Category).Include(z => z.AppUser).Select(a => new ResultTrendingStoriesArticleDto
			{
				ArticleId = a.ArticleId,
				CategoryId = a.CategoryId,
				Title = a.Title,
				CreatedDate = a.CreatedDate,
				CategoryName = a.Category.CategoryName,
				Content = a.Content,
				CoverImage600x400Url = a.CoverImage600x400Url,
				FeatureImage1200x675Url = a.FeatureImage1200x675Url,
				FeatureSliderCategoryImage300x370Url = a.FeatureSliderCategoryImage300x370Url,
				IsTrendingStories = a.IsTrendingStories,
				MainImage1200x600Url = a.MainImage1200x600Url,
				Name = a.AppUser.Name,
				Surname = a.AppUser.Surname,
				FeaturedCoverImage600x600Url = a.FeaturedCoverImage600x600Url,
				FeaturedCoverImageUrlStatus = a.FeaturedCoverImageUrlStatus

			}).ToList();
			return Ok(values);
		}

		[HttpGet("GetLastArticle")]
		public IActionResult GetLastArticle()
		{
			var values = _context.Articles.Where(x => x.IsLastArticle == true).Include(y => y.Category).Include(z => z.AppUser).Select(a => new ResultLastArticleDto
			{
				ArticleId = a.ArticleId,
				CategoryId = a.CategoryId,
				Title = a.Title,
				CreatedDate = a.CreatedDate,
				CategoryName = a.Category.CategoryName,
				Content = a.Content,
				CoverImage600x400Url = a.CoverImage600x400Url,
				FeatureImage1200x675Url = a.FeatureImage1200x675Url,
				FeatureSliderCategoryImage300x370Url = a.FeatureSliderCategoryImage300x370Url,
				IsTrendingStories = a.IsTrendingStories,
				MainImage1200x600Url = a.MainImage1200x600Url,
				Name = a.AppUser.Name,
				Surname = a.AppUser.Surname,
				IsLastArticle = a.IsLastArticle,
				LastArticleImage1200x800Url = a.LastArticleImage1200x800Url,
			}).FirstOrDefault();
			return Ok(values);
		}

		[HttpGet("GetLast4ArticlesWithCategory")]
		public IActionResult GetLast4ArticlesWithCategory()
		{
			var values = _context.Articles.Include(x => x.Category).Include(a=>a.AppUser).OrderByDescending(y => y.ArticleId).Take(4).Select(z => new ResultLast4ArticleWithCategoryDto
			{
				ArticleId = z.ArticleId,
				CategoryName = z.Category.CategoryName,
				Image300x300Url = z.Image300x300Url,
				Title = z.Title,
				Name = z.AppUser.Name,
				Surname = z.AppUser.Surname
			}).ToList();

			return Ok(values);
		}

		[HttpGet("GetArticlesSubFeaturePostsStatusByTrue")]
		public IActionResult GetArticlesSubFeaturePostsStatusByTrue()
		{
			var values = _context.Articles.Where(x => x.SubFeatureStatus == true).Include(y => y.Category).Include(z => z.AppUser).Select(a => new ResultArticlesSubFeaturePostsStatusByTrueDto
			{
				ArticleId = a.ArticleId,
				CategoryId = a.CategoryId,
				Title = a.Title,
				CreatedDate = a.CreatedDate,
				CategoryName = a.Category.CategoryName,
				Content = a.Content,
				CoverImage600x400Url = a.CoverImage600x400Url,
				FeatureImage1200x675Url = a.FeatureImage1200x675Url,
				FeatureSliderCategoryImage300x370Url = a.FeatureSliderCategoryImage300x370Url,
				IsTrendingStories = a.IsTrendingStories,
				MainImage1200x600Url = a.MainImage1200x600Url,
				Name = a.AppUser.Name,
				Surname = a.AppUser.Surname,
				LastArticleImage1200x800Url = a.LastArticleImage1200x800Url,
				SubFeatureImage500x500Url = a.SubFeatureImage500x500Url,
				SubFeatureStatus = a.SubFeatureStatus

			}).ToList();
			return Ok(values);
		}

		[HttpGet("GetNextArticle")]
		public IActionResult GetNextArticlePost(int id)
		{
			var values = _context.Articles
				.Where(x => x.ArticleId > id)
				.OrderBy(x => x.ArticleId)
				.Select(x => new GetArticleByIdDto
				{
					ArticleId = x.ArticleId,
					Title = x.Title
				})
				.FirstOrDefault();

			if (values == null)
			{
				return NotFound("Sıradaki Kayıt Bulunamadı");
			}

			return Ok(values);
		}

		[HttpGet("GetPreviousArticle")]
		public IActionResult GetPreviousArticle(int id)
		{
			var values = _context.Articles
				.Where(x => x.ArticleId < id)
				.OrderByDescending(x => x.ArticleId)
				.Select(x => new GetArticleByIdDto
				{
					ArticleId = x.ArticleId,
					Title = x.Title
				})
				.FirstOrDefault();

			if (values == null)
			{
				return NotFound("Önceki Kayıt Bulunamadı");
			}

			return Ok(values);
		}

		[HttpGet("GetArticlesRelatedByCategory")]
		public IActionResult GetArticlesRelatedByCategory(int id)
		{
			var categoryId = _context.Articles.Where(x => x.ArticleId == id).Select(y => y.CategoryId).FirstOrDefault();
			var values = _context.Articles.Include(x => x.AppUser).Where(y => y.CategoryId == int.Parse(categoryId.ToString())).Skip(1).Take(3).Select(z => new Result3ArticlesByCategoryIdDto
			{
				ArticleId = z.ArticleId,
				Title = z.Title,
				CoverImage600x400Url = z.CoverImage600x400Url,
				Name = z.AppUser.Name,
				Surname = z.AppUser.Surname,
				CreatedDate = z.CreatedDate,
				UserImageUrl = z.AppUser.ImageUrl
			}).ToList();

			return Ok(values);
		}
	}
}