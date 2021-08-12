using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Domains;
using Microsoft.AspNetCore.Identity;
using DataLayer;
using System.Threading.Tasks;
using Utilities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using NobatOnline.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Routing;


namespace NobatOnline.Controllers
{
    
    
    public class HomeController : Controller
    {
        private readonly UserManager<AppUser> UserManager;
        private readonly SignInManager<AppUser> SignInManager;
        private readonly NobatOnlineContext Context;
        public HomeController(UserManager<AppUser> UserManager, NobatOnlineContext _Context, SignInManager<AppUser> SignInManager)
        {
            this.UserManager = UserManager;
            this.Context = _Context;
            this.SignInManager = SignInManager;
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            LoginModel model = new LoginModel();
            return View(model);
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await SignInManager.PasswordSignInAsync(model.UserName, model.Password, true, lockoutOnFailure: true);
            if (result.Succeeded)
            {
                var user = await UserManager.FindByNameAsync(model.UserName);
                if (!user.Active)
                {
                    await SignInManager.SignOutAsync();
                    ModelState.AddModelError("Password", "حساب شما فعال نیست");
                    return View(model);
                }
                if (await UserManager.IsInRoleAsync(user, "Makeuper"))
                {
                    return Redirect("/Makeuper/Home ");
                }
                else
                 if (await UserManager.IsInRoleAsync(user, "Administrator"))
                {
                    return Redirect("/Admin/Home/index");
                }
                else if (await UserManager.IsInRoleAsync(user, "Customer"))
                {
                    return Redirect("/Makeuper/Home");
                }
                return new StatusCodeResult(403);
            }
            else if (result.IsLockedOut)
            {
                return LocalRedirect("/Lockout");
            }
            else
            {

                ModelState.AddModelError("Password", "نام کاربری یا کلمه عبور صحیح نیست");
                return View(model);
            }
        }
    }
}