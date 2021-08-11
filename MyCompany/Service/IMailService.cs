using MyCompany.Models;
using System.Threading.Tasks;

namespace MyCompany.Service
{
	public interface IMailService
	{
		Task SendEmailAsync(MailRequest mailRequest);
	}
}
