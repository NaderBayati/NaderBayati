using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Domains;
using NobatOnline.Areas.Customer.Models;
using DataLayer;
using Microsoft.AspNetCore.Identity;

namespace NobatOnline.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize(Roles =Utilities.RoleNames.Customer)]
    public class HomeController : Controller
    {
         private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<AppRole> roleManager;
        private readonly NobatOnlineContext Context;
        public HomeController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager,  NobatOnlineContext _Context)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
           
            this.Context = _Context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
         [HttpGet]
        public IActionResult Register()
        {
            CustomerModel model = new CustomerModel();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Register(CustomerModel model)
        {
           
            if (ModelState.IsValid)
                {
                    var checkUser=await userManager.FindByNameAsync(model.UserName);
                    if(checkUser!=null){
                        ModelState.AddModelError("","شما قبلا ثبت نام کرده اید");
                        return View(model);
                    }
                    if(model.NationalCode.CheckCodeMeli())
                    {
                         AppUser user=new AppUser();
                         user.FirstName=model.FirstName;
                         user.LastName = model.LastName;
                         user.Active = true;
                         user.PhoneNumber = model.PhoneNumber;
                         user.UserName = model.UserName;
                         user.CodeMeli = model.NationalCode;
                         
                         var result=await userManager.CreateAsync(user,model.Password);
                         if(result.Succeeded)
                         {
                             await userManager.AddToRoleAsync(user,"Customer");
                             TempData["Massage"]="Success";
                             return Redirect("~/Customer/Home/LoginCustomer");
                         }
                         else
                         {
                                foreach(var item in result.Errors)
                                {
                                    ModelState.AddModelError(string.Empty,item.Description);
                                }
                                return View(model);
                         }
                    }
                    else{
                        ModelState.AddModelError("NationalCode","کد ملی وارد شده معتبر نیست");
                        return View(model);
                    }
                }
                 else
                    {
                         return View(model);
                    }
        
        }
    }
}