using MyCompany.Domain.Entities;
using System.Linq;

namespace MyCompany.Models
{
	public class NewsViewModel
	{
		public IQueryable<NewsItem> NewsItems { get; set; }
		public TextField TextField { get; set; }
	}
}
