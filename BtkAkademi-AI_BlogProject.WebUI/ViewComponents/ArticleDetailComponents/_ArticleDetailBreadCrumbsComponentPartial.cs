using BtkAkademi_AI_BlogProject.WebUI.DTO_s.ArticleDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BtkAkademi_AI_BlogProject.WebUI.ViewComponents.ArticleDetailComponents
{
	public class _ArticleDetailBreadCrumbsComponentPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;
		public _ArticleDetailBreadCrumbsComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7003/api/Articles/GetArticle?id=" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<GetArticleById>(jsonData);
				ViewBag.LastArticleImage1200x800Url = values.LastArticleImage1200x800Url;
				ViewBag.Title = values.Title;
				return View();
			}
			return View();
		}
	}
}
