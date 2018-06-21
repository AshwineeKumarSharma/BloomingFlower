using BloomingFlower.Areas.Admin.AdminViewModels;
using BloomingFlower.Areas.Admin.Models;
using BloomingFlower.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BloomingFlower.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        private MyDbContext db=new MyDbContext();
        // GET: Admin/Admin
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            

            return View();
        }

        [HttpPost]
        public ActionResult Login(AdminLoginViewModel el, string ReturnUrl)
        {
            MyDbContext db = new MyDbContext();
            var Password = Convert.ToBase64String(
        System.Text.ASCIIEncoding.ASCII.GetBytes(el.Password));
            var usr=db.UsersInfoes.Where(a=>a.UserName.Equals(el.UserName)&& a.Password.Equals(el.Password)).FirstOrDefault();
            if (usr != null)
            {
                FormsAuthentication.SetAuthCookie(usr.UserName, el.RememberMe);
                if (Url.IsLocalUrl(ReturnUrl))
                {
                    return Redirect(ReturnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Admin");
                }
            }
            return View(el);
        }



        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home", new {area=""});
        }

        public ActionResult UserRegistration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserRegistration(UserRegistration reg,RegisterUserInfo ui )
        {
            var usr = db.RegisterUserInfoes.Where(a => a.UserName.Equals(reg.UserName) && a.Password.Equals(reg.Password)).FirstOrDefault();
            if (usr != null)
            {
                return RedirectToAction("Index", "Home", new { @area = "" });
            }

            else
            {
                ui.Id = reg.Id;
                ui.UserName = reg.UserName;
                reg.Password = Convert.ToBase64String(System.Text.ASCIIEncoding
                    .ASCII.GetBytes(reg.Password));
                ui.Password = reg.Password;
                db.RegisterUserInfoes.Add(ui);
                db.SaveChanges();
               
            }
            return View();
        }
    }
}