using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServerSideValidation.Controllers
{
    public class HomeController : Controller
    {
        ValidationEntities db = new ValidationEntities();
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(tbl_Category category)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    db.tbl_Category.Add(category);
                    db.SaveChanges();
                    TempData["msg"] = "Category added Successfully";

                    ModelState.Clear();
                    return RedirectToAction("List");
                }
                else
                {
                    TempData["msg"] = "Category added UnSuccessfull";
                    return View();
                }
               
            }
            catch(Exception ex)
            {
                TempData["msg"] = "Category added failed"+ex;
                return View();
            }
            
        }

        public ActionResult List()
        {
            var cat = db.tbl_Category.ToList();
            return View(cat);
        }

    }
}