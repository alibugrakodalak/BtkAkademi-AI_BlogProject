using BtkAkademi_AI_BlogProject.WebUI.DTO_s.ArticleDtos;
using BtkAkademi_AI_BlogProject.WebUI.DTO_s.CategoryDtos;
using BtkAkademi_AI_BlogProject.WebUI.Services;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace BtkAkademi_AI_BlogProject.WebUI.Controllers
{
	public class AdminArticleController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly OpenAIArticleService _openAIArticle;
		private readonly OpenAIArticleTitleService _openAIArticleTitleService;

		public AdminArticleController(IHttpClientFactory httpClientFactory, OpenAIArticleService openAIArticle, OpenAIArticleTitleService openAIArticleTitleService)
		{
			_httpClientFactory = httpClientFactory;
			_openAIArticle = openAIArticle;
			_openAIArticleTitleService = openAIArticleTitleService;
		}

		public async Task<IActionResult> ArticleList()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7003/api/Articles");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultArticleDto>>(jsonData);
				return View(values);
			}
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> CreateArticle()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7003/api/Categories");
			var jsonData = await responseMessage.Content.ReadAsStringAsync();
			var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
			List<SelectListItem> CategoryValues = (from x in values
												   select new SelectListItem
												   {
													   Text  = x.CategoryName,
													   Value = x.CategoryId.ToString()
												   }).ToList();
			ViewBag.CategoryValues = CategoryValues;

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateArticle(CreateArticle createArticle)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createArticle);
			StringContent stringContent = new StringContent(jsonData);
			var responseMessage = await client.PostAsync("https://localhost:7003/api/Articles", stringContent);
			return RedirectToAction("ArticleList");
		}

		public async Task<IActionResult> RemoveArticle(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var values = await client.DeleteAsync("https://localhost:7003/api/Articles?id=" + id);
			return RedirectToAction("CategoryList");
		}

		[HttpGet]
		public async Task<IActionResult> UpdateArticle(int id)
		{
			var client1 = _httpClientFactory.CreateClient();
			var responseMessage1 = await client1.GetAsync("https://localhost:7003/api/Categories");
			var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
			var values1 = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData1);
			List<SelectListItem> CategoryValues = (from x in values1
												   select new SelectListItem
												   {
													   Text = x.CategoryName,
													   Value = x.CategoryId.ToString()
												   }).ToList();
			ViewBag.CategoryValues = CategoryValues;

			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7003/api/Articles/GetArticle?id=" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<GetArticleById>(jsonData);
				return View(values);
			}
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> UpdateArticle(UpdateArticle updateArticle)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateArticle);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			await client.PutAsync("https://localhost:7003/api/Articles", stringContent);
			return RedirectToAction("ArticleList");
		}

		[HttpGet]
		public async Task<IActionResult> CreateArticleWithAI()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateArticleWithAI(string topic)
		{
			if (string.IsNullOrWhiteSpace(topic))
			{
				ViewBag.Error = "Lütfen Konu Giriniz...!";
				return View();
			}

			ViewBag.Article = await _openAIArticle.GenerateArticleAsync(topic);
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> CreateArticleTitleWithAI()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateArticleTitleWithAI(string topic)
		{
			if (string.IsNullOrWhiteSpace(topic))
			{
				ViewBag.Error = "Lütfen Konu İle İlgili En Az 5 Kelime Giriniz...!";
				return View();
			}

			ViewBag.Article = await _openAIArticleTitleService.GenerateArticleTitleAsync(topic);
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> ChangeArticleIsFeatureSliderFromTrueToFalse(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7003/api/Articles/ChangeIsFeatureSliderFromTrueToFalse?id=" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("ArticleList", "AdminArticle");
			}
			return View();
		}


		[HttpGet]
		public async Task<IActionResult> ChangeArticleIsFeatureSliderFromFalseToTrue(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7003/api/Articles/ChangeIsFeatureSliderFromFalseToTrue?id=" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("ArticleList", "AdminArticle");
			}
			return View();
		}
	}
}
