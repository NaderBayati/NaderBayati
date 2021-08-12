using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NobatOnline.Areas.Admin.Models
{
    public class CustomerModel
    {
        [Required(ErrorMessage = UserValidation.FirstName)]
        [Display(Name = UserDisplay.FirstName)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = UserValidation.LastName)]
        [Display(Name = UserDisplay.LastName)]
        public string LastName { get; set; }
        [Required(ErrorMessage = UserValidation.NationalCode)]
        [Display(Name = UserDisplay.NationalCode)]
        public string NationalCode { get; set; }
        [Required(ErrorMessage = UserValidation.UserName)]
        [Display(Name = UserDisplay.UserName)]
        [MinLength(5, ErrorMessage = "نام کاربری حداقل باید 5 کاراکتر باشد")]
        public string UserName { get; set; }
        [Required(ErrorMessage = UserValidation.Password)]
        [Display(Name = UserDisplay.Password)]
        [MinLength(8, ErrorMessage = "کلمه عبور باید حداقل 8 کاراکتر باشد")]
        public string Password { get; set; }
        [Required(ErrorMessage = UserValidation.ConfirmPassword)]
        [Display(Name = UserDisplay.ConfirmPassword)]
        [Compare("Password", ErrorMessage = UserValidation.NotMatchPassword)]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = UserValidation.PhoneNumber)]
        [Display(Name = UserDisplay.PhoneNumber)]
        [RegularExpression("[0]{1}[9]{1}[0-9]{9}", ErrorMessage = UserValidation.InvalidPhoneNumber)]
        public string PhoneNumber { get; set; }
    }
    public class EditCustomerModel

    {
        [Required(ErrorMessage = UserValidation.General)]
        public int Id { get; set; }
        [Required(ErrorMessage = UserValidation.FirstName)]
        [Display(Name = UserDisplay.FirstName)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = UserValidation.LastName)]
        [Display(Name = UserDisplay.LastName)]
        public string LastName { get; set; }
        [Required(ErrorMessage = UserValidation.NationalCode)]
        [Display(Name = UserDisplay.NationalCode)]
        public string NationalCode { get; set; }
        [Required(ErrorMessage = UserValidation.UserName)]
        [Display(Name = UserDisplay.UserName)]
        [MinLength(5, ErrorMessage = "نام کاربری حداقل باید 5 کاراکتر باشد")]
        public string UserName { get; set; }
        [Required(ErrorMessage = UserValidation.PhoneNumber)]
        [Display(Name = UserDisplay.PhoneNumber)]
        [RegularExpression("[0]{1}[9]{1}[0-9]{9}", ErrorMessage = UserValidation.InvalidPhoneNumber)]
        public string PhoneNumber { get; set; }
    }
}
