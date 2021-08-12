using System;
using System.ComponentModel.DataAnnotations;
namespace NobatOnline.Models
{
    public class LoginModel
    {
        [Display(Name = UserDisplay.UserName)]
        [Required(ErrorMessage = UserValidation.UserName)]
        public string UserName { get; set; }
        [Display(Name = UserDisplay.Password)]
        [Required(ErrorMessage = UserValidation.UserName)]
        public string Password { get; set; }
    }
}