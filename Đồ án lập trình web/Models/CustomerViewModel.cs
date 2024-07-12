using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Đồ_án_lập_trình_web.Models
{
    public class CustomerViewModel
    {
        public string customerName {  get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int Payment { get; set; }

    }
}