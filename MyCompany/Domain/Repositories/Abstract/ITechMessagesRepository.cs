using MyCompany.Domain.Entities;
using System;
using System.Linq;

namespace MyCompany.Domain.Repositories.Abstract
{
	public interface ITechMessagesRepository
	{
		IQueryable<TechMessage> GetTechMessages();
		TechMessage GetTechMessageById(Guid id);
		void SaveTechMessage(TechMessage entity);
		void DeleteTechMessage(Guid id);
	}
}
