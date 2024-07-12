using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Đồ_án_lập_trình_web.Identity;
using Đồ_án_lập_trình_web.Filters;
using Đồ_án_lập_trình_web.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Đồ_án_lập_trình_web.ViewModel;
using Microsoft.AspNet.Identity;
using System.Web.Helpers;
using Microsoft.Owin.Security;
using Microsoft.Owin.BuilderProperties;

namespace Đồ_án_lập_trình_web.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class UsersController : Controller
    {
        // GET: Admin/Users
        AppDbContext db = new AppDbContext();
        public ActionResult Index()
        {

            List<AppUser> users = db.Users.ToList();
            return View(users);
        }
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
                if (identityResult.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Customer");
                }
                return RedirectToAction("Index", "Users");
            }
            else
            {
                ModelState.AddModelError("New Error", "Invalid Data");
                return View();
            }
        }
        public ActionResult EditUser(string id)
        {
            var appDbContext = new AppDbContext();
            var userStore = new AppUserStore(appDbContext);
            var userManager = new AppUserManager(userStore);
            AppUser user = userManager.FindById(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult EditUser(AppUser userEdit)
        {
            var appDbContext = new AppDbContext();
            var userStore = new AppUserStore(appDbContext);
            var userManager = new AppUserManager(userStore);
            AppUser user = userManager.FindById(userEdit.Id);
            user.Email = userEdit.Email;
            user.UserName = userEdit.UserName;
            user.City = userEdit.City;
            user.PhoneNumber = userEdit.PhoneNumber;
            user.Birthday = userEdit.Birthday;
            user.Address = userEdit.Address;
            user.City = userEdit.City;
            userManager.Update(user);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteUser(string id)
        {
            var appDbContext = new AppDbContext();
            var userStore = new AppUserStore(appDbContext);
            var userManager = new AppUserManager(userStore);
            AppUser user = userManager.FindById(id);
            userManager.Delete(user);
            return RedirectToAction("Index");
        }
    }
}