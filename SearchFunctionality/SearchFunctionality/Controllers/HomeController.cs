using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SearchFunctionality.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            WebAppEntities db = new WebAppEntities();
            var users = db.tbl_UserRegistration.ToList();
            return View(users);
        }






        [HttpPost]

        public ActionResult Index(string SearchText)
        {
            WebAppEntities db = new WebAppEntities();
            var users = db.tbl_UserRegistration.ToList();

            if(SearchText != null)
            {
                users = db.tbl_UserRegistration.Where(x => x.UserName.Contains(SearchText) || x.Email.Contains(SearchText)).ToList();
            }
            return View(users);
        }

    }
}