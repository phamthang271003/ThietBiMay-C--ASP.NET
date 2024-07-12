using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
namespace Đồ_án_lập_trình_web.Identity
{
    public class AppUserStore :UserStore<AppUser>
    {
        public AppUserStore(AppDbContext dbContext) : base(dbContext) { }
    }
}