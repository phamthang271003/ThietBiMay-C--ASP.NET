using System.Web;
using System.Web.Mvc;
using Đồ_án_lập_trình_web.Filters;
namespace Đồ_án_lập_trình_web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new MyExceptionFilter());
        }
    }
}
