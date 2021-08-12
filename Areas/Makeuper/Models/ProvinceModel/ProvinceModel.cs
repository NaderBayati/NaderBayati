using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NobatOnline.Areas.Makeuper.Models
{
    public class ProvinceModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = UserValidation.SelectProvince)]
        [Display(Name =UserDisplay.ProvinceName)]
        public string Name { get; set; }
    }
}
