using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NobatOnline.Areas.Admin.Models
{
    public class CityModel
    {
        public CityModel()
        {
            Provices = new List<SelectListItem>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage =UserValidation.City)]
        [Display(Name=UserDisplay.CityName)]
        public string Name { get; set; }
        [Required(ErrorMessage =UserValidation.SelectProvince)]
        [Display(Name =UserDisplay.ProvinceName)]
        public int ProvinceId { get; set; }
        public List<SelectListItem> Provices { get; set; }
    }
}
