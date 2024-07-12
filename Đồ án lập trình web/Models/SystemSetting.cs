using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Đồ_án_lập_trình_web.Models
{
    public class SystemSetting
    {
        [Key]
        public string SettingKey { get; set; }
        public string SettingValue { get; set; }
        public string SettingDescription { get; set; }

    }
}