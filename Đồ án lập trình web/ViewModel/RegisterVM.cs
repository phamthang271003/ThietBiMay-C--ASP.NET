using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Đồ_án_lập_trình_web.ViewModel
{
    public class RegisterVM
    {
        [Required(ErrorMessage ="Username can not be blank.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password can not be blank.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "ConfirmPassword can not be blank.")]
        [Compare("Password",ErrorMessage ="Password and ConfirmPassword do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Email can not be blank.")]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime? DateOfBirth { get; set; }
        public string Address { get; set; }
        public string City { get; set; }    
    }
}