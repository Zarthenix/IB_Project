using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Start.Models;

namespace Start.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<BaseAccount> userManager;
        private readonly SignInManager<BaseAccount> signInManager;

        public HomeController(SignInManager<BaseAccount> signInManager, UserManager<BaseAccount> userManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
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

        public IActionResult Login()
        {
            LoginViewModel lv = new LoginViewModel();

            return View(lv);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            if (HttpContext.User?.Identity.IsAuthenticated == true)
            {
                await signInManager.SignOutAsync();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(user.Username, user.Password, user.Remember, lockoutOnFailure: false);
                Debug.WriteLine(user.Remember);
                if (result.Succeeded)
                {

                }
                else
                {
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Index");
            }
          
            else
            {
                return View();
            }
        }
    }
}
