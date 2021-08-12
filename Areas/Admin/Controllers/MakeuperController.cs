using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataLayer;
using NobatOnline.Areas.Admin.Models;
using Domains;
using Microsoft.AspNetCore.Identity;

namespace NobatOnline.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MakeuperController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<AppRole> roleManager;
        private readonly NobatOnlineContext Context;
        public MakeuperController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager,  NobatOnlineContext _Context)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
           
            this.Context = _Context;
        }
        [HttpGet]
        public IActionResult Register()
        {
            MakeuperModel model = new MakeuperModel();
            return View(model);
        }
        public IActionResult Index()
        {
            return RedirectToAction("List");
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            ListMakeuperModel model = new ListMakeuperModel();
            var makeuper = userManager.Users.ToList();
            foreach (var item in makeuper)
            {
                if(await userManager.IsInRoleAsync(item, "Makeuper"))
                {
                    model.List.Add(new ListMakeuperItemModel
                    {
                        Id=item.Id,
                        FirstName=item.FirstName,
                        LastName=item.LastName,
                        NationalCode=item.CodeMeli,
                        PhoneNumber=item.PhoneNumber,
                        IsActive=(item.Active) ? "check" : "close",
                        UserName=item.UserName
                    });
                }
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Register(MakeuperModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.NationalCode.CheckCodeMeli())
                {
                    AppUser user = new AppUser();
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.Active = true;
                    user.PhoneNumber = model.PhoneNumber;
                    user.UserName = model.UserName;
                    user.CodeMeli = model.NationalCode;
                    var result = await userManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, "Makeuper");
                        TempData["Massage"] = "Success";
                        return Redirect("/Admin/Makeuper/List");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, item.Description);
                        }
                        return View(model);
                    }
                }
                else
                {
                    ModelState.AddModelError("NationalCode", UserValidation.InvalidNationalCode);
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