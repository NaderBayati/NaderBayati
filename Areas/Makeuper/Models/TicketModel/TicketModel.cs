using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NobatOnline.Areas.Makeuper.Models
{
    public class TicketModel
    {
        [Required(ErrorMessage = UserValidation.TimeTicket)]
        [Display(Name = UserDisplay.TimeTicket)]
        public string StartTime { get; set; }
        [Required(ErrorMessage = UserValidation.TimeTicket)]
        [Display(Name = UserDisplay.TimeTicket)]
        public string EndTime { get; set; }
        [Required(ErrorMessage = UserValidation.TimeTicket)]
        [Display(Name = UserDisplay.TimeTicket)]
        public int SplitTime { get; set; }

        [Required(ErrorMessage = UserValidation.BeautyName)]
        [Display(Name = UserDisplay.BeautyName)]
        public int BeautyId { get; set; }
        public List<SelectListItem> Beauty { get; set; }
    }
}
