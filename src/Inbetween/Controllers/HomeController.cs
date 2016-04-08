using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
//using KickAss2.ViewModels;
using Microsoft.AspNet.Mvc.Rendering;
//using KickAss2.Models;
using Microsoft.AspNet.Http;
using Inbetween.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Inbetween.ViewModels;

namespace Inbetween.Controllers
{
    public class HomeController : Controller
    {
        //public IActionResult Index()
        //{
        //    var model = repository.GetTop3();
        //    return View(model);
        //}

        IdentityDbContext context;

        public IActionResult AllNews()
        {
            var model = repository.GetAll();
            return View(model);
        }

        INewsRepository repository;
        public HomeController(INewsRepository repository, IdentityDbContext context)
        {
            this.context = context;
            this.repository = repository;
        }

        //GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            await context.Database.EnsureCreatedAsync();
            var model = repository.GetIndexVM();
            return View(model);
        }
        [HttpPost]
        public IActionResult SendAnEmail(MailSenderVM mailSenderVMThing) // Lägg in en VM för det!
        {
            MailSender mail = new MailSender();
            mail.SendMail(mailSenderVMThing.Name, mailSenderVMThing.Subject, mailSenderVMThing.Email, mailSenderVMThing.Message); //From, Subject, Email, Text
            ViewData["mail_succes"] = "The email was succefully sent!";
            return RedirectToAction(nameof(HomeController.Index));
        }

        public IActionResult Album()
        {
            return View();
        }
    }
}
