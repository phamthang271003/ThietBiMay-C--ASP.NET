using Đồ_án_lập_trình_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Đồ_án_lập_trình_web.Filters;


namespace Đồ_án_lập_trình_web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        CompanyDBConText db = new CompanyDBConText();
        public ActionResult Index(string search = "", string sortColumn = "ProductID", string iconClass = "fa-sort-asc", int page = 1)
        {
            List<Product> products = db.Products.Where(row => row.ProductName.Contains(search)).ToList();
            ViewBag.Categories = db.Categories.ToList();
            ViewBag.Brands = db.Brands.ToList();
            ViewBag.Search = search;
            ViewBag.SortColumn = sortColumn;
            ViewBag.IconClass = iconClass;
            if (sortColumn == "ProductName")
            {
                if (iconClass == "fa-sort-asc")
                {
                    products = products.OrderBy(row => row.ProductName).ToList();
                }
               
                else
                {
                    products = products.OrderByDescending(row => row.ProductName).ToList();
                }
            }
            if (sortColumn == "ProductPrice")
            {
                if (iconClass == "fa-sort-asc")
                {
                    products = products.OrderBy(row => row.ProductPrice).ToList();
                }
                else
                {
                    products = products.OrderByDescending(row => row.ProductPrice).ToList();
                }
            }

            int NoOfRecordPerPage = 12;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(products.Count) / Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordToSkip = (page - 1) * (NoOfRecordPerPage);
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            products = products.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();
            return View(products);
        }
        public ActionResult Error() { return View(); }
        public ActionResult Detail(int id)
        {
            Product product = db.Products.Where(row => row.ProductID == id).FirstOrDefault();
            ViewBag.Categories = db.Categories.ToList();
            ViewBag.Brands = db.Brands.ToList();
            return View(product);
        }
    }
}