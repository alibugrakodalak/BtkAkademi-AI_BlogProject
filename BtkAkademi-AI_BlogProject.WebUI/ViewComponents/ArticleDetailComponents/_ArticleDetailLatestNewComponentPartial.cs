using BtkAkademi_AI_BlogProject.WebUI.DTO_s.ArticleDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BtkAkademi_AI_BlogProject.WebUI.ViewComponents.ArticleDetailComponents
{
	public class _ArticleDetailLatestNewComponentPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;
		public _ArticleDetailLatestNewComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7003/api/Articles/GetLast4ArticlesWithCategory");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultLast4ArticleWithCategoryDto>>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}
