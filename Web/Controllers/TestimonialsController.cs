using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BL.AppServices;
using BL.ViewModel;
using DAL;

namespace Web.Controllers
{
    public class TestimonialsController : Controller
    {
        TestimonialsAppService testimonials = new TestimonialsAppService();
        ProductAppService productAppService = new ProductAppService();
        CategoryAppService categoryAppService=new CategoryAppService();
        // GET: TestimonialsViewModels
        public ActionResult ShowAllTestimonials()
        {
            ViewBag.test = testimonials.GetAllTestimonials();
            ViewBag.cats = categoryAppService.GetAllCateogries();
            return View(productAppService.GetAllProduct().ToList());
        }
    }
}
