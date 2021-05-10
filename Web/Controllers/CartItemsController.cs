using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;
using BL.AppServices;
namespace Web.Controllers
{
    public class CartItemsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        ProductAppService ProductAppService = new ProductAppService();
        CartItemAppService cartItemAppService = new CartItemAppService();
        public ActionResult Index()
        {
            ViewBag.cart = cartItemAppService.GetAllCartItems();
            return View(ProductAppService.GetAllProduct().ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CartItem cartItem = db.Cartitems.Find(id);
            if (cartItem == null)
            {
                return HttpNotFound();
            }
            return View(cartItem);
        }

        public ActionResult Create()
        {
            ViewBag.CartID = new SelectList(db.Carts, "ID", "UserID");
            ViewBag.productId = new SelectList(db.Products, "ID", "ProductName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,productId,CartID")] CartItem cartItem)
        {
            if (ModelState.IsValid)
            {
                db.Cartitems.Add(cartItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CartID = new SelectList(db.Carts, "ID", "UserID", cartItem.CartID);
            ViewBag.productId = new SelectList(db.Products, "ID", "ProductName", cartItem.productId);
            return View(cartItem);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CartItem cartItem = db.Cartitems.Find(id);
            if (cartItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.CartID = new SelectList(db.Carts, "ID", "UserID", cartItem.CartID);
            ViewBag.productId = new SelectList(db.Products, "ID", "ProductName", cartItem.productId);
            return View(cartItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,productId,CartID")] CartItem cartItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cartItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CartID = new SelectList(db.Carts, "ID", "UserID", cartItem.CartID);
            ViewBag.productId = new SelectList(db.Products, "ID", "ProductName", cartItem.productId);
            return View(cartItem);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CartItem cartItem = db.Cartitems.Find(id);
            if (cartItem == null)
            {
                return HttpNotFound();
            }
            return View(cartItem);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CartItem cartItem = db.Cartitems.Find(id);
            db.Cartitems.Remove(cartItem);
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
