using MyCompany.Domain.Entities;
using MyCompany.Domain.Repositories.Abstract;
using System;
using System.Linq;

namespace MyCompany.Domain.Repositories.EntityFramework
{
	public class EFTechMessagesRepository : ITechMessagesRepository
	{
		private readonly AppDbContext _context;

		public EFTechMessagesRepository(AppDbContext context) => _context = context;

		public IQueryable<TechMessage> GetTechMessages() => _context.TechMessages;

		public TechMessage GetTechMessageById(Guid id) => _context.TechMessages.FirstOrDefault(x => x.Id == id);


		public void SaveTechMessage(TechMessage entity)
		{
			_context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
			_context.SaveChanges();
		}

		public void DeleteTechMessage(Guid id)
		{
			TechMessage entity = _context.TechMessages.FirstOrDefault(x => x.Id == id);

			if (entity != null)
				_context.TechMessages.Remove(entity);
			else
				throw new ArgumentException("Ошибка удаления. Сообщение не существует");

			_context.SaveChanges();
		}
	}
}
