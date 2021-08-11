using System.ComponentModel.DataAnnotations;

namespace MyCompany.Domain.Entities
{
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
