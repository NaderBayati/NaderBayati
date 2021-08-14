using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NobatOnline.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles =Utilities.RoleNames.Administrator)]

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}