using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Đồ_án_lập_trình_web.Filters
{
    public class AdminAuthorization : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
           if(filterContext.HttpContext.User.IsInRole("Admin") == false)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }
    }
}