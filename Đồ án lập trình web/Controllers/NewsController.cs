using Đồ_án_lập_trình_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Đồ_án_lập_trình_web.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        CompanyDBConText db = new CompanyDBConText();
        public ActionResult Index()
        {
            var items = db.news.ToList();
            return View(items);
        }
        public ActionResult Detail(int id)
        {
            var item = db.news.Find(id);
            return View(item);
        }
        public ActionResult Partial_News_Home()
        {
            var items = db.news.Take(3).ToList();
            return PartialView(items);
        }
    }
}