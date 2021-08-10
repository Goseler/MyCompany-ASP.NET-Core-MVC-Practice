using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using MyCompany.Domain.Entities;
using MyCompany.Domain.Repositories.Abstract;

namespace MyCompany.Domain.Repositories.EntityFramework
{
	public class EFNewsItemsReposiitory : INewsItemsRepository
	{
		private readonly AppDbContext _context;
		public EFNewsItemsReposiitory(AppDbContext context)
		{
			_context = context;
		}

		public IQueryable<NewsItem> GetNewsItems()
		{
			return _context.NewsItems;
		}

		public NewsItem GetNewsItemById(Guid id)
		{
			return _context.NewsItems.FirstOrDefault(x => x.Id == id);
		}

		public void SaveNewsItem(NewsItem entity)
		{
			if (entity.Id == default || GetNewsItemById(entity.Id) == null)
				_context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
			else
				_context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

			_context.SaveChanges();
		}

		public void DeleteNewsItem(Guid id)
		{
			NewsItem newsItem = GetNewsItemById(id);

			if (newsItem != null)
			{
				if (newsItem.TitleImagePath != null)
				{
					FileInfo file = new FileInfo(newsItem.TitleImagePath);
					if (file.Exists)
						file.Delete();
				}
				_context.Remove(newsItem);
			}
			else
				throw new ArgumentException("Ошибка удаления. Новость не существует");

			_context.SaveChanges();
		}
	}
}
