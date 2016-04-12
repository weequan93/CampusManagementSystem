using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CampusManagementSystem.Models;

namespace CampusManagementSystem.Controllers
{
    public class AdminsController : Controller
    {
        private NewwsContext db = new NewwsContext();

        // GET: Admins
        public ActionResult Index()
        {
            return View(db.Newws.ToList());
        }

        // GET: Admins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Neww neww = db.Newws.Find(id);
            if (neww == null)
            {
                return HttpNotFound();
            }
            return View(neww);
        }

        // GET: Admins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Info,Date")] Neww neww)
        {
            if (ModelState.IsValid)
            {
                db.Newws.Add(neww);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(neww);
        }

        // GET: Admins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Neww neww = db.Newws.Find(id);
            if (neww == null)
            {
                return HttpNotFound();
            }
            return View(neww);
        }

        // POST: Admins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Info,Date")] Neww neww)
        {
            if (ModelState.IsValid)
            {
                db.Entry(neww).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(neww);
        }

        // GET: Admins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Neww neww = db.Newws.Find(id);
            if (neww == null)
            {
                return HttpNotFound();
            }
            return View(neww);
        }

        // POST: Admins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Neww neww = db.Newws.Find(id);
            db.Newws.Remove(neww);
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
