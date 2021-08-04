using MyCompany.Domain.Enities;
using MyCompany.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Domain.Repositories.EntityFramework
{
	public class EFTextFieldsRepository : ITextFieldsRepository
	{
		private readonly AppDbContext context;
		public EFTextFieldsRepository(AppDbContext context)
		{
			this.context = context;
		}

		public IQueryable<ServiceItems> GetTextFields()
		{
			return context.TextFields;
		}

		public ServiceItems GetTextFieldById(Guid id)
		{
			return context.TextFields.FirstOrDefault(x => x.Id == id);
		}

		public ServiceItems GetTextFieldByCodeWord(string codeword)
		{
			return context.TextFields.FirstOrDefault(x => x.CodeWord == codeword);
		}

		public void SaveTextField(ServiceItems entity)
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

		public void DeleteTextField(Guid id)
		{
			context.TextFields.Remove(new ServiceItems() { Id = id });
			context.SaveChanges();
		}
	}
}
