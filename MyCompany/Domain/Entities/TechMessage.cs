using System.ComponentModel.DataAnnotations;

namespace MyCompany.Domain.Entities
{
	public class TechMessage : MessageBase
	{
		[Required(ErrorMessage = "Введите тему сообщения")]
		[Display(Name = "Тема сообщения")]
		public override string Title { get; set; }

		[Display(Name = "Текст сообщения")]
		public override string Text { get; set; }
	}
}
