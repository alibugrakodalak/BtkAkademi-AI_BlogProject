using BtkAkademi_AI_BlogProject.WebUI.DTO_s.ArticleDtos;
using BtkAkademi_AI_BlogProject.WebUI.DTO_s.TradingVideoDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BtkAkademi_AI_BlogProject.WebUI.ViewComponents.TradingVideoComponents
{
	public class _TradingVideoIsFeatureByTrueComponentPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;
		public _TradingVideoIsFeatureByTrueComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7003/api/TradingVideos/GetFeatureTradingVideo");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<GetTradingFeatureVideoDto>(jsonData);
				ViewBag.Title = values.Title;
				ViewBag.FeatureImage1200x675Url = values.FeatureImage1200x675Url;
				ViewBag.EmbedVideoUrl = values.EmbedVideoUrl;
				ViewBag.CreatedDate = values.CreatedDate;
				ViewBag.UserNameSurname = values.UserNameSurname;
				ViewBag.UserImageUrl = values.UserImageUrl;
			}

			return View();
		}
	}
}
