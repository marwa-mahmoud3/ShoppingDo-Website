using BL.AppServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        CategoryAppService categoryAppService = new CategoryAppService();
        ProductAppService productAppService = new ProductAppService();
        TestimonialsAppService testimonials = new TestimonialsAppService();
        public ActionResult Index()
        {
            ViewBag.test = testimonials.GetAllTestimonials();
            ViewBag.cats = categoryAppService.GetAllCateogries();
            return View(productAppService.GetAllProduct().ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}