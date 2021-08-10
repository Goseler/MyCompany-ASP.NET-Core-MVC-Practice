﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCompany.Domain;
using MyCompany.Domain.Entities;
using MyCompany.Models;
using MyCompany.Service;
using System;
using System.IO;
using System.Threading.Tasks;

namespace MyCompany.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class NewsReviewsController : Controller
	{
		private readonly DataManager dataManager;
		private readonly IWebHostEnvironment webHostEnvironment;
		private readonly IMailService mailService;

		public NewsReviewsController(DataManager dataManager, IWebHostEnvironment webHostEnvironment, IMailService mailService)
		{
			this.dataManager = dataManager;
			this.webHostEnvironment = webHostEnvironment;
			this.mailService = mailService;
		}
		public IActionResult Review(Guid id)
		{
			NewsMessage newsMessage = dataManager.NewsMessages.GetNewsMessageById(id);
			return View(newsMessage);
		}

		// TODO Refactor
		[HttpPost]
		public async Task<IActionResult> Review(NewsMessage newsMessage, IFormFile titleImageFile, string submitButton)
		{
			if (submitButton == "Принять")
			{
				if (ModelState.IsValid)
				{
					if (titleImageFile != null)
					{
						if (newsMessage.TitleImagePath != null)
						{
							FileInfo file = new FileInfo(newsMessage.TitleImagePath);
							if (file.Exists)
								file.Delete();
						}

						newsMessage.TitleImagePath = Path.Combine(webHostEnvironment.WebRootPath, "images/uploads/", Guid.NewGuid().ToString("N") + titleImageFile.FileName);
						using (var stream = new FileStream(newsMessage.TitleImagePath, FileMode.Create))
							titleImageFile.CopyTo(stream);
					}

					// Add News to DB
					NewsItem newsItem = new NewsItem();
					newsItem = newsMessage.ConvertToNews();
					dataManager.NewsItems.SaveNewsItem(newsItem);
				}
				else
					return View(newsMessage);
			}

			// Send Email
			MailRequest entity = new MailRequest()
			{
				Subject = new string("Рецензия на новсть: " + newsMessage.Title),
				ToEmail = newsMessage.Email,
				ResponseBody = newsMessage.ResponsetText,
				DateSent = newsMessage.DateAdded,
				UserBody = new string(newsMessage.Subtitle + "" + newsMessage.Text),
				TitleImagePath = newsMessage.TitleImagePath
			};
			await mailService.SendEmailAsync(entity);

			dataManager.NewsMessages.DeleteNewsMessage(newsMessage.Id);

			return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
		}

		[HttpPost]
		public IActionResult Delete(Guid id)
		{
			dataManager.NewsMessages.DeleteNewsMessage(id);
			return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
		}
	}
}
