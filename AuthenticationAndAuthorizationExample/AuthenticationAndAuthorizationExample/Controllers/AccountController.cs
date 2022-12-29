using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AuthenticationAndAuthorizationExample.Controllers
{
    public class AccountController : Controller
    {
        UserMangementEntities1 db = new UserMangementEntities1();

       
        [HttpGet]
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(tbl_User user)
        {
            var count = db.tbl_User.Where(x => x.UserName == user.UserName && x.Password == user.Password).Count();

            if(count != 0)
            {
                FormsAuthentication.SetAuthCookie(user.UserName, false);
                return RedirectToAction("Index", "Employee");
            }

            else
            {
                TempData["Msg"] = "UserName or Password is Incorrect";
                return View();
            }

          
        }
    }
}