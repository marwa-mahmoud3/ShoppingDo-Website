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
    public class Products1Controller : Controller
    {
        ProductAppService productAppService = new ProductAppService();
        public ActionResult Index()
        {
            return View(productAppService.GetAllProduct().ToList());
        }

    }
}
