using MyCompany.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Models
{
    public class NewsViewModel
    {
        public IQueryable<NewsItem> NewsItems { get; set; }
        public TextField TextField { get; set; }
    }
}
