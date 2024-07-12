using Đồ_án_lập_trình_web.Models;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;


namespace Đồ_án_lập_trình_web.ApiControllers
{


    public class ProductController : ApiController
    {
        CompanyDBConText db = new CompanyDBConText();
        [Route("Api/Product/GetListJson")]
        public IHttpActionResult GetListJson()
        {
            List<Product> products = db.Products.ToList();

            return Json(products);

        }
        [Route("Api/Product/GetProductById")]
        public IHttpActionResult GetProductById(long id)
        {
            Product product = GetProductByID(id);

            if (product == null)
            {
                return NotFound(); // Return 404 Not Found if the product is not found
            }

            return Json(product);
        }

        private Product GetProductByID(long ID)
        {
            Product product = db.Products.FirstOrDefault(row => row.ProductID == ID);
            return product;
        }

        //public void PostProduct(Product newPr)
        //{
        //    db.Products.Add(newPr);
        //    db.SaveChanges();
        //}

        [HttpPost]
        public IHttpActionResult PostProduct()
        {
            try
            {

                var newPr = new Product
                {
                    // Lấy các thông tin từ Request.Form
                    ProductName = HttpContext.Current.Request.Form["ProductName"],
                    ProductPrice = decimal.Parse(HttpContext.Current.Request.Form["ProductPrice"]),
                    DateOfPurchase = DateTime.Parse(HttpContext.Current.Request.Form["DateOfPurchase"]),
                    AvailabilityStatus = HttpContext.Current.Request.Form["AvailabilityStatus"],
                    CategoryID = int.Parse(HttpContext.Current.Request.Form["CategoryID"]),
                    BrandID = int.Parse(HttpContext.Current.Request.Form["BrandID"]),
                    Active = bool.Parse(HttpContext.Current.Request.Form["Active"])
                };

                var file = HttpContext.Current.Request.Files["fileProductImage"];

                if (file != null && file.ContentLength > 0)
                {
                    string rootFolder = HttpContext.Current.Server.MapPath("~/image/");
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string pathImage = Path.Combine(rootFolder, fileName);
                    file.SaveAs(pathImage);

                    newPr.ProductImage = "/image/" + fileName;
                }

                // Thêm sản phẩm vào cơ sở dữ liệu
                db.Products.Add(newPr);
                db.SaveChanges();

                return Ok(); // Hoặc có thể trả về một đối tượng JSON để thông báo thành công
            }
            catch (Exception ex)
            {
                // Ghi log lỗi
                Console.WriteLine($"Error: {ex.Message}");
                return InternalServerError(ex); // Trả về lỗi Internal Server Error
            }
        }

        [HttpPut]
        public IHttpActionResult PutProduct()
        {
            try
            {
                int productId = int.Parse(HttpContext.Current.Request.Form["ProductID"]);

                Product oldProduct = db.Products.Find(productId);

                if (oldProduct != null)
                {
                    oldProduct.ProductName = HttpContext.Current.Request.Form["ProductName"];
                    oldProduct.ProductPrice = decimal.Parse(HttpContext.Current.Request.Form["ProductPrice"]);
                    oldProduct.DateOfPurchase = DateTime.Parse(HttpContext.Current.Request.Form["DateOfPurchase"]);
                    oldProduct.AvailabilityStatus = HttpContext.Current.Request.Form["AvailabilityStatus"];
                    oldProduct.CategoryID = int.Parse(HttpContext.Current.Request.Form["CategoryID"]);
                    oldProduct.BrandID = int.Parse(HttpContext.Current.Request.Form["BrandID"]);
                    oldProduct.Active = bool.Parse(HttpContext.Current.Request.Form["Active"]);

                    var file = HttpContext.Current.Request.Files["fileProductImage"];

                    if (file != null && file.ContentLength > 0)
                    {
                        string rootFolder = HttpContext.Current.Server.MapPath("~/image/");
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        string pathImage = Path.Combine(rootFolder, fileName);
                        file.SaveAs(pathImage);

                        oldProduct.ProductImage = "/image/" + fileName;
                    }

                    db.SaveChanges();
                    return Ok(); // Hoặc có thể trả về một đối tượng JSON để thông báo thành công
                }

                return NotFound(); // Trả về 404 nếu không tìm thấy sản phẩm
            }
            catch (Exception ex)
            {
                // Ghi log lỗi
                Console.WriteLine($"Error: {ex.Message}");
                return InternalServerError(ex); // Trả về lỗi Internal Server Error
            }
        }


        //public void PutProduct(Product product)
        //    {
        //        Product oldProduct = db.Products.Where(row => row.ProductID == product.ProductID).FirstOrDefault();
        //        oldProduct.ProductImage = product.ProductImage;
        //        oldProduct.ProductName = product.ProductName;
        //        oldProduct.ProductPrice = product.ProductPrice;
        //        oldProduct.DateOfPurchase = product.DateOfPurchase;
        //        oldProduct.AvailabilityStatus = product.AvailabilityStatus;
        //        oldProduct.CategoryID = product.CategoryID;
        //        oldProduct.BrandID = product.BrandID;
        //        oldProduct.Active = product.Active;
        //        db.SaveChanges();
        //    }

        public void DeleteProduct(long id)
            {
                Product oldProduct = db.Products.Where(row => row.ProductID == id).FirstOrDefault();
                db.Products.Remove(oldProduct);
                db.SaveChanges();
            }

            //public Product GetProductByID(long ID)
            //{
            //    Product product = db.Products.Where(row => row.ProductID == ID).FirstOrDefault();
            //    return product;
            //}
            //public List<Product> Get()
            //{       
            //    List<Product> products = db.Products.ToList();
            //    return products;
            //}

        }
    }
