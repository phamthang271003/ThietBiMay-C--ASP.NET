using Đồ_án_lập_trình_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Đồ_án_lập_trình_web.Filters;
using System.Data.Entity.Validation;

namespace Đồ_án_lập_trình_web.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class ProductController : Controller
    {
        // GET: Admin/Product
        CompanyDBConText db = new CompanyDBConText();
        // GET: Product
        public ActionResult ListProduct(string search = "", string sortColumn = "ProductID", string iconClass = "fa-sort-asc", int page = 1)
        {
            List<Product> products = db.Products.Where(row => row.ProductName.Contains(search)).ToList();
            ViewBag.Search = search;
            //Sort
            ViewBag.SortColumn = sortColumn;
            ViewBag.IconClass = iconClass;
            if (sortColumn == "ProductID")
            {
                if (iconClass == "fa-sort-asc")
                {
                    products = products.OrderBy(row => row.ProductID).ToList();
                }
                else
                {
                    products = products.OrderByDescending(row => row.ProductID).ToList();
                }
            }

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
            if (sortColumn == "DateOfPurchase")
            {
                if (iconClass == "fa-sort-asc")
                {
                    products = products.OrderBy(row => row.DateOfPurchase).ToList();
                }
                else
                {
                    products = products.OrderByDescending(row => row.DateOfPurchase).ToList();
                }
            }
            int NoOfRecordPerPage = 5;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(products.Count) / Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordToSkip = (page - 1) * (NoOfRecordPerPage);
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            products = products.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();
            return View(products);
        }
        //public ActionResult Detail(int id)
        //{
        //    Product product = db.Products.Where(row => row.ProductID == id).FirstOrDefault();
        //    ViewBag.Brands = db.Brands.ToList();
        //    return View(product);
        //}
        public ActionResult CreateProduct()
        {
            ViewBag.Categories = db.Categories.ToList();
            ViewBag.Brands = db.Brands.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult CreateProduct(Product model, HttpPostedFileBase FileAnh)
        {
            if (ModelState.IsValid)
            {
                if (FileAnh.ContentLength > 0)
                {
                    string rootFolder = Server.MapPath("/image/");
                    string pathImage = rootFolder + FileAnh.FileName;
                    FileAnh.SaveAs(pathImage);
                    // lưu thuộc tính url hình ảnh
                    model.ProductImage = "/image/" + FileAnh.FileName;
                }
                //if (model.ID == 0)
                //{
                //    ModelState.AddModelError("", "ID phải nhập > 0");
                //    return View(model);
                //}
                db.Products.Add(model);
                db.SaveChanges();
                return RedirectToAction("ListProduct");
            }
            else
            {
                //ViewBag.Categories = db.Categories.ToList();
                //ViewBag.Brands = db.Brands.ToList();
                return View();
            }

        }
        public ActionResult EditProduct(int id)
        {
            Product product = db.Products.Where(row => row.ProductID == id).FirstOrDefault();
            ViewBag.Categories = db.Categories.ToList();
            ViewBag.Brands = db.Brands.ToList();
            return View(product);
        }
        [HttpPost]
        public ActionResult EditProduct(Product model, HttpPostedFileBase FileAnh)
        {
            Product product = db.Products.Where(row => row.ProductID == model.ProductID).FirstOrDefault();
            if (product != null)
            {
                if (FileAnh != null && FileAnh.ContentLength > 0)
                {
                    string rootFolder = Server.MapPath("/image/");
                    string pathImage = rootFolder + FileAnh.FileName;
                    FileAnh.SaveAs(pathImage);
                    // lưu thuộc tính url hình ảnh
                    model.ProductImage = "/image/" + FileAnh.FileName;
                }
                product.ProductImage = model.ProductImage;
                product.ProductName = model.ProductName;
                product.ProductPrice = model.ProductPrice;
                product.DateOfPurchase = model.DateOfPurchase;
                product.AvailabilityStatus = model.AvailabilityStatus;
                product.CategoryID = model.CategoryID;
                product.BrandID = model.BrandID;
                product.Active = model.Active;
                db.SaveChanges();
            }
            return RedirectToAction("ListProduct");
        }
        public ActionResult DeleteProduct(int id)
        {
            Product product = db.Products.Where(row => row.ProductID == id).FirstOrDefault();
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("ListProduct");
        }
    }
}