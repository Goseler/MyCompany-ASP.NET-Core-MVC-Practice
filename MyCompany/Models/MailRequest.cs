using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Models
{
    public class MailRequest
    {
        [Display(Name = "Email пользователя")]
        [DataType(DataType.EmailAddress)]
        public string ToEmail { get; set; }
        [Display(Name = "Тема сообщения")]
        public string Subject { get; set; }
        [Display(Name = "Текст пользователя")]
        [DataType(DataType.MultilineText)]
        public string UserBody { get; set; }
        [Display(Name = "Титульная картинка")]
        public string TitleImagePath { get; set; }
        [Display(Name = "Текст сообщения")]
        public string ResponseBody { get; set; }
        [Display(Name = "Дата отправки")]
        [DataType(DataType.DateTime)]
        public DateTime DateSent { get; set; }
    }
}
