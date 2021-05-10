using BL.AppServices;
using BL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class ProductReviewController : Controller
    {
        ProductReviewAppService reviewAppService = new ProductReviewAppService();
        ProductAppService productAppService = new ProductAppService();
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ProductReviewViewModel newreview)
        {
            if (ModelState.IsValid == false)
                return View(newreview);
            reviewAppService.SaveNewReview(newreview);
            return RedirectToAction("Index");
        }
        // GET: 
        [System.Web.Mvc.Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            List<ProductReviewViewModel> s = reviewAppService.GetAllReviews();
            return View(s);
        }
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductReviewViewModel comment = reviewAppService.GetReviewById(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }
        public ActionResult Edit(int id)
        {
            ProductReviewViewModel s = reviewAppService.GetReviewById(id);
            return View(s);
        }
        [HttpPost]
        public ActionResult Edit(int id, ProductReviewViewModel reviews)
        {
            reviews.ID = id;
            if (ModelState.IsValid)
            {
                ProductReviewViewModel c = reviewAppService.GetReviewById(id);
                return View(c);
            }
            return View(reviews);
        }
        public ActionResult Delete(int id)
        {
            reviewAppService.DeleteReview(id);
            return RedirectToAction("Index");
        }
    }
}