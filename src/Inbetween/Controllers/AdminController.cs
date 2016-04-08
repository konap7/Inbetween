using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Inbetween.ViewModels;
using Inbetween.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Inbetween.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        IIndexRepository indexRepository;
        INewsRepository newsRepository;
        IAlbumsRepository albumsRepository;
        UserManager<IdentityUser> userManager;
        SignInManager<IdentityUser> signInManager;
        IdentityDbContext context;

        public AdminController(IIndexRepository indexRepository, INewsRepository newsRepository, IAlbumsRepository albumsRepository, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IdentityDbContext context)
        {
            this.indexRepository = indexRepository;
            this.newsRepository = newsRepository;
            this.albumsRepository = albumsRepository;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var model = indexRepository.GetIndexVMAdmin();
            return View(model);
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        public IActionResult AddNews()
        {
            return View();
        }

        public IActionResult AddAlbum()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAlbum(AddAlbumVM newAlbum)
        {
            albumsRepository.AddAlbum(newAlbum);
            return RedirectToAction(nameof(AdminController.Index));
        }

        [HttpPost]
        public IActionResult AddNews(AddNewsVM newNews)
        {
            newsRepository.AddNews(newNews);
            return RedirectToAction(nameof(AdminController.Index));
        }

        [HttpPost]
        public IActionResult DeleteNewsPost(int id)
        {
            newsRepository.DeleteNewsPost(id);
            return RedirectToAction(nameof(AdminController.Index));
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            //await context.Database.EnsureCreatedAsync();

            var result = await userManager.CreateAsync(
                new IdentityUser(viewModel.Username), viewModel.Password);

            if (!result.Succeeded)
            {
                ModelState.AddModelError(nameof(SignUpVM.Username),
                    result.Errors.First().Description);

                return View(viewModel);
            }
            return RedirectToAction(nameof(AccountController.Login));
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            await signInManager.PasswordSignInAsync(
                viewModel.Username, viewModel.Password, false, false);

            return RedirectToAction(nameof(AdminController.Index));
        }

        public async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
