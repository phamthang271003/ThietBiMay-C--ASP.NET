using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Đồ_án_lập_trình_web.Models
{
    [Table("tb_Order")]
    public class Order
    {
      
        public Order()
        {
           this.OrderDetails= new HashSet<OrderDetail>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required(ErrorMessage ="Tên khách hàng không để trống")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage ="Số điện thoại không để trống")]
        public string Phone { get; set; }
        [Required(ErrorMessage ="Địa chỉ không để trống")]
        public string Address { get; set; }
        public string Email { get; set; }
        public decimal ToTalAmount { get; set; }
        public int Quantity { get; set; }    
        public int TypePayment {  get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

    }
}