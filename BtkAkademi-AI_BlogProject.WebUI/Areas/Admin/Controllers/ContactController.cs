using BtkAkademi_AI_BlogProject.WebUI.DTO_s.ContactDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace BtkAkademi_AI_BlogProject.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ContactController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public ContactController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> ContactList()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7003/api/Contacts");

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
				var contact = values?.FirstOrDefault();

				return View(contact);
			}

			return View();
		}

		[HttpGet]
		public IActionResult CreateContact()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createContactDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7003/api/Contacts", stringContent);
			return RedirectToAction("ContactList", "Contact", new { area = "Admin" });

		}
		public async Task<IActionResult> RemoveContact(int id)
		{
			var client = _httpClientFactory.CreateClient();
			await client.DeleteAsync("https://localhost:7003/api/Contacts?id=" + id);
			return RedirectToAction("ContactList", "Contact", new { area = "Admin" });
		}

		[HttpGet]
		public async Task<IActionResult> UpdateContact(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7003/api/Contacts/GetContact?id=" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<GetContactByIdDto>(jsonData);
				return View(values);
			}
			return RedirectToAction("ContactList", "Contact", new { area = "Admin" });
		}

		[HttpPost]
		public async Task<IActionResult> UpdateContact(UpdateContactDto updateContactDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateContactDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			await client.PutAsync("https://localhost:7003/api/Contacts/", stringContent);
			return RedirectToAction("ContactList", "Contact", new { area = "Admin" });
		}
	}
}
