using Microsoft.AspNetCore.Mvc;
using MyCompany.Domain;
using MyCompany.Domain.Entities;
using MyCompany.Models;
using MyCompany.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersMessagesController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IMailService mailService;
        public UsersMessagesController(DataManager dataManager, IMailService mailService)
		{
            this.dataManager = dataManager;
            this.mailService = mailService;
        }

        public IActionResult Index(Guid id)
		{
            TechMessage techMessage = dataManager.TechMessages.GetTechMessageById(id);
            MailRequest entity = new MailRequest() { Subject = techMessage.Title, ToEmail = techMessage.Email, UserBody = techMessage.Text, DateSent=techMessage.DateSent};
            if(entity == null)
			{
                throw new ArgumentException("Сообщение отсутствует");
			}
            return View(entity);
		}

        [HttpPost]
        public async Task<IActionResult> IndexAsync(MailRequest request)
		{
			if (ModelState.IsValid)
			{
                await mailService.SendEmailAsync(request);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(request);
		}

        [HttpPost]
        public IActionResult Delete(Guid id)
		{
            dataManager.TechMessages.DeleteTechMessage(id);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }
    }
}
