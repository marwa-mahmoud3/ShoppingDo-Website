using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BL.ViewModel;
using DAL;

namespace Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BrandsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Brands
        public ActionResult Index()
        {
            return View(db.Brands.ToList());
        }

        // GET: Brands/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brands brands = db.Brands.Find(id);
            if (brands == null)
            {
                return HttpNotFound();
            }
            return View(brands);
        }

        public ActionResult Create() => View(new BrandsViewModel());


        // POST: Brands/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,BrandName")] Brands brands)
        {
            if (ModelState.IsValid)
            {
                db.Brands.Add(brands);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(brands);
        }

        // GET: Brands/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brands brands = db.Brands.Find(id);
            if (brands == null)
            {
                return HttpNotFound();
            }
            return View(brands);
        }

        // POST: Brands/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,BrandName")] Brands brands)
        {
            if (ModelState.IsValid)
            {
                db.Entry(brands).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(brands);
        }

        // GET: Brands/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brands brands = db.Brands.Find(id);
            if (brands == null)
            {
                return HttpNotFound();
            }
            return View(brands);
        }

        // POST: Brands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Brands brands = db.Brands.Find(id);
            db.Brands.Remove(brands);
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
