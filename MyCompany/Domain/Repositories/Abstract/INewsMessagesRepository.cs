using MyCompany.Domain.Entities;
using System;
using System.Linq;

namespace MyCompany.Domain.Repositories.Abstract
{
	public interface INewsMessagesRepository
	{
		IQueryable<NewsMessage> GetNewsMessages();
		NewsMessage GetNewsMessageById(Guid id);
		void SaveNewsMessage(NewsMessage entity);
		void DeleteNewsMessage(Guid id);
	}
}
