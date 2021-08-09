using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
