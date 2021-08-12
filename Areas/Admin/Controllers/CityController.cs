using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
using Domains;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NobatOnline.Areas.Admin.Models;


namespace NobatOnline.Areas.Admin.Controllers
{
    [Area("Admin")]
    
    public class CityController : Controller
    {
        private readonly NobatOnlineContext Context;
        public CityController(NobatOnlineContext _Context)
        {
            this.Context = _Context;
        }
        public IActionResult Index()
        {
            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult List()
        {
            var cities = Context.Cities.Select(p => new
            {
                p.Id,
                p.Name,
                ProvinceName = p.Province.Name
            }).ToList();
            ListCityModel model = new ListCityModel();
            foreach (var item in cities)
            {
                model.List.Add(new ListCityItemModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    ProvinceName = item.ProvinceName
                });
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Create(int? Id)
        {


            CityModel model = new CityModel();
            if (Id.HasValue)
            {
                var city = Context.Cities.Find(Id);
                model.Id = city.Id;
                model.Name = city.Name;
                model.ProvinceId = city.ProvinceId;
            }
            PrepairProvince(model.Provices);
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(CityModel model)
        {
            if (ModelState.IsValid)
            {
                City city = new City();
                city.Id = model.Id;
                city.Name = model.Name;
                city.ProvinceId = model.ProvinceId;
                Context.Cities.Update(city);
                Context.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                PrepairProvince(model.Provices);
                return View(model);
            }
        }
        [HttpGet]
        public IActionResult Remove(int Id)
        {
            var citys = Context.Cities.Find(Id);
            Context.Cities.Remove(citys);
            Context.SaveChanges();
            return RedirectToAction("List");
        }
        [NonAction]
        public void PrepairProvince(List<SelectListItem> model)
        {
            var province = Context.Provinces.Select(p => new { p.Id, p.Name }).ToList();
            foreach (var item in province)
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