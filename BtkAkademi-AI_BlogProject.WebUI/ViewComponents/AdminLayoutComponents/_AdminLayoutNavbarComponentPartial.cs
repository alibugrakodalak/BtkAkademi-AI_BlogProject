using Microsoft.AspNetCore.Mvc;

namespace BtkAkademi_AI_BlogProject.WebUI.ViewComponents.AdminLayoutComponents
{
	public class _AdminLayoutNavbarComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
