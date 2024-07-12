using Đồ_án_lập_trình_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Đồ_án_lập_trình_web.Areas.Admin.Controllers
{
    public class PostsController : Controller
    {
        // GET: Admin/Posts
        CompanyDBConText db = new CompanyDBConText();
        public ActionResult List()
        {
            var items = db.posts.ToList();
            return View(items);
        }
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Post model)
        {
            if (ModelState.IsValid)
            {
                model.CreateDate = DateTime.Now;
                model.CategoryId = 3;
                model.ModifiedDate = DateTime.Now;
                model.Alias = Đồ_án_lập_trình_web.Common.Filter.FilterChar(model.Title);
                db.posts.Add(model);
                db.SaveChanges();
                return RedirectToAction("List");
            }
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var item = db.posts.Find(id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Post model)
        {
            if (ModelState.IsValid)
            {
                model.ModifiedDate = DateTime.Now;
                model.Alias = Đồ_án_lập_trình_web.Common.Filter.FilterChar(model.Title);
                db.posts.Attach(model);
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("List");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.posts.Find(id);
            if (item != null)
            {
                db.posts.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
            }

            return Json(new { success = false });
        }

        [HttpPost]
        public ActionResult IsActive(int id)
        {
            var item = db.posts.Find(id);
            if (item != null)
            {
                item.IsActive = !item.IsActive;
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true, isAcive = item.IsActive });
            }

            return Json(new { success = false });
        }

        [HttpPost]
        public ActionResult DeleteAll(string ids)
        {
            if (!string.IsNullOrEmpty(ids))
            {
                var items = ids.Split(',');
                if (items != null && items.Any())
                {
                    foreach (var item in items)
                    {
                        var obj = db.posts.Find(Convert.ToInt32(item));
                        db.posts.Remove(obj);
                        db.SaveChanges();
                    }
                }
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}