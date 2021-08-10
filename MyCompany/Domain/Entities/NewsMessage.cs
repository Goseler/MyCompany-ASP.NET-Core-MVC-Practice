using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Domain.Entities
{
    public class NewsMessage : MessageBase
    {
		public NewsMessage()
		{
            DateAdded = DateTime.UtcNow;
		}

        [Required(ErrorMessage = "Заполните название новости")]
        [Display(Name = "Название новости")]
        public override string Title { get; set; }

        [Display(Name = "Краткое описание новости")]
        public string Subtitle { get; set; }

        [Display(Name = "Полное описание новости")]
        public override string Text { get; set; }

        [Display(Name = "Титульная картинка")]
        public string TitleImagePath { get; set; }

        [Display(Name = "SEO метатег Title")]
        public string MetaTitle { get; set; }

        [Display(Name = "SEO метатег Description")]
        public string MetaDescription { get; set; }

        [Display(Name = "SEO метатег Keywords")]
        public string MetaKeywords { get; set; }

        [DataType(DataType.Time)]
        public DateTime DateAdded { get; set; }
    }
}
