using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Đồ_án_lập_trình_web.ViewModel;
using Đồ_án_lập_trình_web.Models;
using Đồ_án_lập_trình_web.Identity;
using System.Web.Helpers;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace Đồ_án_lập_trình_web.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterVM rmv)
        {
            if (ModelState.IsValid)
            {
                var appDbContext = new AppDbContext();
                var userStore = new AppUserStore(appDbContext);
                var userManager = new AppUserManager(userStore);
                var passwdHash = Crypto.HashPassword(rmv.Password);
                var user = new AppUser()
                {
                    Email = rmv.Email,
                    UserName = rmv.Username,
                    PasswordHash = passwdHash,
                    City = rmv.City,
                    Birthday = rmv.DateOfBirth,
                    Address = rmv.Address,
                    PhoneNumber = rmv.PhoneNumber,
                };
                IdentityResult identityResult = userManager.Create(user);
                if(identityResult.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Customer");
                   this.LoginUser(userManager, user);
                }
                return RedirectToAction("Index","Home");
            }
            else
            {
                ModelState.AddModelError("New Error", "Invalid Data");
                return View();
            }
        }
        public ActionResult Login()
        {
            CompanyDBConText db = new CompanyDBConText();
            ViewBag.Categories = db.Categories.ToList();
            ViewBag.Brands = db.Brands.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginVM lvm)
        {
            var appDbContext = new AppDbContext();
            var userStore = new AppUserStore(appDbContext);
            var userManager = new AppUserManager(userStore);
            var user = userManager.Find(lvm.Username, lvm.Password);
            if (user != null)
            {
               this.LoginUser(userManager, user);
                if (userManager.IsInRole(user.Id, "Admin"))
                {
                    return RedirectToAction("Index", "HomeAdmin", new { area = "Admin" });
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
                    
              
            }
            else
            {
                ModelState.AddModelError("MyError", "Invalid username and password.");
                return View();
            }
        }
        [NonAction]
        public void LoginUser(AppUserManager userManager, AppUser user)
        {
            var authenManager = HttpContext.GetOwinContext().Authentication;
            var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
            authenManager.SignIn(new AuthenticationProperties(), userIdentity);
        }
        public ActionResult Logout()
        {
            var authenManager = HttpContext.GetOwinContext().Authentication;
            authenManager.SignOut();
            Session["Cart"] = null;
            return RedirectToAction("Index","Home");
        }

    }
}