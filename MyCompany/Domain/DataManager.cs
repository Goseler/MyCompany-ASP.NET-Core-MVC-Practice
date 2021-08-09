using MyCompany.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Domain
{
    public class DataManager
    {
        public ITextFieldsRepository TextFields { get; set; }
        public IServiceItemsRepository ServiceItems { get; set; }
        public INewsItemsRepository NewsItems { get; set; }
        public ITechMessagesRepository TechMessages { get; set; }

		public DataManager(ITextFieldsRepository textFieldsRepository, IServiceItemsRepository serviceItemsRepository, INewsItemsRepository newsItemsRepository, ITechMessagesRepository techMessagesRepository)
		{
            TextFields = textFieldsRepository;
            ServiceItems = serviceItemsRepository;
            NewsItems = newsItemsRepository;
            TechMessages = techMessagesRepository;
		}
    }
}
