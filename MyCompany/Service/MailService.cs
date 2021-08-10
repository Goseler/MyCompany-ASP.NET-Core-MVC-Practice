using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using MyCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Service
{
    public class MailService : IMailService
    {
        //private readonly ResponseData responseData;
        private readonly ILogger<MailService> _logger;

        //      public EmailService(/*ResponseData responseData, ILogger<EmailService> logger*/)
        //{
        //	this.responseData = responseData;
        //          this.logger = logger;
        //}

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
                System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
                message.IsBodyHtml = true; //тело сообщения в формате HTML
                message.From = new MailAddress(_mailSettings.Mail, _mailSettings.DisplayName); //отправитель сообщения
                message.To.Add(mailRequest.ToEmail); //адресат сообщения
                message.Subject = mailRequest.Subject; //тема сообщения
                message.Body = new string("<div>" + mailRequest.ResponseBody + "<br/>" + mailRequest.DateSent.ToString("MMM , dd, yyyy") + "<br/><br/><br/>" + "</div>" + mailRequest.UserBody); //тело сообщения
                message.Attachments.Add(new Attachment(mailRequest.TitleImagePath)); //добавить вложение к письму при необходимости
                //var builder = new BodyBuilder();

                using (System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(_mailSettings.Host)) //используем сервера Advantiss
                {
                    client.Credentials = new NetworkCredential(_mailSettings.Mail, _mailSettings.Password); //логин-пароль от аккаунта
                    client.Port = _mailSettings.Port; //порт 587 либо 465
                    //client.EnableSsl = true; //SSL обязательно

                    await client.SendMailAsync(message);
                    _logger.LogInformation("Сообщение отправлено успешно!");
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.GetBaseException().Message);
            }
        }
    }
}
