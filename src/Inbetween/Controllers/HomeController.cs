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

namespace Inbetween.Controllers
{
    public class HomeController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult AllNews()
        {
            var model = repository.GetAll();
            return View(model);
        }

        INewsRepository repository;
        public HomeController(INewsRepository repository)
        {
            this.repository = repository;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var model = repository.GetTop3();
            return View(model);
        }
    }
}
