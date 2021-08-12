using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
using Domains;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NobatOnline.Areas.Admin.Models;
namespace NobatOnline.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CustomerController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<AppRole> roleManager;
        private readonly NobatOnlineContext Context;
        public CustomerController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, NobatOnlineContext _Context)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;

            this.Context = _Context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}