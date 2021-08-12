using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataLayer;
using NobatOnline.Areas.Makeuper.Models;
using Domains;
using Microsoft.EntityFrameworkCore;

namespace NobatOnline.Areas.Makeuper.Controllers
{
    [Area("Makeuper")]
    public class ProvinceController : Controller
    {
        private readonly NobatOnlineContext Context;
        public ProvinceController(NobatOnlineContext _Context)
        {
            this.Context = _Context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return RedirectToAction("List");
        }
        [HttpGet]
        public async Task<IActionResult>List()
        {
            var list =await Context.Provinces.Select(p => new       { p.Id, p.Name }).ToListAsync();
            ListProvinceModel model = new ListProvinceModel();
            foreach (var item in list)
            {
                model.List.Add(new ListProvinceItemModel
                {
                    Id = item.Id,
                    Name = item.Name
                });
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Create(int? Id)
        {
            ProvinceModel model = new ProvinceModel();
            if (Id.HasValue)
            {
                var province =await Context.Provinces.FindAsync(Id);
                model.Id = province.Id;
                model.Name = province.Name;
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProvinceModel model)
        {
            if (ModelState.IsValid)
            {
                Province province = new Province();
                province.Id = model.Id;
                province.Name = model.Name;
                Context.Provinces.Update(province);
                await Context.SaveChangesAsync();
            }
            return RedirectToAction("List");
        }
        [HttpGet]
        public async Task<IActionResult> Remove(int Id)
        {
            var province =await Context.Provinces.FindAsync(Id);
            Context.Provinces.Remove(province);
            await Context.SaveChangesAsync();
            return RedirectToAction("List");
        }
    }
}