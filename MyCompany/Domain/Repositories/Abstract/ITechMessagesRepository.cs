using MyCompany.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Domain.Repositories.Abstract
{
    public interface ITechMessagesRepository
    {
        IQueryable<TechMessage> GetTechMessages();
        TechMessage GetTechMessageById(Guid id);
        void SaveTechMessage(TechMessage entity);
        void DeleteTechMessage(Guid id);
    }
}
