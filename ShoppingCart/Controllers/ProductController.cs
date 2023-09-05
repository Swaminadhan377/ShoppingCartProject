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
    public class ProductController : Controller
    {
        private shoppingcartContext db = new shoppingcartContext();

        // GET: Product
        public ActionResult Index()
        {
            var productdetails = db.productdetails.Include(p => p.brand).Include(p => p.category);
            return View(productdetails.ToList());
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            productdetail productdetail = db.productdetails.Find(id);
            if (productdetail == null)
            {
                return HttpNotFound();
            }
            return View(productdetail);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            ViewBag.brand_id = new SelectList(db.brands, "brand_id", "brand_name");
            ViewBag.category_id = new SelectList(db.categories, "category_id", "category_name");
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "product_id,product_name,category_id,brand_id,description,price,current_stock,created_by,created_date,updated_by,updated_date,is_active")] productdetail productdetail)
        {
            if (ModelState.IsValid)
            {
                db.productdetails.Add(productdetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.brand_id = new SelectList(db.brands, "brand_id", "brand_name", productdetail.brand_id);
            ViewBag.category_id = new SelectList(db.categories, "category_id", "category_name", productdetail.category_id);
            return View(productdetail);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            productdetail productdetail = db.productdetails.Find(id);
            if (productdetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.brand_id = new SelectList(db.brands, "brand_id", "brand_name", productdetail.brand_id);
            ViewBag.category_id = new SelectList(db.categories, "category_id", "category_name", productdetail.category_id);
            return View(productdetail);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "product_id,product_name,category_id,brand_id,description,price,current_stock,created_by,created_date,updated_by,updated_date,is_active")] productdetail productdetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productdetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.brand_id = new SelectList(db.brands, "brand_id", "brand_name", productdetail.brand_id);
            ViewBag.category_id = new SelectList(db.categories, "category_id", "category_name", productdetail.category_id);
            return View(productdetail);
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            productdetail productdetail = db.productdetails.Find(id);
            if (productdetail == null)
            {
                return HttpNotFound();
            }
            return View(productdetail);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            productdetail productdetail = db.productdetails.Find(id);
            db.productdetails.Remove(productdetail);
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
