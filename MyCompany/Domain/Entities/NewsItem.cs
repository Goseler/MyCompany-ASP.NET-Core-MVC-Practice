using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCompany.Domain.Entities
{
	[Index(nameof(Title), IsUnique = true)]
	public class NewsItem : EntityBase
	{
		[Required(ErrorMessage = "Заполните название новости")]
		[Display(Name = "Название новости")]
		public override string Title { get; set; }

		[Display(Name = "Краткое описание новости")]
		public override string Subtitle { get; set; }

		[Display(Name = "Полное описание новости")]
		public override string Text { get; set; }
	}
}
