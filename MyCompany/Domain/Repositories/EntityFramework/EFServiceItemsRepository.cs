using MyCompany.Domain.Enities;
using MyCompany.Domain.Repositories.Abstract;
using System;
using System.Linq;

namespace MyCompany.Domain.Repositories.EntityFramework
{
	public class EFServiceItemsRepository : IServiceItemsRepository
	{
		private readonly AppDbContext context;
		public EFServiceItemsRepository(AppDbContext context)
		{
			this.context = context;
		}

		public IQueryable<ServiceItem> GetServiceItems()
		{
			return context.ServiceItems;
		}

		public ServiceItem GetTServiceItemById(Guid id)
		{
			return context.ServiceItems.FirstOrDefault(x => x.Id == id);
		}

		public void SaveServiceItem(ServiceItem entity)
		{
			if (entity.Id == default)
			{
				context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
			}
			else
			{
				context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			}
			context.SaveChanges();
		}

		public void DeleteServiceItem(Guid id)
		{
			context.ServiceItems.Remove(new ServiceItem() { Id = id });
			context.SaveChanges();
		}

	}
}
