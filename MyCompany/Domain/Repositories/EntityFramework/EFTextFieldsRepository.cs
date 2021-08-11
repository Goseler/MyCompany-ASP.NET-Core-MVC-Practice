using MyCompany.Domain.Entities;
using MyCompany.Domain.Repositories.Abstract;
using System;
using System.Linq;

namespace MyCompany.Domain.Repositories.EntityFramework
{
	public class EFTextFieldsRepository : ITextFieldsRepository
	{
		private readonly AppDbContext _context;

		public EFTextFieldsRepository(AppDbContext context) => _context = context;

		public IQueryable<TextField> GetTextFields() => _context.TextFields;

		public TextField GetTextFieldById(Guid id) => _context.TextFields.FirstOrDefault(x => x.Id == id);

		public TextField GetTextFieldByCodeWord(string codeword) => _context.TextFields.FirstOrDefault(x => x.CodeWord == codeword);

		public void SaveTextField(TextField entity)
		{
			if (entity.Id == default)
				_context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
			else
				_context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

			_context.SaveChanges();
		}

		public void DeleteTextField(Guid id)
		{
			TextField entity = _context.TextFields.FirstOrDefault(x => x.Id == id);

			if (entity != null)
				_context.TextFields.Remove(entity);
			else
				throw new ArgumentException("Ошибка удаления. Сообщение не существует");

			_context.SaveChanges();
		}
	}
}
