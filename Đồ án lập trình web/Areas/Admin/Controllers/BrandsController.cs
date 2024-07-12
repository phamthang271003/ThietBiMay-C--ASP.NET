using Đồ_án_lập_trình_web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Đồ_án_lập_trình_web.Filters;

namespace Đồ_án_lập_trình_web.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class BrandsController : Controller
    {
        // GET: Admin/Brands  
        CompanyDBConText db = new CompanyDBConText();
        public ActionResult ListBrand()
        {

            List<Brand> brands = db.Brands.ToList();
            return View(brands);
        }
        public ActionResult CreateBrand()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateBrand(Brand model)
        {
            db.Brands.Add(model);
            db.SaveChanges();
            return RedirectToAction("ListBrand");
        }
        public ActionResult EditBrand(int id)
        {
            Brand brand = db.Brands.Where(row => row.BrandID == id).FirstOrDefault();
            return View(brand);
        }
        [HttpPost]
        public ActionResult EditBrand(Brand model)
        {
            Brand brand = db.Brands.Where(row => row.BrandID == model.BrandID).FirstOrDefault();
            if (brand != null)
            {
                brand.BrandName = model.BrandName;
                db.SaveChanges();
            }
            return RedirectToAction("ListBrand");
        }
        public ActionResult DeleteBrand(int id)
        {
            Brand brand = db.Brands.Where(row => row.BrandID == id).FirstOrDefault();
            db.Brands.Remove(brand);
            db.SaveChanges();
            return RedirectToAction("ListBrand");
        }

    }
}