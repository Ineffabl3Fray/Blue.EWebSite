using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blue.EWebSite.WebUI.Identity;
using Blue.EWebSite.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blue.EWebSite.WebUI.Controllers
{
    public class SecurityController : Controller
    {
        private UserManager<AppIdentityUser> _userManager;
        private RoleManager<AppIdentityRole> _roleManager;
        private SignInManager<AppIdentityUser> _signInManager;

        public SecurityController(UserManager<AppIdentityUser> userManager, RoleManager<AppIdentityRole> roleManager, SignInManager<AppIdentityUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppIdentityUser appIdentityUser = new AppIdentityUser
                {
                    Email = model.Email,
                     UserName = model.UserName
                };
                IdentityResult result = _userManager.CreateAsync(appIdentityUser, model.Password).Result;
                if (result.Succeeded)
                {
                    if (!_roleManager.RoleExistsAsync("Admin").Result)
                    {
                        AppIdentityRole appIdentityRole = new AppIdentityRole
                        {
                            Name = "Admin"
                        };
                        IdentityResult roleResult = _roleManager.CreateAsync(appIdentityRole).Result;
                        if (!roleResult.Succeeded)
                        {
                            ModelState.AddModelError("", "We can't add the role!");
                            return View(model);
                        }
                    }
                    _userManager.AddToRoleAsync(appIdentityUser, "Admin");
                    return RedirectToAction("Login", "Security");
                }
            }
            return View(model);
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false).Result;
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            _signInManager.SignOutAsync().Wait();
            return RedirectToAction("Login");
        }
    }
}