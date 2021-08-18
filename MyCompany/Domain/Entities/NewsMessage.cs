using System.ComponentModel.DataAnnotations;

namespace MyCompany.Domain.Entities
{
	public class NewsMessage : EntityBase
	{
		[Required(ErrorMessage = "Заполните название новости")]
		[Display(Name = "Название новости")]
		public override string Title { get; set; }

		[Display(Name = "Краткое описание новости")]
		public override string Subtitle { get; set; }

		[Display(Name = "Полное описание новости")]
		public override string Text { get; set; }

		[Display(Name = "Текст рецензии")]
		public string ResponsetText { get; set; } = "Ваша новость была одобрена администрацией компании.";

		[Required(ErrorMessage = "Email не указан")]
		[EmailAddress(ErrorMessage = "Неверный Email")]
		[Display(Name = "Email")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }
	}
}
