using MyCompany.Domain.Entities;
using MyCompany.Domain.Repositories.Abstract;
using System;
using System.Linq;

namespace MyCompany.Domain.Repositories.EntityFramework
{
	public class EFNewsMessagesRepository : INewsMessagesRepository
	{
		private readonly AppDbContext _context;

		public EFNewsMessagesRepository(AppDbContext context) => _context = context;

		public IQueryable<NewsMessage> GetNewsMessages() => _context.NewsMessages;

		public NewsMessage GetNewsMessageById(Guid id) => _context.NewsMessages.FirstOrDefault(x => x.Id == id);

		public void SaveNewsMessage(NewsMessage entity)
		{
			_context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
			_context.SaveChanges();
		}

		public void DeleteNewsMessage(Guid id)
		{
			NewsMessage entity = _context.NewsMessages.FirstOrDefault(x => x.Id == id);

			if (entity != null)
				_context.NewsMessages.Remove(entity);
			else
				throw new ArgumentException("Ошибка удаления. Новость не существует");

			_context.SaveChanges();
		}
	}
}
