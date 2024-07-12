using Đồ_án_lập_trình_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Đồ_án_lập_trình_web.Controllers
{
    public class BrandsController : Controller
    {
        // GET: Brands
        CompanyDBConText db = new CompanyDBConText();
        public ActionResult List(int id)
        {
            List<Brand> brands = db.Brands.Where(row => row.BrandID == id).ToList();
            return View(brands);
        }
        public ActionResult ProductBrand(int id)
        {
            List<Product> products = db.Products.Where(row => row.BrandID == id).ToList();
            ViewBag.Brands = db.Brands.ToList();
            ViewBag.Categories = db.Categories.ToList();
            return View(products);
        }
    }
}