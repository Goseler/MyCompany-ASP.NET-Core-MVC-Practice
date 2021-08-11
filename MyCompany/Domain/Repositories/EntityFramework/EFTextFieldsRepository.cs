using MyCompany.Domain.Entities;
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

		public IQueryable<TextField> GetTextFields()
		{
			return context.TextFields;
		}

		public TextField GetTextFieldById(Guid id)
		{
			return context.TextFields.FirstOrDefault(x => x.Id == id);
		}

		public TextField GetTextFieldByCodeWord(string codeword)
		{
			return context.TextFields.FirstOrDefault(x => x.CodeWord == codeword);
		}

		public void SaveTextField(TextField entity)
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
			TextField entity = context.TextFields.FirstOrDefault(x => x.Id == id);
			if (entity != null)
			{
				context.TextFields.Remove(entity);
			}
			else
			{
				throw new ArgumentException("Ошибка удаления. Сообщение не существует");
			}

			context.SaveChanges();
		}
	}
}
