using MyCompany.Domain.Entities;
using System.Collections.Generic;

namespace MyCompany.Models
{
	public class NewsViewModel
	{
		public IEnumerable<NewsItem> NewsItems { get; set; }
		public TextField TextField { get; set; }
		public PageViewModel PageViewModel { get; set; }
	}
}
