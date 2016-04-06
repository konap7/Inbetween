using Inbetween.ViewModels;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inbetween.Controllers
{
    public class AccountController : Controller
    {
        UserManager<IdentityUser> userManager;
        SignInManager<IdentityUser> signInManager;
        IdentityDbContext context;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IdentityDbContext context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return Content("If you see this - you are logged in...");
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

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

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            await signInManager.PasswordSignInAsync(
                viewModel.Username, viewModel.Password, false, false);

            return RedirectToAction("index", "home");
        }

        public async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }

        //[AllowAnonymous]
        //public IActionResult Login()
        //{
        //    return View();
        //}

        //[AllowAnonymous]
        //[HttpPost]
        //public async Task<IActionResult> Login(LoginVM viewModel)
        //{
        //    if (!ModelState.IsValid)
        //        return View(viewModel);

        //    // Skapa DB-schemat
        //    await context.Database.EnsureCreatedAsync();

        //    // Skapa användaren
        //    var result = await userManager.CreateAsync(new IdentityUser(viewModel.Username), viewModel.Password);

        //    // Visa eventuellt felmeddelande
        //    if (!result.Succeeded)
        //    {
        //        ModelState.AddModelError(nameof(LoginVM.Username), result.Errors.First().Description);

        //        return View(viewModel);
        //    }

        //    await signInManager.PasswordSignInAsync(viewModel.Username, viewModel.Password, false, false);

        //    return RedirectToAction(nameof(AccountController.Index));
        //}
    }
}
