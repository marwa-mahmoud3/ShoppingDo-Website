using BL.AppServices;
using BL.ViewModel;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
        [Authorize]
        public class PaymentController : Controller
        {
            PaymentAppService paymentAppService = new PaymentAppService();

            public ActionResult Index()
            {
                return View(paymentAppService.GetAllPayments());
            }
            public ActionResult AllPayment()
            {
                ViewBag.payments = paymentAppService.GetAllPayments();
                return View(paymentAppService.GetAllPayments());
            }
            [HttpPost]
            public ActionResult Create(PaymentViewModel paymentViewModel)
            {
                paymentViewModel.userID = User.Identity.GetUserId();
                ViewBag.payments = paymentAppService.GetAllPayments();
                if (ModelState.IsValid == false)
                    return RedirectToAction("index", "cart"); //to be modfied and pass rigth CartPaymentInfoVieModel

                paymentAppService.SaveNewPayment(paymentViewModel);

                return RedirectToAction("index", "cart");
            }

            public ActionResult UpdatePayment(int ID)
            {
                PaymentViewModel paymentView = paymentAppService.GetPayment(ID);
                ViewBag.payments = paymentAppService.GetAllPayments();
                return View(paymentView);
            }
            public ActionResult UpdatePayment(PaymentViewModel paymentView)
            {

                paymentAppService.UpdatePayment(paymentView);
                return RedirectToAction("Index");
            }
            public ActionResult DeletePayment(int ID)
            {
                paymentAppService.DeletePayment(ID);
                return RedirectToAction("Index");
            }
        }
    }
