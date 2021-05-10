using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BL.AppServices;
using DAL;

namespace Web.Controllers
{
    [Authorize(Roles ="Admin")]
    public class UserCategoryController : Controller
    {
        CategoryAppService categoryAppService = new CategoryAppService();
        ProductAppService productAppService = new ProductAppService();
        public ActionResult Index()
        {
            ViewBag.cats = categoryAppService.GetAllCateogries();
            return View(productAppService.GetAllProduct().ToList());
        }

    }
}
