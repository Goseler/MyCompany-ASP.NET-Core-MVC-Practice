using Microsoft.AspNetCore.Mvc;
using MyCompany.Domain;
using MyCompany.Models;

namespace MyCompany.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class HomeController : Controller
	{
		private readonly DataManager dataManager;

		public HomeController(DataManager dataManager) => this.dataManager = dataManager;

		public IActionResult Index() => View();

		[HttpPost]
		public PartialViewResult Index(AjaxPage Page)
		{
			return Page switch
			{
				AjaxPage.Services => PartialView("ServicesPartial", dataManager.ServiceItems.GetServiceItems()),
				AjaxPage.MainPages => PartialView("MainPagesPartial"),
				AjaxPage.News => PartialView("NewsPartial", dataManager.NewsItems.GetNewsItems()),
				AjaxPage.UsersMessages => PartialView("UsersMessagesPartial", dataManager.TechMessages.GetTechMessages()),
				AjaxPage.NewsReviews => PartialView("NewsReviewsPartial", dataManager.NewsMessages.GetNewsMessages()),
				_ => PartialView("ServicesPartial", dataManager.ServiceItems.GetServiceItems()),
			};
		}
	}
}
