using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataLayer;
using NobatOnline.Areas.Customer.Models;
using Domains;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
namespace NobatOnline.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize(Roles =Utilities.RoleNames.Customer)]
    public class CustomerController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<AppRole> roleManager;
        private readonly NobatOnlineContext Context;
        public CustomerController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager,  NobatOnlineContext _Context)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
           
            this.Context = _Context;
        }
        public IActionResult Index()
        {
            return RedirectToAction("List");
        }
        
        [HttpGet]
        public async Task<IActionResult> List()
        {
            ListCustomerModel model = new ListCustomerModel();
            var customer = userManager.Users.ToList();
            foreach (var item in customer)
            {
                if(await userManager.IsInRoleAsync(item, "Customer"))
                {
                    model.List.Add(new ListCustomerItemModel
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
        
    }
}