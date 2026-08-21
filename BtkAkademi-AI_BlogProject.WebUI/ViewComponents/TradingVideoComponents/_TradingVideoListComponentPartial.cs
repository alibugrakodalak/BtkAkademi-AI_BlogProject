using BtkAkademi_AI_BlogProject.WebUI.DTO_s.ArticleDtos;
using BtkAkademi_AI_BlogProject.WebUI.DTO_s.TradingVideoDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BtkAkademi_AI_BlogProject.WebUI.ViewComponents.TradingVideoComponents
{
	public class _TradingVideoListComponentPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;
		public _TradingVideoListComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7003/api/TradingVideos");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultTradingVideoDto>>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}
