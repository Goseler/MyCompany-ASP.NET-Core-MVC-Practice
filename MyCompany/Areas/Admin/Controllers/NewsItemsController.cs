using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MyCompany.Domain;
using MyCompany.Domain.Entities;
using MyCompany.Service;
using System;
using System.IO;
using static MyCompany.Service.Extensions;

namespace MyCompany.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class NewsItemsController : Controller
	{
		private readonly DataManager dataManager;
		private readonly IWebHostEnvironment webHostEnvironment;

		public NewsItemsController(DataManager dataManager, IWebHostEnvironment webHostEnvironment)
		{
			this.dataManager = dataManager;
			this.webHostEnvironment = webHostEnvironment;
		}

		public IActionResult Edit(Guid id)
		{
			var entity = id == default ? new NewsItem() : dataManager.NewsItems.GetNewsItemById(id);
			return View(entity);
		}

		[HttpPost]
		public IActionResult Edit(NewsItem model, IFormFile titleImageFile)
		{
			if (ModelState.IsValid)
			{
				if (titleImageFile != null)
				{
					FileManager.Delete(model.TitleImagePath, "images/uploads/", webHostEnvironment);

					model.TitleImagePath = Guid.NewGuid().ToString("N") + titleImageFile.FileName;
					using var stream = new FileStream(Path.Combine(webHostEnvironment.WebRootPath, "images/uploads/", model.TitleImagePath), FileMode.Create);
					titleImageFile.CopyTo(stream);
				}

				try
				{
					dataManager.NewsItems.SaveNewsItem(model);
				}
				catch (Exception ex)
				{
					if (ex.InnerException.Message.Contains("Повторяющееся значение ключа: "))
						ModelState.AddModelError(string.Empty, "Новость уже сущетствует");

					return View(model);
				}
				return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
			}
			return View(model);
		}

		[HttpPost]
		public IActionResult Delete(Guid id)
		{
			FileManager.Delete(dataManager.NewsItems.GetNewsItemById(id).TitleImagePath, "images/uploads/", webHostEnvironment);

			dataManager.NewsItems.DeleteNewsItem(id);
			return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
		}
	}
}

