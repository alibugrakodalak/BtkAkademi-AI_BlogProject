using BtkAkademi_AI_BlogProject.WebUI.DTO_s.ArticleDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BtkAkademi_AI_BlogProject.WebUI.ViewComponents.DefaultComponents
{
	public class _DefaultFeatureComponentPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;
		public _DefaultFeatureComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{

			#region LastTechnologyArticle
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7003/api/Articles/GetLastTechnologyArticle");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<ResultLastTechnologyArticleDto>(jsonData);
				ViewBag.LastTechnologyArticleTitle = values.Title;
				ViewBag.LastTechnologyArticleFeatureImageUrl = values.FeaturedCoverImage600x600Url;
				ViewBag.LastTechnologyArticleAuthor = values.Name + " " + values.Surname;
				ViewBag.LastTechnologyArticleAuthorImageUrl = values.ImageUrl;
			}
			#endregion

			#region LastTravelArticle
			var client1 = _httpClientFactory.CreateClient();
			var responseMessage1 = await client1.GetAsync("https://localhost:7003/api/Articles/GetLastTravelArticle");
			if (responseMessage1.IsSuccessStatusCode)
			{
				var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
				var values1 = JsonConvert.DeserializeObject<ResultLastTravelArticleDto>(jsonData1);
				ViewBag.LastTravelArticleTitle = values1.Title;
				ViewBag.LastTravelArticleFeatureImageUrl = values1.FeaturedCoverImage600x600Url;
				ViewBag.LastTravelArticleAuthor = values1.Name + " " + values1.Surname;
				ViewBag.LastTravelArticleAuthorImageUrl = values1.ImageUrl;
			}
			#endregion

			#region LastPoliticsArticle
			var client2 = _httpClientFactory.CreateClient();
			var responseMessage2 = await client2.GetAsync("https://localhost:7003/api/Articles/GetLastPoliticArticle");
			if (responseMessage2.IsSuccessStatusCode)
			{
				var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
				var values2 = JsonConvert.DeserializeObject<ResultLastPoliticArticleDto>(jsonData2);
				ViewBag.LastPoliticsArticleTitle = values2.Title;
				ViewBag.LastPoliticsArticleFeatureImageUrl = values2.FeaturedCoverImage600x600Url;
				ViewBag.LastPoliticsArticleCreatedDate = values2.CreatedDate;
				ViewBag.LastTravelPoliticAuthor = values2.Name + " " + values2.Surname;
				ViewBag.LastTravelPoliticAuthorImageUrl = values2.ImageUrl;
			}
			#endregion

			return View();

		}
	}
}
