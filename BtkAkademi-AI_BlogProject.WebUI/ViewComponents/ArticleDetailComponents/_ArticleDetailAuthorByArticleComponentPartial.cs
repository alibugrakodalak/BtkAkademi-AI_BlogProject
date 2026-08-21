using BtkAkademi_AI_BlogProject.WebApi.DTO_s.UserDtos;
using BtkAkademi_AI_BlogProject.WebUI.DTO_s.ArticleDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BtkAkademi_AI_BlogProject.WebUI.ViewComponents.ArticleDetailComponents
{
	public class _ArticleDetailAuthorByArticleComponentPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;
		public _ArticleDetailAuthorByArticleComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync(int id)
		{
			string userId = "";

			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7003/api/Articles/GetArticle?id=" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<GetArticleById>(jsonData);
				userId = values.AppUserId;
			}


			var client2 = _httpClientFactory.CreateClient();
			var responseMessage2 = await client2.GetAsync("https://localhost:7003/api/Users/GetUserById?id=" + userId);
			if (responseMessage2.IsSuccessStatusCode)
			{
				var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
				var values2 = JsonConvert.DeserializeObject<GetUserByIdDto>(jsonData2);
				ViewBag.AuthorNameSurname = values2.Name + " " + values2.Surname;
				ViewBag.AuthorDescription = values2.Description;
				ViewBag.UserImage = values2.ImageUrl;
				ViewBag.UserTitle = values2.Title;
				return View();
			}
			return View();
		}
	}
}
