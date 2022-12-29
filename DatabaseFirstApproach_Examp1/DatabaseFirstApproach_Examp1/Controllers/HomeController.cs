using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatabaseFirstApproach_Examp1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Category()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Category(tbl_Category category) //create
        {
            WebAppDbContext db = new WebAppDbContext();
            db.tbl_Category.Add(category);
            db.SaveChanges();
            return View();
        }


        public ActionResult ListView()
        {
            WebAppDbContext db = new WebAppDbContext();
            var list = db.tbl_Category.ToList();
 
            return View(list);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            WebAppDbContext db = new WebAppDbContext();
            var category = db.tbl_Category.Find(id);
            return View(category);
        }
        [HttpPost]
        public ActionResult Edit(tbl_Category category)
        {
            WebAppDbContext db = new WebAppDbContext();
            db.Entry(category).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            
            return RedirectToAction("ListView");
        }

        public ActionResult Delete(int category_id)
        {
            WebAppDbContext db = new WebAppDbContext();
            var category = db.tbl_Category.Find(category_id);
            db.tbl_Category.Remove(category);
            db.SaveChanges();
            return RedirectToAction("ListView");


        }
    }
}