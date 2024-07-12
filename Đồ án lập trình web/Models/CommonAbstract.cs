using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Đồ_án_lập_trình_web.Models
{
    public class CommonAbstract
    {
        public string CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}