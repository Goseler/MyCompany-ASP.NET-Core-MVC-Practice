using MyCompany.Domain.Entities;
using MyCompany.Domain.Repositories.Abstract;
using System;
using System.IO;
using System.Linq;

namespace MyCompany.Domain.Repositories.EntityFramework
{
	public class EFServiceItemsRepository : IServiceItemsRepository
	{
		private readonly AppDbContext _context;
		public EFServiceItemsRepository(AppDbContext context)
		{
			_context = context;
		}

		public IQueryable<ServiceItem> GetServiceItems()
		{
			return _context.ServiceItems;
		}

		public ServiceItem GetServiceItemById(Guid id)
		{
			return _context.ServiceItems.FirstOrDefault(x => x.Id == id);
		}

		public void SaveServiceItem(ServiceItem entity)
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

		public void DeleteServiceItem(Guid id)
		{
			ServiceItem serviceItem = GetServiceItemById(id);

			if (serviceItem != null)
			{
				if (serviceItem.TitleImagePath != null)
				{
					FileInfo file = new FileInfo(serviceItem.TitleImagePath);
					if (file.Exists)
						file.Delete();
				}
				_context.Remove(serviceItem);
			}
			else
				throw new ArgumentException("Ошибка удаления. Новость не существует");

			_context.SaveChanges();
		}

	}
}
