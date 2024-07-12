using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Đồ_án_lập_trình_web.Models
{
    public class CategoryMenu : CommonAbstract
    {
        public CategoryMenu()
        {
            this.News = new HashSet<New>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 
        public string Title { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
        public string SeoTittle { get; set; }
        public string SeoDescription { get; set; }
        public string SeoKeywords { get; set; }
        public int Position { get; set; }
        public ICollection<New> News { get; set; } 
        public ICollection<Post> Posts { get; set; } 

    }
}