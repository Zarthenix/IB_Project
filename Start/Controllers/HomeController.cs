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
            return View();
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
        public async Task<IActionResult> Login(string username, string password)
        {
            if (HttpContext.User?.Identity.IsAuthenticated == true)
            {
                await signInManager.SignOutAsync();
            }
            ViewData["msg"] = "";
            if (username != null)
            {
                var result = await signInManager.PasswordSignInAsync(username, password, false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    if (HttpContext.User.IsInRole("Admin"))
                    {
                        ViewData["msg"] = "admin";
                        
                    }
                    else if (HttpContext.User.IsInRole("Employee"))
                    {
                        ViewData["msg"] = "employee";
                    }
                    else if (HttpContext.User.IsInRole("Customer"))
                    {
                        ViewData["msg"] = "customer";
                    }
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
    }
}
