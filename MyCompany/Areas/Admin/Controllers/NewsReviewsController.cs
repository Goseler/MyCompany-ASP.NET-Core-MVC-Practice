using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyCompany.Domain;
using MyCompany.Domain.Entities;
using MyCompany.Models;
using MyCompany.Service;
using System;
using System.IO;
using System.Threading.Tasks;
using static MyCompany.Service.Extensions;

namespace MyCompany.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class NewsReviewsController : Controller
	{
		private readonly DataManager dataManager;
		private readonly IWebHostEnvironment webHostEnvironment;
		private readonly IMailService mailService;
		private readonly ILogger<NewsReviewsController> logger;

		public NewsReviewsController(DataManager dataManager, IWebHostEnvironment webHostEnvironment, IMailService mailService, ILogger<NewsReviewsController> logger)
		{
			this.dataManager = dataManager;
			this.webHostEnvironment = webHostEnvironment;
			this.mailService = mailService;
			this.logger = logger;
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
					FileManager.SaveImage(titleImageFile, newsMessage.TitleImagePath, webHostEnvironment);

					NewsItem newsItem = newsMessage.ConvertToNews();

					try
					{
						dataManager.NewsItems.SaveNewsItem(newsItem);
					}
					catch (Exception ex)
					{
						if (ex.GetBaseException().Message.Contains("Повторяющееся значение ключа: "))
						{
							ModelState.AddModelError(string.Empty, "Новость уже сущетствует");
							return View(newsMessage);
						}
						logger.LogError(ex.GetBaseException().Message);
					}
				}
				else
					return View(newsMessage);
			}

			MailRequest mailRequest = new()
			{
				Subject = new string("Рецензия на новсть: " + newsMessage.Title),
				ToEmail = newsMessage.Email,
				ResponseBody = newsMessage.ResponsetText,
				DateSent = newsMessage.DateAdded,
				UserBody = new string(newsMessage.Subtitle + "" + newsMessage.Text),
				TitleImagePath = Path.Combine(webHostEnvironment.WebRootPath, "images/uploads/", newsMessage.TitleImagePath)
			};
			await mailService.SendEmailAsync(mailRequest);

			dataManager.NewsMessages.DeleteNewsMessage(newsMessage.Id);

			return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
		}

		[HttpPost]
		public IActionResult Delete(Guid id)
		{
			FileManager.Delete(dataManager.NewsMessages.GetNewsMessageById(id).TitleImagePath, "images/uploads/", webHostEnvironment);

			dataManager.NewsMessages.DeleteNewsMessage(id);
			return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
		}
	}
}
