using Microsoft.AspNetCore.Mvc;
using MyCompany.Domain;

namespace MyCompany.Controllers
{
	public class HomeController : Controller
	{
		private readonly DataManager dataManager;

		public HomeController(DataManager dataManager) => this.dataManager = dataManager;

		public IActionResult Index() => View(dataManager.TextFields.GetTextFieldByCodeWord("PageIndex"));

		public IActionResult Contacts() => View(dataManager.TextFields.GetTextFieldByCodeWord("PageContacts"));
	}
}
