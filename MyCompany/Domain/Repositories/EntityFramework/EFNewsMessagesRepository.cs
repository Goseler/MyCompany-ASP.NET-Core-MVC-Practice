using MyCompany.Domain.Entities;
using MyCompany.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Domain.Repositories.EntityFramework
{
	public class EFNewsMessagesRepository : INewsMessagesRepository
	{
		private readonly AppDbContext _context;
		public EFNewsMessagesRepository(AppDbContext context)
		{
			_context = context;
		}
		public IQueryable<NewsMessage> GetNewsMessages()
		{
			return _context.NewsMessages;
		}

		public NewsMessage GetNewsMessageById(Guid id)
		{
			return _context.NewsMessages.FirstOrDefault(x => x.Id == id);
		}

		public void SaveNewsMessage(NewsMessage entity)
		{
			_context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
			_context.SaveChanges();
		}

		public void DeleteNewsMessage(Guid id)
		{
			NewsMessage newsMessage = GetNewsMessageById(id);

			if(newsMessage != null)
			{
				if (newsMessage.TitleImagePath != null)
				{
					FileInfo file = new FileInfo(newsMessage.TitleImagePath);
					if (file.Exists)
						file.Delete();
				}
				_context.Remove(newsMessage);
			}
			else
				throw new ArgumentException("Ошибка удаления. Новость не существует");

			_context.SaveChanges();
		}
	}
}
