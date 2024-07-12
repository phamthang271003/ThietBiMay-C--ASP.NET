using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Đồ_án_lập_trình_web.Models
{
    public class Brand
    {
        [Key]
        public long BrandID { get; set; }
        public string BrandName { get; set; }
    }
}