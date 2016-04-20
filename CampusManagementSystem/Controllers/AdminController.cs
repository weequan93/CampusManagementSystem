using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CampusManagementSystem.Models;
using System.Configuration;
using System.Data.SqlClient;

namespace CampusManagementSystem.Controllers
{
    public class AdminController : Controller
    {
        private NewwsContext db2 = new NewwsContext();
        private CoursesContext db = new CoursesContext();
        private ClassesContext db3 = new ClassesContext();
        private StudentsContext db4 = new StudentsContext();
        private TakensContext db5 = new TakensContext();
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

            var query = "SELECT * FROM dbo.Classes where Code='" + course.Code+"'";

            using (var context = new ClassesContext())
            {
                var blogs = context.Classes.SqlQuery(query).ToList();
                return View(blogs);
            }
            
            
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

        public ActionResult ClassCreate()
        {
            return View();
        }

        // POST: Admins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ClassCreate([Bind(Include = "Id,Code,Section,Student")] Classe classe)
        {
            if (ModelState.IsValid)
            {
                db3.Classes.Add(classe);
                db3.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(classe);
        }
        // GET: Admins/Details/5
        public ActionResult ClassDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classe classe = db3.Classes.Find(id);
            if (classe == null)
            {
                return HttpNotFound();
            }
            var currentyear = "2016";
            var query = "SELECT * FROM dbo.Takens where Code='" + classe.Code + "' AND Year='"+currentyear+"' AND Section ='"+classe.Section+"'";

            using (var context = new TakensContext())
            {
                var blogs = context.Takens.SqlQuery(query).ToList();
                return View(blogs);
            }
            
        }


        // GET: Admins/Edit/5
        public ActionResult ClassEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classe classe = db3.Classes.Find(id);
            if (classe == null)
            {
                return HttpNotFound();
            }
            return View(classe);
        }

        // POST: Admins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ClassEdit([Bind(Include = "Id,Code,Section,Student")] Classe classe)
        {
            if (ModelState.IsValid)
            {
                db3.Entry(classe).State = EntityState.Modified;
                db3.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(classe);
        }

        // GET: Admins/Delete/5
        public ActionResult ClassDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classe classe = db3.Classes.Find(id);
            if (classe == null)
            {
                return HttpNotFound();
            }
            return View(classe);
        }

        // POST: Admins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult ClassDeleteConfirmed(int id)
        {
            Classe classe = db3.Classes.Find(id);
            db3.Classes.Remove(classe);
            db3.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Students()
        {
            return View(db4.Students.ToList());
        }

        // GET: Admins/Details/5
        public ActionResult StudentsDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db4.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Admins/Create
        public ActionResult StudentsCreate()
        {
            return View();
        }

        // POST: Admins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StudentsCreate([Bind(Include = "Id,Acid,Year")] Student student)
        {
            if (ModelState.IsValid)
            {
                db4.Students.Add(student);
                db4.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Admins/Edit/5
        public ActionResult StudentsEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db4.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Admins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StudentsEdit([Bind(Include = "Id,Acid,Year")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Admins/Delete/5
        public ActionResult StudentsDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db4.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Admins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult StudentsDeleteConfirmed(int id)
        {
            Student student = db4.Students.Find(id);
            db4.Students.Remove(student);
            db4.SaveChanges();
            return RedirectToAction("Index");
        }
        // GET: Admins/Details/5
        public ActionResult TakenDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Taken taken = db5.Takens.Find(id);
            if (taken == null)
            {
                return HttpNotFound();
            }
            return View(taken);
        }

        // GET: Admins/Create
        public ActionResult TakenCreate()
        {
            return View();
        }

        // POST: Admins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TakenCreate([Bind(Include = "Id,Code,Acid,Section,Result,Year")] Taken taken)
        {
            if (ModelState.IsValid)
            {
                db5.Takens.Add(taken);
                db5.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(taken);
        }

        // GET: Admins/Edit/5
        public ActionResult TakenEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Taken taken = db5.Takens.Find(id);
            if (taken == null)
            {
                return HttpNotFound();
            }
            return View(taken);
        }

        // POST: Admins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TakenEdit([Bind(Include = "Id,Code,Acid,Section,Result,Year")] Taken taken)
        {
            if (ModelState.IsValid)
            {
                db5.Entry(taken).State = EntityState.Modified;
                db5.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(taken);
        }

        // GET: Admins/Delete/5
        public ActionResult TakenDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Taken taken = db5.Takens.Find(id);
            if (taken == null)
            {
                return HttpNotFound();
            }
            return View(taken);
        }

        // POST: Admins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult TakenDeleteConfirmed(int id)
        {
            Taken taken = db5.Takens.Find(id);
            db5.Takens.Remove(taken);
            db5.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}