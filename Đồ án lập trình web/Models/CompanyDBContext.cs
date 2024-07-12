using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace Đồ_án_lập_trình_web.Models
{
    public class CompanyDBConText : DbContext
    {
        public CompanyDBConText() : base("MyConnectionString") { }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
      
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Adv> advs { get; set; }
        public DbSet<CategoryMenu> CategoryMenus { get; set; }
        public DbSet<Contact> contacts { get; set; }
        public DbSet<New> news { get; set; }
        public DbSet<Post> posts { get; set; }
        public DbSet<Subscribe> subscribes { get; set; }
        public DbSet<SystemSetting> systemSettings { get; set; }

    }
}