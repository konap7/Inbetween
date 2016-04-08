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
        IIndexRepository indexRepository;
        INewsRepository newsRepository;
        IAlbumsRepository albumsRepository;

        public HomeController(IIndexRepository indexRepository, INewsRepository newsRepository, IAlbumsRepository albumsRepository, IdentityDbContext context)
        {
            this.indexRepository = indexRepository;
            this.newsRepository = newsRepository;
            this.albumsRepository = albumsRepository;
            this.context = context;
        }

        public IActionResult AllNews()
        {
            var model = newsRepository.GetAll();
            return View(model);
        }

        public IActionResult AllAlbums()
        {
            var model = albumsRepository.GetAllAlbums();
            return View(model);
        }

        //IAlbumsRepository albumsRepository;
        //public HomeController(IAlbumsRepository repository, IdentityDbContext context)
        //{
        //    this.context = context;
        //    albumsRepository = repository;
        //}

        //INewsRepository repository;
        //public HomeController(INewsRepository repository, IdentityDbContext context)
        //{
        //    this.context = context;
        //    this.repository = repository;
        //}

        //GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            await context.Database.EnsureCreatedAsync();
            var model = indexRepository.GetIndexVM();
            return View(model);
        }
        [HttpPost]
        public IActionResult SendAnEmail(MailSenderVM mailSenderVMThing) // Lägg in en VM för det!
        {
            MailSender mail = new MailSender();
            mail.SendMail(mailSenderVMThing.Name, mailSenderVMThing.Subject, mailSenderVMThing.Email, mailSenderVMThing.Message); //From, Subject, Email, Text
            return RedirectToAction(nameof(HomeController.Index));
        }
    }
}
