using Đồ_án_lập_trình_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Đồ_án_lập_trình_web.Filters;

namespace Đồ_án_lập_trình_web.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class HomeAdminController : Controller
    {
        CompanyDBConText db = new CompanyDBConText();
        // GET: Admin/HomeAdmin
        public ActionResult Index()
        {
            return View();
        }
    } 

}