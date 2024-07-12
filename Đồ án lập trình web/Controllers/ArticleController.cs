using Đồ_án_lập_trình_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Đồ_án_lập_trình_web.Controllers
{
    public class ArticleController : Controller
    {
        // GET: Article
        CompanyDBConText db = new CompanyDBConText();
        public ActionResult Index(string alias)
        {
            var item = db.posts.FirstOrDefault(x => x.Alias == alias);
            return View(item);
        }
    }
}