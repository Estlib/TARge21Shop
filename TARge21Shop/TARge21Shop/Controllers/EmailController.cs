using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;
using TARge21Shop.Core.ServiceInterface;
using TARge21Shop.ApplicationServices.Services;
using TARge21Shop.Core.Dto;
using TARge21Shop.Models.Email;

namespace TARge21Shop.Controllers
{
    public class EmailController : Controller
    {
        private readonly IEmailsServices _emailsServices;

        public EmailController(IEmailsServices emailsServices) 
        {
            _emailsServices = emailsServices;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendEmail(EmailViewModel vm)
        {

            var dto = new EmailDto()
            {
                To = vm.To,
                Subject = vm.Subject,
                Body = vm.Body,
            };

            _emailsServices.SendEmail(dto);

            return RedirectToAction(nameof(Index));
        }
    }
}
