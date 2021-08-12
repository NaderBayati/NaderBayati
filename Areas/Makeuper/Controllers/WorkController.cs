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
    public class WorkController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<AppRole> roleManager;
        private readonly NobatOnlineContext Context;
        public WorkController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, NobatOnlineContext _Context)
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
            var List = Context.Works.Select(p => new {
                p.Id, p.Price, p.Onvan, BeautyName = p.Beauty.BeautyName
            }).ToList();
            ListWorkModel model = new ListWorkModel();
            foreach (var item in List)
            {
                model.List.Add(new ListWorkitemModel
                {
                    Id = item.Id,
                    BeautyName = item.BeautyName,
                    Price = item.Price,
                    Onvan = item.Onvan
                });
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            WorkModel model = new WorkModel();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(WorkModel model)
        {
            if (ModelState.IsValid)
            {
                Work work = new Work();
                work.BeautyId = model.BeautyId;
                work.Id = model.Id;
                work.Price = model.Price;
                work.Onvan = model.onvan;
                await Context.Works.AddAsync(work);
                await Context.SaveChangesAsync();

            }
            PrepairBeauty(model.Beauty);
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult>  Remove(int Id)
        {
            var work =await Context.Works.FindAsync(Id);
             Context.Works.Remove(work);
            await Context.SaveChangesAsync();
            return RedirectToAction("List");
        }
        [NonAction]
        public void PrepairBeauty(List<SelectListItem> model)
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