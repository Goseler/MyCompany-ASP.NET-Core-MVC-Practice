using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCompany.Domain;
using MyCompany.Domain.Entities;
using MyCompany.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompany.Controllers
{
	public class ServicesController : Controller
	{
		private readonly DataManager dataManager;

		public ServicesController(DataManager dataManager) => this.dataManager = dataManager;

		public async Task<IActionResult> IndexAsync(Guid id, int page = 1)
		{
			if (id != default)
				return View("Show", dataManager.ServiceItems.GetServiceItemById(id));

			IQueryable<ServiceItem> serviceItems = dataManager.ServiceItems.GetServiceItems();
			TextField textField = dataManager.TextFields.GetTextFieldByCodeWord("PageServices");

			int pageSize = 7;
			var count = await serviceItems.CountAsync();
			var items = await serviceItems.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
			PageViewModel pageViewModel = new(count, page, pageSize);

			ServiceViewModel serviceViewModel = new() { ServiceItems = items, TextField = textField, PageViewModel = pageViewModel };

			return View(serviceViewModel);
		}
	}
}
