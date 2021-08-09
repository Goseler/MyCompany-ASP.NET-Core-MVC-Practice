using Microsoft.AspNetCore.Mvc;
using MyCompany.Domain;
using MyCompany.Domain.Entities;
using MyCompany.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Controllers
{
    public class UserActionsController : Controller
    {
        private readonly DataManager dataManager;
		public UserActionsController(DataManager dataManager)
		{
			this.dataManager = dataManager;
		}
        public IActionResult TechSupport()
		{
            return View(new TechMessage());
		}

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
