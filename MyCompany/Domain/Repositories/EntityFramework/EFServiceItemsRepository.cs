using MyCompany.Domain.Entities;
using MyCompany.Domain.Repositories.Abstract;
using System;
using System.Linq;

namespace MyCompany.Domain.Repositories.EntityFramework
{
	public class EFServiceItemsRepository : IServiceItemsRepository
	{
		private readonly AppDbContext _context;

		public EFServiceItemsRepository(AppDbContext context) => _context = context;

		public IQueryable<ServiceItem> GetServiceItems() => _context.ServiceItems;

		public ServiceItem GetServiceItemById(Guid id) => _context.ServiceItems.FirstOrDefault(x => x.Id == id);

		public void SaveServiceItem(ServiceItem entity)
		{
			if (entity.Id == default)
				_context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
			else
				_context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

			_context.SaveChanges();
		}

		public void DeleteServiceItem(Guid id)
		{
			ServiceItem entity = _context.ServiceItems.FirstOrDefault(x => x.Id == id);

			if (entity != null)
				_context.ServiceItems.Remove(entity);
			else
				throw new ArgumentException("Ошибка удаления. Услуга не существует");

			_context.SaveChanges();
		}

	}
}
