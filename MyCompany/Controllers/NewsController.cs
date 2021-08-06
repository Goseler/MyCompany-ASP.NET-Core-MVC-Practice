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
            TextField textField = dataManager.TextFields.GetTextFieldByCodeWord("PageNews"); ;
            IQueryable<NewsItem> newsItems = dataManager.NewsItems.GetNewsItems();
            NewsViewModel newsViewModel = new NewsViewModel() { NewsItems = newsItems, TextField = textField };

            if (id != default)
			{
                newsViewModel.NewsItems = newsItems.Where(n => n.Id == id);
                return View("Show", newsViewModel);
			}

            return View(newsViewModel);
		}
    }
}
