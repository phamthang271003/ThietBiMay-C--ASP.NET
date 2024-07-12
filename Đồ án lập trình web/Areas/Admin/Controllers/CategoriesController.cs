using Đồ_án_lập_trình_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Đồ_án_lập_trình_web.Filters;

namespace Đồ_án_lập_trình_web.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class CategoriesController : Controller
    {
        // GET: Admin/Categories
        CompanyDBConText db = new CompanyDBConText();
        public ActionResult ListCategory()
        {  
            List<Category> categories = db.Categories.ToList();
            return View(categories);
        }
        public ActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCategory(Category model)
        {
            db.Categories.Add(model);
            db.SaveChanges();
            return RedirectToAction("ListCategory");
        }
        public ActionResult EditCategory(int id)
        {
            Category category = db.Categories.Where(row => row.CategoryID == id).FirstOrDefault();
            return View(category);
        }
        [HttpPost]
        public ActionResult EditCategory(Category model)
        {
            Category category = db.Categories.Where(row => row.CategoryID == model.CategoryID).FirstOrDefault();
            if (category != null)
            {
                category.CategoryName = model.CategoryName;
                db.SaveChanges();
            }
            return RedirectToAction("ListCategory");
        }
        public ActionResult DeleteCategory(int id)
        {
            Category category = db.Categories.Where(row => row.CategoryID == id).FirstOrDefault();
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("ListCategory");
        }

    }
}