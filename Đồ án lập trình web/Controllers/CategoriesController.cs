using Đồ_án_lập_trình_web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Đồ_án_lập_trình_web.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        CompanyDBConText db = new CompanyDBConText();
        public ActionResult List(int id)
        {
            List<Category> categories = db.Categories.Where(row => row.CategoryID == id).ToList();
            return View(categories);
        }
        public ActionResult ProductCategory(int id)
        {
            List<Product> products = db.Products.Where(row => row.CategoryID == id).ToList();
            ViewBag.Categories = db.Categories.ToList();
            return View(products);
        }
    }
}