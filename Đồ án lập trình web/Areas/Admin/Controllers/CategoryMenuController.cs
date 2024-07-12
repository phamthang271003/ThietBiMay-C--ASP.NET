using Đồ_án_lập_trình_web.Identity;
using Đồ_án_lập_trình_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Đồ_án_lập_trình_web.Areas.Admin.Controllers
{
    public class CategoryMenuController : Controller
    {
        // GET: Admin/CategoryMenu
        CompanyDBConText db = new CompanyDBConText();
        public ActionResult List()
        {
            List<CategoryMenu> categoryMenus  =  db.CategoryMenus.ToList();
            return View(categoryMenus);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CategoryMenu model)
        {
            if(ModelState.IsValid)
            {
                model.CreateDate = DateTime.Now;
                model.ModifiedDate = DateTime.Now;
                model.Alias = Đồ_án_lập_trình_web.Common.Filter.FilterChar(model.Title);
                db.CategoryMenus.Add(model);
                db.SaveChanges();
                return RedirectToAction("List");
            }
            return View(model);          
        }
        public ActionResult Edit(int id)
        {
            CategoryMenu categoryMenu = db.CategoryMenus.Find(id);
            return View(categoryMenu);
        }
        [HttpPost]
        public ActionResult Edit(CategoryMenu model)
        {
            if (ModelState.IsValid)
            {
                db.CategoryMenus.Attach(model);
                model.ModifiedDate = DateTime.Now;
                model.Alias = Đồ_án_lập_trình_web.Common.Filter.FilterChar(model.Title);
                db.Entry(model).Property(x => x.Title).IsModified = true;
                db.Entry(model).Property(x => x.Description).IsModified = true;
                db.Entry(model).Property(x => x.Alias).IsModified = true;
                db.Entry(model).Property(x => x.SeoKeywords).IsModified = true;
                db.Entry(model).Property(x => x.SeoDescription).IsModified = true;
                db.Entry(model).Property(x => x.SeoTittle).IsModified = true;
                db.Entry(model).Property(x => x.Position).IsModified = true;
                db.Entry(model).Property(x => x.ModifiedDate).IsModified = true;
                db.Entry(model).Property(x => x.ModifiedBy).IsModified = true;
     
                db.SaveChanges();
                return RedirectToAction("List");
            }
            return View(model);
        }
        public ActionResult DeleteCategory(int id)
        {
            CategoryMenu categoryMenu = db.CategoryMenus.Where(row => row.Id == id).FirstOrDefault();
            db.CategoryMenus.Remove(categoryMenu);
            db.SaveChanges();
            return RedirectToAction("List");
        }
    }
}