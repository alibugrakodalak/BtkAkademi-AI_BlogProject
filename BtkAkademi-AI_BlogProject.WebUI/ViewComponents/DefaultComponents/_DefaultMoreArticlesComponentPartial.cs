using Microsoft.AspNetCore.Mvc;

namespace BtkAkademi_AI_BlogProject.WebUI.ViewComponents.DefaultComponents
{
	public class _DefaultMoreArticlesComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();			
		}
	}
}
