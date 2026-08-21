using BtkAkademi_AI_BlogProject.WebUI.DTO_s.ContactDtos;
using BtkAkademi_AI_BlogProject.WebUI.DTO_s.MessageDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace BtkAkademi_AI_BlogProject.WebUI.Controllers
{
	public class ContactController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public ContactController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		[HttpGet]
		public async Task<IActionResult> SendMessage()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7003/api/Contacts/GetFirstContact");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<ResultContactDto>(jsonData);
				ViewBag.PhoneNumber1 = values.PhoneNumberFirst;
				ViewBag.PhoneNumber2 = values.PhoneNumberSecond;
				ViewBag.Mail1 = values.FirstEmail;
				ViewBag.Mail2 = values.SecondEmail;
				ViewBag.Address = values.Address;
				ViewBag.Map = values.MapLocation;
			}
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> SendMessage(CreateMessageDto createMessageDto)
		{
			createMessageDto.SendDate = DateTime.Now;
			createMessageDto.IsRead = false;
			createMessageDto.AIStatus = "pending";
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createMessageDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			await client.PostAsync("https://localhost:7003/api/Contacts", stringContent);
			return View();
		}
	}
}
