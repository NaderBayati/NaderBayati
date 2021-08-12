using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
using Domains;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NobatOnline.Areas.Makeuper.Models;

namespace NobatOnline.Areas.Makeuper.Controllers
{
    [Area("Makeuper")]
    public class TicketController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<AppRole> roleManager;
        private readonly NobatOnlineContext Context;
        public TicketController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, NobatOnlineContext _Context)
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
        public  IActionResult List()
        {
            var List = Context.Tickets.Select(p => new {
                p.Id,
                p.Time,
                BeautyName =p.Beauty.BeautyName,
                p.Date,
                p.DayName }).ToList();
            ListTicketModel model = new ListTicketModel();
            foreach (var item in List)
            {
                model.List.Add(new ListTicketItemModel
                {
                    Id=item.Id,
                    Date=item.Date,
                    DayName=item.DayName,
                    BeautyName=item.BeautyName,
                    Time=item.Time
                });
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Create(int? Id)
        {
            TicketModel model = new TicketModel();
            if (Id.HasValue)
            {
                var Customeruser = await userManager.FindByNameAsync(User.Identity.Name);
                Ticket ticket = new Ticket();
               
            }
            return View();
        }
        [NonAction]
        public void PreipaerBeauty(List<SelectListItem> model)
        {
            var beauty = Context.Beauties.Select(p => new { p.Id, p.BeautyName }).ToList();
            foreach (var item in beauty)
            {
                model.Add(new SelectListItem
                {
                    Value=item.Id.ToString(),
                    Text=item.BeautyName
                });
            }
        }
    }
}