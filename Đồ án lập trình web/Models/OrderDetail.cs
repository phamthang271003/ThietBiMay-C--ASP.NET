﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Đồ_án_lập_trình_web.Models
{
    [Table("tb_OrderDetail")]
    public class OrderDetail
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public long ProductID { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }

    }
}