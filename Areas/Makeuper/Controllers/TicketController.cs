using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
using Domains;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NobatOnline.Areas.Makeuper.Models;

namespace NobatOnline.Areas.Makeuper.Controllers
{
    [Area("Makeuper")]
    [Authorize(Roles = Utilities.RoleNames.Beautify)]

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
        public IActionResult List()
        {
            // var List = Context.Tickets.Select(p => new {
            //     p.Id,
            //     p.Time,
            //     BeautyName =p.Beauty.BeautyName,
            //     p.Date,
            //     p.DayName }).ToList();
            // ListTicketModel model = new ListTicketModel();
            // foreach (var item in List)
            // {
            //     model.List.Add(new ListTicketItemModel
            //     {
            //         Id=item.Id,
            //         Date=item.Date,
            //         DayName=item.DayName,
            //         BeautyName=item.BeautyName,
            //         Time=item.Time
            //     });
            // }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Create(int? Id)
        {
            TicketModel model = new TicketModel();
            if (Id.HasValue)
            {
                var user = await userManager.FindByNameAsync(User.Identity.Name);

            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(TicketModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var tickets = new List<Ticket>();

            DateTime miladi = DateTime.Now;

            TimeSpan startTime = TimeSpan.Parse(model.StartTime);
            TimeSpan endTime = TimeSpan.Parse(model.EndTime);

            DateTime start = new DateTime(miladi.Year, miladi.Month, miladi.Day, startTime.Hours, startTime.Minutes, 00);
            DateTime end = new DateTime(miladi.Year, miladi.Month, miladi.Day, endTime.Hours, endTime.Minutes, 00);
            DateTime temp = start;
            temp = temp.AddMinutes(model.SplitTime);
            while (temp < end)
            {
                tickets.Add(new Ticket
                {
                    BeautyId = model.BeautyId,
                    Date = DateTime.Today,
                    StartTime = temp.Hour + ":" + temp.Minute,
                    EndTime = temp.Hour + ":" + temp.Minute,
                    SplitTime = model.SplitTime
                });
                temp = temp.AddMinutes(model.SplitTime);
            }
            return Json(tickets);
        }
        [NonAction]
        public void PreipaerBeauty(List<SelectListItem> model)
        {
            var beauty = Context.Beauties.Select(p => new { p.Id, p.BeautyName }).ToList();
            foreach (var item in beauty)
            {
                model.Add(new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.BeautyName
                });
            }
        }
    }
}