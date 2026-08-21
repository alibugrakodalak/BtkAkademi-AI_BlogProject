using Microsoft.AspNetCore.Mvc;

namespace BtkAkademi_AI_BlogProject.WebUI.Controllers
{
	public class DefaultController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
