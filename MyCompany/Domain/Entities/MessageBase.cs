using System;
using System.ComponentModel.DataAnnotations;

namespace MyCompany.Domain.Entities
{
	public class MessageBase
	{
		public MessageBase() => DateSent = DateTime.UtcNow;

		[Required]
		public Guid Id { get; set; }

		[Display(Name = "Тема сообщения")]
		public virtual string Title { get; set; }

		[Display(Name = "Текст сообщения")]
		public virtual string Text { get; set; }

		[Required(ErrorMessage = "Email не указан")]
		[DataType(DataType.EmailAddress)]
		[EmailAddress(ErrorMessage = "Неверный Email")]
		[Display(Name = "Email")]
		public virtual string Email { get; set; }

		[DataType(DataType.Time)]
		public DateTime DateSent { get; set; }
	}
}
