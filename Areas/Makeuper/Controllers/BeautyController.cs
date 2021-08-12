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
    [Authorize(Roles =Utilities.RoleNames.Beautify)]
    public class BeautyController : Controller
    {

        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<AppRole> roleManager;
        private readonly NobatOnlineContext Context;
        public BeautyController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, NobatOnlineContext _Context)
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
            var _listBeauty = Context.Beauties.Select(p =>  new {p.Id,p.BeautyName,CityName=p.City.Name,p.Phone,p.Address}).ToList();
            ListBeautyModel model = new ListBeautyModel();
            foreach (var item in _listBeauty)
            {
                model.List.Add(new ListBeautyItemModel
                {
                    Id=item.Id,
                    Phone=item.Phone,
                    Address=item.Address,
                    BeautyName=item.BeautyName,
                    CityName = item.CityName
                });
            }
            return View(model);
        }
        [HttpGet]
        public  IActionResult Create()
        {
            BeautyModel model = new BeautyModel();
            PrepairCity(model.City);
            return View(model);  
        }
        [HttpPost]
        public async Task<IActionResult> Create(BeautyModel model)
        {
            if (ModelState.IsValid)
            {
                var test = User;
                var Beautyuser = await userManager.FindByNameAsync(User.Identity.Name);
                Beauty beauty = new Beauty();
                beauty.AppUserId = Beautyuser.Id;
                beauty.BeautyName = model.BeautyName;
                beauty.Address = model.Address;
                beauty.Phone = model.Phone;
                beauty.CityId = model.CityId ;
                await Context.Beauties.AddAsync(beauty);
                await Context.SaveChangesAsync();

            }
            PrepairCity(model.City);
            return View(model);
        }
        [NonAction]
        public void PrepairCity(List<SelectListItem> model)
        {
            var city = Context.Cities.Select(p => new { p.Id, p.Name }).ToList();
            foreach (var item in city)
            {
                model.Add(new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.Name
                });
            }
        }
    }
}