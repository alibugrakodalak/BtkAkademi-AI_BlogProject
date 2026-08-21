using BtkAkademi_AI_BlogProject.WebUI.DTO_s.CommentDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BtkAkademi_AI_BlogProject.WebUI.ViewComponents.ArticleDetailComponents
{
	public class _ArticleDetailCommentListByArticleComponentPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;
		public _ArticleDetailCommentListByArticleComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7003/api/Comments/GetCommentsWithUsersByArticleId?id=" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultCommentWithUserDto>>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}
