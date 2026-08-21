using Microsoft.AspNetCore.Mvc;

namespace BtkAkademi_AI_BlogProject.WebUI.Controllers
{
	public class ErrorPagesController : Controller
	{
		public IActionResult Page404()
		{
			return View();
		}
	}
}
