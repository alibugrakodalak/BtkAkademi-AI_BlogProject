using BtkAkademi_AI_BlogProject.WebUI.DTO_s.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BtkAkademi_AI_BlogProject.WebUI.ViewComponents.LayoutComponents
{
	public class _LayoutHeaderNavBarComponentPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _LayoutHeaderNavBarComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();

			var responseMessage = await client.GetAsync(
				"https://localhost:7003/api/Categories");

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();

				var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

				return View(values ?? new List<ResultCategoryDto>());
			}

			return View(new List<ResultCategoryDto>());
		}
	}
}
