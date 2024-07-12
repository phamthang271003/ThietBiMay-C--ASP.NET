using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Đồ_án_lập_trình_web.Models
{
    public class Category
    {
        [Key]
        public long CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}