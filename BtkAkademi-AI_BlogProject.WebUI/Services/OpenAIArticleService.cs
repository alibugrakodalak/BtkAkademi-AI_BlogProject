using System.Text;
using System.Text.Json;

namespace BtkAkademi_AI_BlogProject.WebUI.Services
{
	public class OpenAIArticleService
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly IConfiguration _configuration;

		public OpenAIArticleService(IHttpClientFactory httpClientFactory,IConfiguration configuration)
		{
			_httpClientFactory = httpClientFactory;
			_configuration = configuration;
		}

		public async Task<string> GenerateArticleAsync(string topic)
		{
			var client = _httpClientFactory.CreateClient();

			client.DefaultRequestHeaders.Add("Authorization",
				$"Bearer {_configuration["OpenAI:ApiKey"]}");

			var requestBody = new
			{
				model = "gpt-4o-mini",
				messages = new[]
				{
				new { role = "system", content = "Sen profesyonel bir makale yazarısın." },
				new {
					role = "user",
					content = $"'{topic}' konusu hakkında giriş, gelişme ve sonuç içeren, " +
							  $"SEO uyumlu, akademik ama aynı zamanda kısmen samimi tonlu, minimum 1500 karakter uzunluğunda " +
							  $"detaylı bir makale yaz."
				}
			},
				temperature = 0.7,
				max_tokens = 1100
			};

			var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

			var response = await client.PostAsync("https://api.openai.com/v1/chat/completions",	content);

			response.EnsureSuccessStatusCode();

			var responseString = await response.Content.ReadAsStringAsync();

			using var doc = JsonDocument.Parse(responseString);
			return doc.RootElement
					  .GetProperty("choices")[0]
					  .GetProperty("message")
					  .GetProperty("content")
					  .GetString();
		}
	}
}
