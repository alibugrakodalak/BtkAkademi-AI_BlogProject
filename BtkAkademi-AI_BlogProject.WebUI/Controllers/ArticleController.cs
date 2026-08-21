using BtkAkademi_AI_BlogProject.WebUI.DTO_s.ArticleDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BtkAkademi_AI_BlogProject.WebUI.Controllers
{
	public class ArticleController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		public ArticleController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> ArticleList(int? categoryId)
		{
			var client = _httpClientFactory.CreateClient();

			var responseMessage = await client.GetAsync("https://localhost:7003/api/Articles");

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();

				var values = JsonConvert.DeserializeObject<List<ResultArticleDto>>(jsonData)
							 ?? new List<ResultArticleDto>();

				if (categoryId.HasValue)
				{
					values = values
						.Where(x => x.CategoryId == categoryId.Value)
						.ToList();
				}

				return View(values);
			}

			return View(new List<ResultArticleDto>());
		}
		public IActionResult ArticleDetail(int id)
		{
			ViewBag.i = id;
			return View();
		}
	}
}
