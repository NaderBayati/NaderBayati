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
        public TicketModel()
        {
            Beauty = new List<SelectListItem>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = UserValidation.DayName)]
        [Display(Name = UserDisplay.DayName)]
        public string DayName { get; set; }
        [Required(ErrorMessage = UserValidation.Date)]
        [Display(Name = UserDisplay.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = UserValidation.TimeTicket)]
        [Display(Name = UserDisplay.TimeTicket)]
        public string Time { get; set; }
        [Required(ErrorMessage = UserValidation.BeautyName)]
        [Display(Name = UserDisplay.BeautyName)]
        public int BeautyId { get; set; }
        public List<SelectListItem> Beauty { get; set; }
    }
}
