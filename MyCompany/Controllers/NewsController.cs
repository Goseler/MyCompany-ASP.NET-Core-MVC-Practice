using Microsoft.AspNetCore.Mvc;
using MyCompany.Domain;
using MyCompany.Domain.Entities;
using MyCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Controllers
{
    public class NewsController : Controller
    {
        private readonly DataManager dataManager;
		public NewsController(DataManager dataManager)
		{
            this.dataManager = dataManager;
		}

        public IActionResult Index(Guid id)
		{
            if (id != default)
			{
                return View("Show", dataManager.NewsItems.GetNewsItemById(id));
			}

            IQueryable<NewsItem> newsItems = dataManager.NewsItems.GetNewsItems();
            TextField textField = dataManager.TextFields.GetTextFieldByCodeWord("PageNews"); ;
            NewsViewModel newsViewModel = new NewsViewModel() { NewsItems = newsItems, TextField = textField };

            return View(newsViewModel);
		}
    }
}
