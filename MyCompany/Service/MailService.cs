using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MyCompany.Models;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace MyCompany.Service
{
	public class MailService : IMailService
	{
		private readonly ILogger<MailService> _logger;
		private readonly MailSettings _mailSettings;

		public MailService(IOptions<MailSettings> mailSettings, ILogger<MailService> logger)
		{
			_mailSettings = mailSettings.Value;
			_logger = logger;
		}

		public async Task SendEmailAsync(MailRequest mailRequest)
		{
			try
			{
				MailMessage message = new()
				{
					IsBodyHtml = true, //тело сообщения в формате HTML
					From = new MailAddress(_mailSettings.Mail, _mailSettings.DisplayName) //отправитель сообщения
				};
				message.To.Add(mailRequest.ToEmail); //адресат сообщения
				message.Subject = mailRequest.Subject; //тема сообщения
				message.Body = new string("<div>" + mailRequest.ResponseBody + "<br/>" + mailRequest.DateSent.ToString("MMM , dd, yyyy") + "<br/><br/><br/>" + "</div>" + mailRequest.UserBody); //тело сообщения
				message.Attachments.Add(new Attachment(mailRequest.TitleImagePath)); //добавить вложение к письму при необходимости
																					 //var builder = new BodyBuilder();

				using SmtpClient client = new(_mailSettings.Host); //используем сервера Advantiss
				client.Credentials = new NetworkCredential(_mailSettings.Mail, _mailSettings.Password); //логин-пароль от аккаунта
				client.Port = _mailSettings.Port; //порт 587 либо 465
												  //client.EnableSsl = true; //SSL обязательно

				await client.SendMailAsync(message);
				_logger.LogInformation("Сообщение отправлено успешно!");
			}
			catch (Exception e)
			{
				_logger.LogError(e.GetBaseException().Message);
			}
		}
	}
}
