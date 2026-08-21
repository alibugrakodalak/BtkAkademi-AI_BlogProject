using Microsoft.AspNetCore.Mvc;

namespace BtkAkademi_AI_BlogProject.WebUI.ViewComponents.SubFeatureComponents
{
	public class _SubFeatureComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
