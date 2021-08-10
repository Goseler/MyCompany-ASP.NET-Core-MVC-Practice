using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Domain.Entities
{
    public class MessageBase
    {
		public MessageBase()
		{
			DateSent = DateTime.UtcNow;
		}

		[Required]
		public Guid Id { get; set; }

		[Display(Name = "Тема сообщения")]
		public virtual string Title { get; set; }

		[Display(Name = "Текст сообщения")]
		public virtual string Text { get; set; }

		[Required(ErrorMessage = "Email не указан")]
		[EmailAddress(ErrorMessage = "Неверный Email")]
		[Display(Name = "Email")]
		[DataType(DataType.EmailAddress)]
		public virtual string Email { get; set; }

		[DataType(DataType.Time)]
		public DateTime DateSent { get; set; }
	}
}
