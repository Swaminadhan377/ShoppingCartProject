using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShoppingCart.Models;

namespace ShoppingCart.Controllers
{
    public class LoginDetailsController : Controller
    {
        private shoppingcartContext db = new shoppingcartContext();

        // GET: LoginDetails
        public ActionResult Index()
        {
            return View(db.logindetails.ToList());
        }

        // GET: LoginDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            logindetail logindetail = db.logindetails.Find(id);
            if (logindetail == null)
            {
                return HttpNotFound();
            }
            return View(logindetail);
        }

        // GET: LoginDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoginDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "login_id,First_name,Middle_name,Last_name,gender,dob,email,password,confirm_password,roles")] logindetail logindetail)
        {
            if (ModelState.IsValid)
            {
                db.logindetails.Add(logindetail);
                db.SaveChanges();
                return RedirectToAction("Login","Login");
            }

            return View(logindetail);
        }

        // GET: LoginDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            logindetail logindetail = db.logindetails.Find(id);
            if (logindetail == null)
            {
                return HttpNotFound();
            }
            return View(logindetail);
        }

        // POST: LoginDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "login_id,First_name,Middle_name,Last_name,gender,dob,email,password,confirm_password,roles")] logindetail logindetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(logindetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(logindetail);
        }

        // GET: LoginDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            logindetail logindetail = db.logindetails.Find(id);
            if (logindetail == null)
            {
                return HttpNotFound();
            }
            return View(logindetail);
        }

        // POST: LoginDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            logindetail logindetail = db.logindetails.Find(id);
            db.logindetails.Remove(logindetail);
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
