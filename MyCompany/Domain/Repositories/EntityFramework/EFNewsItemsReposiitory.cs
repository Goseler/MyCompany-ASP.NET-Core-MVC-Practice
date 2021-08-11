using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
			if (entity.Id == default)
			{
				_context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
			}
			else
			{
				_context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			}
			_context.SaveChanges();
		}

		public void DeleteNewsItem(Guid id)
		{
			NewsItem entity = _context.NewsItems.FirstOrDefault(x => x.Id == id);
			if (entity != null)
			{
				_context.NewsItems.Remove(entity);
			}
			else
			{
				throw new ArgumentException("Ошибка удаления. Новость не существует");
			}
			_context.SaveChanges();
		}
	}
}
