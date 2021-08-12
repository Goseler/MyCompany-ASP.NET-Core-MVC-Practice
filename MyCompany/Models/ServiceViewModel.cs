using MyCompany.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Models
{
    public class ServiceViewModel
    {
        public IEnumerable<ServiceItem> ServiceItems { get; set; }
        public TextField TextField { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
