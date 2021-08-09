using MyCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Service
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
