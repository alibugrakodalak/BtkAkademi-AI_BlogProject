using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using BtkAkademi_AI_BlogProject.WebUI.Areas.Admin.Models;

namespace BtkAkademi_AI_BlogProject.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class RapidAPIController : Controller
	{
		private readonly IConfiguration _configuration;

		public RapidAPIController(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public async Task<IActionResult> PopularMoviesList()
		{
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://imdb236.p.rapidapi.com/api/imdb/most-popular-movies"),
				Headers =
				{
					{ "x-rapidapi-key", _configuration["RapidAPI:Key"] },
					{ "x-rapidapi-host", "imdb236.p.rapidapi.com" },
				},
			};

			List<RapidAPIMoviesModel> movies = new();

			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();

				movies = JsonSerializer.Deserialize<List<RapidAPIMoviesModel>>(body, new JsonSerializerOptions
				{
					PropertyNameCaseInsensitive = true
				}) ?? new List<RapidAPIMoviesModel>();
			}

			return View(movies);
		}
	}
}