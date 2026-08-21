using BtkAkademi_AI_BlogProject.WebUI.DTO_s.ArticleDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BtkAkademi_AI_BlogProject.WebUI.ViewComponents.DefaultComponents
{
	public class _DefaultSubFeaturePostsComponentPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _DefaultSubFeaturePostsComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7003/api/Articles/GetArticlesSubFeaturePostsStatusByTrue");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultArticlesSubFeaturePostsStatusByTrueDto>>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}
