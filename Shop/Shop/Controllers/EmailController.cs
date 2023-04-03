using Microsoft.AspNetCore.Mvc;
using Shop.Models.Email;
using ShopTARgv21.Core.Dto;
using ShopTARgv21.Core.ServiceInterface;
using System.Security.Cryptography.X509Certificates;

namespace Shop.Controllers
{
    public class EmailController : Controller
    {
        private readonly IEmailServices _emailServices;
        public EmailController(IEmailServices emailService)
        {
            _emailServices = emailService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public IActionResult SendEmail (EmailViewModel vm)
        {
            var dto = new EmailDto()
            {
                To = vm.To,
                Subject = vm.Subject,
                Body = vm.Body
            };

            _emailServices.SendEmail(dto);

            return RedirectToAction(nameof(Index));
        }
    }
}
