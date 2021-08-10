using MyCompany.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Domain.Repositories.Abstract
{
    public interface INewsMessagesRepository
    {
        IQueryable<NewsMessage> GetNewsMessages();
        NewsMessage GetNewsMessageById(Guid id);
        void SaveNewsMessage(NewsMessage entity);
        void DeleteNewsMessage(Guid id);
    }
}
