using BtkAkademi_AI_BlogProject.WebUI.DTO_s.ArticleDtos;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace BtkAkademi_AI_BlogProject.WebUI.ViewComponents.ArticleDetailComponents
{
	public class _ArticleDetailPreviousAndNextPostComponentPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _ArticleDetailPreviousAndNextPostComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync(int id)
		{
			var client = _httpClientFactory.CreateClient();

			GetArticleById? nextPost = null;
			var nextResponse = await client.GetAsync($"https://localhost:7003/api/Articles/GetNextArticle?id={id}");
			if (nextResponse.IsSuccessStatusCode)
				nextPost = await nextResponse.Content.ReadFromJsonAsync<GetArticleById>();

			GetArticleById? prevPost = null;
			var prevResponse = await client.GetAsync($"https://localhost:7003/api/Articles/GetPreviousArticle?id={id}");
			if (prevResponse.IsSuccessStatusCode)
				prevPost = await prevResponse.Content.ReadFromJsonAsync<GetArticleById>();

			ViewBag.NextPost = nextPost;
			ViewBag.PrevPost = prevPost;

			return View();
		}
	}
}