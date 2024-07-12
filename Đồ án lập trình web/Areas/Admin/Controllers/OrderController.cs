using Đồ_án_lập_trình_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using Đồ_án_lập_trình_web.Filters;

namespace Đồ_án_lập_trình_web.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class OrderController : Controller
    {
        private CompanyDBConText db = new CompanyDBConText();
        // GET: Admin/Order
        public ActionResult Index(int page = 1)
        {
            List<Order> orders = db.orders.OrderByDescending(x => x.CreatedDate).ToList();
            int NoOfRecordPerPage = 20;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(orders.Count) / Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordToSkip = (page - 1) * (NoOfRecordPerPage);
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            orders = orders.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();
            return View(orders);
        }
        public ActionResult Detail(int id)
        {
            Order orders = db.orders.Where(row => row.Id == id).FirstOrDefault();

            return View(orders);
        }
        public ActionResult Partial_SanPham(int id)
        {
            var items = db.OrderDetails.Where(row => row.OrderId == id).ToList();
            return PartialView(items);
        }
        [HttpPost]
        public ActionResult UpdateTT(int id , int trangthai)
        {
            var item = db.orders.Find(id);
            if(item != null)
            {
                db.orders.Attach(item);
                item.TypePayment = trangthai;
                db.Entry(item).Property(x => x.TypePayment).IsModified = true;
                db.SaveChanges();
                return Json(new { message = "Unsuccess", Success = true });
            }
            return Json(new { message = "Unsuccess", Success = false });
        }
      
    }
}
