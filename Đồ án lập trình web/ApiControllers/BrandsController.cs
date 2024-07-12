using Đồ_án_lập_trình_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Đồ_án_lập_trình_web.ApiControllers
{
    public class BrandsController : ApiController
    {
        public List<Brand> GetBrands()
        {
            CompanyDBConText db = new CompanyDBConText();
            List<Brand> brands = db.Brands.ToList();
            return brands;
        }
        public Brand GetBrandByID(long ID)
        {
            CompanyDBConText db = new CompanyDBConText();
            Brand brand = db.Brands.Where(row => row.BrandID == ID).FirstOrDefault();
            return brand;
        }
    }
}
