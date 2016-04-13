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
    public class AdminController : Controller
    {
        private NewwsContext db2 = new NewwsContext();
        private CoursesContext db = new CoursesContext();
        // GET: Admin
        public ActionResult Index()
        {
            if (Session["UserId"] != null)
            {
                if (Session["userType"].Equals("Admin"))
                {
                    return View();
                }
            }
                
            return HttpNotFound();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult News()
        {
            if (Session["UserId"] != null)
            {
                if (Session["userType"].Equals("Admin"))
                {
                    return View(db2.Newws.ToList());
                }
            }

            return HttpNotFound();
            
        }

        // GET: Admins/Details/5
        public ActionResult NewwsDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Neww neww = db2.Newws.Find(id);
            if (neww == null)
            {
                return HttpNotFound();
            }
            return View(neww);
        }

        // GET: Admins/Create
        public ActionResult NewwsCreate()
        {
            return View();
        }

        // POST: Admins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewwsCreate([Bind(Include = "Id,Info,Date")] Neww neww)
        {
            if (ModelState.IsValid)
            {
                db2.Newws.Add(neww);
                db2.SaveChanges();
                return RedirectToAction("News");
            }

            return View(neww);
        }

        // GET: Admins/Edit/5
        public ActionResult NewwsEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Neww neww = db2.Newws.Find(id);
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
        public ActionResult NewwsEdit([Bind(Include = "Id,Info,Date")] Neww neww)
        {
            if (ModelState.IsValid)
            {
                db2.Entry(neww).State = EntityState.Modified;
                db2.SaveChanges();
                return RedirectToAction("News");
            }
            return View(neww);
        }

        // GET: Admins/Delete/5
        public ActionResult NewwsDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Neww neww = db2.Newws.Find(id);
            if (neww == null)
            {
                return HttpNotFound();
            }
            return View(neww);
        }

        // POST: Admins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult NewwsDeleteConfirmed(int id)
        {
            Neww neww = db2.Newws.Find(id);
            db2.Newws.Remove(neww);
            db2.SaveChanges();
            return RedirectToAction("News");

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db2.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult Courses()
        {
            return View(db.Courses.ToList());
        }
        // GET: Admins/Details/5
        public ActionResult CoursesDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // GET: Admins/CoursesCreate
        public ActionResult CoursesCreate()
        {
            return View();
        }

        // POST: Admins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CoursesCreate([Bind(Include = "Id,Code,Name,Section,Credit")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Courses");
            }

            return View(course);
        }

        // GET: Admins/Edit/5
        public ActionResult CoursesEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Admins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CoursesEdit([Bind(Include = "Id,Code,Name,Section,Credit")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Courses");
            }
            return View(course);
        }

        // GET: Admins/Delete/5
        public ActionResult CoursesDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Admins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult CoursesDeleteConfirmed(int id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
            db.SaveChanges();
            return RedirectToAction("Courses");
        }

    }
}