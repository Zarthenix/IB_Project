using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Start.Context;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Start.Models;
using Start.Repository;
using Microsoft.AspNetCore.Authorization;

namespace Start.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<BaseAccount> _userManager;
        private readonly SignInManager<BaseAccount> _signInManager;
        private AuthRepository authRepo;


        public HomeController
            (SignInManager<BaseAccount> signInManager,
            UserManager<BaseAccount> userManager,
            AuthRepository authRepo)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this.authRepo = authRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Login()
        {
            LoginViewModel lv = new LoginViewModel();

            return View(lv);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel user)
        {
            IActionResult retval = null;

            if (ModelState.IsValid)
            {
                bool result = await authRepo.Login(user);

                if (result)
                    retval = RedirectToAction("Index");
                else
                    retval = RedirectToAction("Login");
            }
            else retval = RedirectToAction("Login");

            return retval;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            if (HttpContext.User?.Identity.IsAuthenticated == true)
            {
                await _signInManager.SignOutAsync();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Register()
        {
            RegisterViewModel rv = new RegisterViewModel();

            return View(rv);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerView)
        {
            IActionResult retval = View();

            if (ModelState.IsValid)
            {
                bool result = await authRepo.Register(registerView, "Customer");

                if (result)
                {
                    try
                    {
                        await _signInManager.PasswordSignInAsync(registerView.Username, registerView.Password, false, false);
                        retval = RedirectToAction("Home", "Index");
                    }
                    catch (Exception)
                    {
                        retval = RedirectToAction("Home", "Login");
                    }
                }
                else
                {
                    ViewData["Error"] = "An error has occured.";
                }
            }
            return retval;
        }
    }
}
