using Microsoft.AspNetCore.Mvc;

namespace BtkAkademi_AI_BlogProject.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class AdminChatController : Controller
	{
		public IActionResult SendChatWithAI()
		{
			return View();
		}
	}
}
