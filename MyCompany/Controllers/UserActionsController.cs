using Microsoft.AspNetCore.Mvc;
using MyCompany.Domain;
using MyCompany.Domain.Entities;
using MyCompany.Service;

namespace MyCompany.Controllers
{
	public class UserActionsController : Controller
	{
		private readonly DataManager dataManager;

		public UserActionsController(DataManager dataManager) => this.dataManager = dataManager;

		public IActionResult TechSupport() => View(new TechMessage());

		[HttpPost]
		public IActionResult Send(TechMessage techMessage)
		{
			if (ModelState.IsValid)
			{
				dataManager.TechMessages.SaveTechMessage(techMessage);
				return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
			}

			return View(techMessage);
		}
	}
}
