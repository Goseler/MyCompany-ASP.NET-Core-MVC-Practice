using Microsoft.AspNetCore.Mvc;
using MyCompany.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompany.Controllers
{
	public class HomeController : Controller
	{
		private readonly DataManager dataManager;

		public HomeController(DataManager dataManager)
		{
			this.dataManager = dataManager;
		}

		public IActionResult Index()
		{
			return View(dataManager.TextFields.GetTextFieldByCodeWord("PageIndex"));
		}

		public IActionResult Contacts()
		{
			return View(dataManager.TextFields.GetTextFieldByCodeWord("PageContacts"));
		}
	}
}
