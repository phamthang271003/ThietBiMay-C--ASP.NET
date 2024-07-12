using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Đồ_án_lập_trình_web.CustomValidations;

namespace Đồ_án_lập_trình_web.Models
{
    [Serializable]
    public class Product
    {
        public long ProductID { get; set; }
       
        public string ProductImage { get; set; }
        [Required(ErrorMessage ="Product Name cannot br blank.")]


        [MinLength(4,ErrorMessage ="Product Name should contain at least 4 characters.")]
        public string ProductName { get; set; }
        //[DisplayFormat(DataFormatString = "{0:C}")]
        [Required]
        [Range(0,100000000,ErrorMessage ="Price should be in between 0 and 100000000")]

        //customer validations
        //[DivisibleBy100(ErrorMessage ="Price should in multiples 100.")]
        public Nullable<decimal> ProductPrice { get; set; }
        //[DisplayFormat(DataFormatString = "{0: dd/MM/yyyy }")]
        public Nullable<System.DateTime> DateOfPurchase { get; set; }
        [Required]
        public string AvailabilityStatus { get; set; }

        public string Alias { get; set; }
        public Nullable<long> CategoryID { get; set; }
        [Required]
        public Nullable<long> BrandID { get; set; }
        public Nullable<bool> Active { get; set; }
      
    
  

        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }

    
    }
}