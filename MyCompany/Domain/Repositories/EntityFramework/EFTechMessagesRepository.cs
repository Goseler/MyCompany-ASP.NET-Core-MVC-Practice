using MyCompany.Domain.Entities;
using MyCompany.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Domain.Repositories.EntityFramework
{
	public class EFTechMessagesRepository : ITechMessagesRepository
	{
		private readonly AppDbContext context;
		public EFTechMessagesRepository(AppDbContext context)
		{
			this.context = context;
		}

		public IQueryable<TechMessage> GetTechMessages()
		{
			return context.TechMessages;
		}

		public TechMessage GetTechMessageById(Guid id)
		{
			return context.TechMessages.FirstOrDefault(x => x.Id == id);
		}

		public void SaveTechMessage(TechMessage entity)
		{
			context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
			context.SaveChanges();
		}

		public void DeleteTechMessage(Guid id)
		{
			TechMessage entity = context.TechMessages.FirstOrDefault(x => x.Id == id);
			if (entity != null)
			{
				context.TechMessages.Remove(entity);
			}
			else
			{
				throw new ArgumentException("Ошибка удаления. Сообщение не существует");
			}
			context.SaveChanges();
		}
	}
}
