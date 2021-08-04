using MyCompany.Domain.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Domain.Repositories.Abstract
{
    public interface ITextFieldsRepository
    {
        IQueryable<ServiceItems> GetTextFields();
        ServiceItems GetTextFieldById(Guid id);
        ServiceItems GetTextFieldByCodeWord(string codeword);
        void SaveTextField(ServiceItems entity);
        void DeleteTextField(Guid id);
    }
}
