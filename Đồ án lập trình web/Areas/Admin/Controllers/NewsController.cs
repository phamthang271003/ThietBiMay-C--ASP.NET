using Đồ_án_lập_trình_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Đồ_án_lập_trình_web.Areas.Admin.Controllers
{
    public class NewsController : Controller
    {
        // GET: Admin/News
        CompanyDBConText db = new CompanyDBConText();
        public ActionResult List()
        {
            List<New> news = db.news.ToList();
            return View(news);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(New model)
        {
            if(ModelState.IsValid)
            {
                model.CreateDate = DateTime.Now;
                model.CategoryId = 3;
                model.ModifiedDate = DateTime.Now;
                model.Alias = Đồ_án_lập_trình_web.Common.Filter.FilterChar(model.Title);
                db.news.Add(model);
                db.SaveChanges();
                return RedirectToAction("List");
            }
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var item = db.news.Find(id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(New model)
        {
            if (ModelState.IsValid)
            {
                model.ModifiedDate = DateTime.Now;
                model.Alias = Đồ_án_lập_trình_web.Common.Filter.FilterChar(model.Title);
                db.news.Attach(model);
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("List");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.news.Find(id);
            if (item != null)
            {
                db.news.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
            }

            return Json(new { success = false });
        }

        [HttpPost]
        public ActionResult IsActive(int id)
        {
            var item = db.news.Find(id);
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
                        var obj = db.news.Find(Convert.ToInt32(item));
                        db.news.Remove(obj);
                        db.SaveChanges();
                    }
                }
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}