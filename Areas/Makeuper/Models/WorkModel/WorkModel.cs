using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NobatOnline.Areas.Makeuper.Models
{
    public class WorkModel
    {
        public WorkModel()
        {
            Beauty = new List<SelectListItem>();
        }
        [Required(ErrorMessage = UserValidation.General)]
        public int Id { get; set; }
        [Required(ErrorMessage = UserValidation.Onvan)]
        [Display(Name = UserDisplay.Onvan)]
        public string onvan { get; set; }
        [Required(ErrorMessage = UserValidation.Price)]
        [Display(Name = UserDisplay.Price)]
        public int Price { get; set; }
        [Required(ErrorMessage = UserValidation.BeautyName)]
        [Display(Name = UserDisplay.BeautyName)]
        public int BeautyId { get; set; }
        public List<SelectListItem> Beauty { get; set; }

    }
}
