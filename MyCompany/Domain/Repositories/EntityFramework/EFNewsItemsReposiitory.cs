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
		private readonly AppDbContext context;
		public EFNewsItemsReposiitory(AppDbContext context)
		{
			this.context = context;
		}

		public IQueryable<NewsItem> GetNewsItems()
		{
			return context.NewsItems;
		}

		public NewsItem GetNewsItemById(Guid id)
		{
			return context.NewsItems.FirstOrDefault(x => x.Id == id);
		}

		public void SaveNewsItem(NewsItem entity)
		{
			if (entity.Id == default || GetNewsItemById(entity.Id) == null)
			{
				context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
			}
			else
			{
				context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			}
			context.SaveChanges();
		}

		public void DeleteNewsItem(Guid id)
		{
			context.NewsItems.Remove(new NewsItem() { Id = id });
			context.SaveChanges();
		}
	}
}
