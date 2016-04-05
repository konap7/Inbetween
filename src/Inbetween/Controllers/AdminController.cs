using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Inbetween.ViewModels;
using Inbetween.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Inbetween.Controllers
{
    public class AdminController : Controller
    {
        INewsRepository repository;

        public AdminController(INewsRepository repository)
        {
            this.repository = repository;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddNews()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNews(AddNewsVM newNews)
        {
            repository.AddNews(newNews);
            return RedirectToAction(nameof(AdminController.Index));
        }
    }
}
