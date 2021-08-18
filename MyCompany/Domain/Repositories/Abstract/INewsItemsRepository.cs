using MyCompany.Domain.Entities;
using System;
using System.Linq;

namespace MyCompany.Domain.Repositories.Abstract
{
	public interface INewsItemsRepository
	{
		IQueryable<NewsItem> GetNewsItems();
		NewsItem GetNewsItemById(Guid id);
		void SaveNewsItem(NewsItem entity);
		void DeleteNewsItem(Guid id);
	}
}
