using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NobatOnline.Areas.Makeuper.Models
{
    public class BeautyModel
    {
        public BeautyModel()
        {
            City = new List<SelectListItem>();
        }
        [Required(ErrorMessage = UserValidation.BeautyName)]
        [Display(Name = UserDisplay.BeautyName)]
        public string BeautyName { get; set; }

        [Required(ErrorMessage = UserValidation.City)]
        [Display(Name = UserDisplay.CityName)]
        public int CityId { get; set; }
        public List<SelectListItem> City { get; set; }
        [Required(ErrorMessage =UserValidation.Address)]
        [Display(Name=UserDisplay.Address)]
        public string Address { get; set; }
        [Required(ErrorMessage = UserValidation.PhoneNumber)]
        [Display(Name = UserDisplay.PhoneNumber)]
        public string Phone { get; set; }
    }

}
