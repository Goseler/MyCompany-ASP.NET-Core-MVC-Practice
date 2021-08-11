using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCompany.Domain;
using MyCompany.Domain.Entities;
using MyCompany.Models;
using MyCompany.Service;
using System;
using System.IO;
using System.Linq;
using static MyCompany.Service.Extensions;

namespace MyCompany.Controllers
{
	public class NewsController : Controller
	{
		private readonly DataManager dataManager;
		private readonly IWebHostEnvironment webHostEnvironment;

		public NewsController(DataManager dataManager, IWebHostEnvironment webHostEnvironment)
		{
			this.dataManager = dataManager;
			this.webHostEnvironment = webHostEnvironment;
		}

		public IActionResult Index(Guid id)
		{
			if (id != default)
				return View("Show", dataManager.NewsItems.GetNewsItemById(id));

			IQueryable<NewsItem> newsItems = dataManager.NewsItems.GetNewsItems();
			TextField textField = dataManager.TextFields.GetTextFieldByCodeWord("PageNews"); ;
			NewsViewModel newsViewModel = new() { NewsItems = newsItems, TextField = textField };

			return View(newsViewModel);
		}

		public IActionResult Add() => View(new NewsMessage());

		[HttpPost]
		public IActionResult Add(NewsMessage newsMessage, IFormFile titleImageFile)
		{
			if (ModelState.IsValid)
			{
				if (titleImageFile != null)
				{
					newsMessage.TitleImagePath = Guid.NewGuid().ToString("N") + titleImageFile.FileName;
					using var stream = new FileStream(Path.Combine(webHostEnvironment.WebRootPath, "images/uploads/", newsMessage.TitleImagePath), FileMode.Create);
						titleImageFile.CopyTo(stream);

				}

				dataManager.NewsMessages.SaveNewsMessage(newsMessage);

				return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
			}

			return View(newsMessage);
		}
	}
}
