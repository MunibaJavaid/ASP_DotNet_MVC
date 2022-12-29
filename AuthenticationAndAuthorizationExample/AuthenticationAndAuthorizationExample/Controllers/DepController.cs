using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AuthenticationAndAuthorizationExample;

namespace AuthenticationAndAuthorizationExample.Controllers
{
    [Authorize]
    public class DepController : Controller
    {
        
        private UserMangementEntities1 db = new UserMangementEntities1();

        // GET: Dep
        
        public ActionResult Index()
        {
            return View(db.tbl_Dep.ToList());
        }

        // GET: Dep/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Dep tbl_Dep = db.tbl_Dep.Find(id);
            if (tbl_Dep == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Dep);
        }

        // GET: Dep/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dep/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DepId,DepName,HOD")] tbl_Dep tbl_Dep)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Dep.Add(tbl_Dep);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Dep);
        }

        // GET: Dep/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Dep tbl_Dep = db.tbl_Dep.Find(id);
            if (tbl_Dep == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Dep);
        }

        // POST: Dep/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DepId,DepName,HOD")] tbl_Dep tbl_Dep)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Dep).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Dep);
        }

        // GET: Dep/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Dep tbl_Dep = db.tbl_Dep.Find(id);
            if (tbl_Dep == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Dep);
        }

        // POST: Dep/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Dep tbl_Dep = db.tbl_Dep.Find(id);
            db.tbl_Dep.Remove(tbl_Dep);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
