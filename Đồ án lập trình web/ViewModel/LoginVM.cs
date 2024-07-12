using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Đồ_án_lập_trình_web.ViewModel
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Username can not be blank.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password can not be blank.")]
        public string Password { get; set; }
    }
}